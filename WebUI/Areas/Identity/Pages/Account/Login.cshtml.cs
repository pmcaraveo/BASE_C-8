using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSJ.Application.Interfaces;
using MvcCore.Helpers;
using TSJ.Infraestructure.Identity;
using static TSJ.Application.Helpers.EncryptHelper;
using Microsoft.AspNetCore.Http;

namespace TDJ.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly TSJ.Application.Interfaces.IAuthenticationService _ldap;
        private readonly IAccountService _account;
        private readonly IHttpContextAccessor _http;

        public LoginModel(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger,
                          TSJ.Application.Interfaces.IAuthenticationService ldap, IAccountService account,
                          IHttpContextAccessor http)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _ldap = ldap;
            _account = account;
            _http = http;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "El usuario es requerido.")]
            [Display(Name = "Usuario")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "La contraseña es requerida.")]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Display(Name = "Recordarme?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                //Verifica si existe el usuario en dominio.
                var existUser = _ldap.ValidateUser(Input.UserName, Input.Password);

                if (existUser)
                {
                    //Encripta y guarda la contraseña en sesión.
                    var key = "E546C8DF278CD5931069B522E695D4F2";
                    HttpContext.Session.SetObject("Pass", EncryptString(Input.Password, key));

                    //Verifica si existe en la BD.
                    var existente = await _userManager.FindByNameAsync(Input.UserName);

                    if (existente == null)
                    {
                        MessageDanger("No tiene permisos para entrar al sistema.");
                        //var usuario = new ApplicationUser { UserName = Input.UserName, Email = Input.UserName + "@tsjqroo.gob.mx" };
                        //usuario.NombreCompleto = user.DisplayName;
                        //await _userManager.CreateAsync(usuario, Input.Password);
                        return LocalRedirect(returnUrl);
                    }

                    //Condición para saber si está activa la sesión del usuario
                    //if (existente.IsSession == false)
                    //{
                    if (existente.Activo && existente.EsExterno == false)
                    {
                        //Actualiza nombre completo y contraseña
                        //existente.NombreCompleto = user.DisplayName;
                        existente.PasswordHash = _userManager.PasswordHasher.HashPassword(existente, Input.Password);
                        var update = await _userManager.UpdateAsync(existente);

                        if (update.Succeeded)
                        {
                            var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                            if (result.Succeeded)
                            {
                                return LocalRedirect(returnUrl);
                            }

                            MessageDanger("Error, usuario o contraseña no válidos.");
                            return Page();
                        }
                        MessageDanger("No tiene permisos para ingresar al sistema.");
                    }

                    MessageDanger("No tiene permisos para ingresar al sistema.");
                    //}
                    //else
                    //{
                    //    MessageDanger("Ya existe una sesión abierta para este usuario. <a onclick=closeSession(" + existente.Id+")>Click aquí para cerrar la sesión abierta.</a>");
                    //    return Page();
                    //}
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return LocalRedirect(returnUrl);
                    }

                    MessageDanger("Error, usuario o contraseña no válidos.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}