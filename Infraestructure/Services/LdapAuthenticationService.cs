using Microsoft.Extensions.Options;
using Novell.Directory.Ldap;
using System;
using System.DirectoryServices;
using TSJ.Application.Interfaces;
using TSJ.Application.Ldap;
using TSJ.Domain.Entities;

namespace TSJ.Infraestructure.Ldap
{
    public class LdapAuthenticationService : IAuthenticationService
    {
        private const string DisplayNameAttribute = "DisplayName";
        private const string SAMAccountNameAttribute = "SAMAccountName";
        private readonly LdapConfig config;

        public LdapAuthenticationService(IOptions<LdapConfig> config)
        {
            this.config = config.Value;
        }

        public User Login(string userName, string password)
        {
            try
            {
                using (DirectoryEntry entry = new DirectoryEntry(config.Path, config.UserDomainName + "\\" + userName, password))
                {
                    using (DirectorySearcher searcher = new DirectorySearcher(entry))
                    {
                        searcher.Filter = String.Format("({0}={1})", SAMAccountNameAttribute, userName);
                        searcher.PropertiesToLoad.Add(DisplayNameAttribute);
                        searcher.PropertiesToLoad.Add(SAMAccountNameAttribute);
                        var result = searcher.FindOne();
                        if (result != null)
                        {
                            var displayName = result.Properties[DisplayNameAttribute];
                            var samAccountName = result.Properties[SAMAccountNameAttribute];

                            return new User
                            {
                                DisplayName = displayName == null || displayName.Count <= 0 ? null : displayName[0].ToString(),
                                UserName = samAccountName == null || samAccountName.Count <= 0 ? null : samAccountName[0].ToString(),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex == null)
                    throw new InvalidCastException(ex.Message);
                else
                    return null; // Devuelve nulo para validae con la contraseña de base de datos
            }
            return null;
        }

        public bool ValidateUser(string username, string password)
        {
            string userDn = $"{username}@tsjqroo.gob.mx";
            try
            {
                using (var connection = new LdapConnection { SecureSocketLayer = false })
                {
                    connection.Connect("tsjqroo.gob.mx", LdapConnection.DEFAULT_PORT);
                    connection.Bind(userDn, password);

                    if (connection.Bound) 
                        return true;
                }
            }
            catch (LdapException ex)
            {
                if (ex == null)
                    throw new InvalidCastException(ex.Message);
            }
            return false;
        }
    }
}