using TSJ.Domain.Entities;

namespace TSJ.Application.Interfaces
{
    public interface IAuthenticationService
    {
        User Login(string userName, string password);
        bool ValidateUser(string username, string password);
    }
}