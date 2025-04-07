﻿using System;
using System.Collections.Generic;

namespace TSJ.Domain
{
    public partial class AspNetUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string NombreCompleto { get; set; }
        public bool Activo { get; set; }
        public int? UsuarioRegistraId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? UsuarioActualizaId { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public bool EsExterno { get; set; }
        public string RecoveryPassword { get; set; }
    }
}