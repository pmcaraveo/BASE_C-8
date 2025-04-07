using MvcCore.Helpers;
using System.Threading.Tasks;

namespace TSJ.Application.Interfaces
{
    public interface IEMailService
    {
        Task<OperationResult> SendEmailAsync(int id);
    }
}