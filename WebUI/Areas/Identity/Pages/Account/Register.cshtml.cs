using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MvcCore.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using TSJ.Application.Interfaces;
using TSJ.Infraestructure.Identity;

namespace TDJ.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : BasePageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ICatalogoService _catalogo;
        private readonly IAccountService _account;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            ICatalogoService catalogo,
            IAccountService account,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _catalogo = catalogo;
            _account = account;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public SelectList Roles { get; set; } = new MySelectList(Enumerable.Empty<SelectListItem>());

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El campo {0} es requerido.")]
            [Display(Name = "Usuario")]
            public string UserName { get; set; }
            /*
            //[Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }
            */
            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe contener al menos {2} y máximo {1} caracteres de longitud.", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido."), Display(Name = "Rol")]
            public int RolId { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            Roles = new MySelectList(await _catalogo.GetRolesAsync());
            ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var existente = await _account.GetUser(Input.UserName);
                if (existente.Succeeded)
                {
                    MessageDanger("Ya existe este usuario.");
                }
                var user = new ApplicationUser { UserName = Input.UserName, Email = Input.UserName + "@tsjqroo.gob.mx" };
                user.EmailConfirmed = true;
                user.UsuarioRegistraId = User.GetUserId();
                user.FechaRegistro = DateTime.Now;
                user.Activo = true;
                user.EsExterno = false;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, Input.UserName);
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User created a new account with password.");
                    var role = await _account.GetRolById(Input.RolId);
                    if (!role.Succeeded)
                    {
                        MessageDanger("No existe el rol seleccionado para el usuario. Edite el usuario para agregarle un rol.");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, role.Entity.Name);
                        var userInsertado = await _account.GetUser(Input.UserName);
                        //await _account.CreateDetailsUser(Input.AdministracionId, Input.OrganoJudicialId, Input.RolId, userInsertado.Entity.Id);
                    }
                    MessageSuccess("Registro creado con éxito.");
                    return RedirectToAction("Index", "Account");
                }
            }

            Roles = new MySelectList(await _catalogo.GetRolesAsync());
            return Page();
        }
    }
}