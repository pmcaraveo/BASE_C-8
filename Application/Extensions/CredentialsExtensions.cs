using SimpleImpersonation;

namespace TSJ.Application.Extensions
{
    public static class CredentialsExtensions
    {
        public static UserCredentials CredentialsToServer()
        {
            var credentials = new UserCredentials("tsjqroo", "webapps", "11pr06ramad0reZ");

            return credentials;
        }
    }
}