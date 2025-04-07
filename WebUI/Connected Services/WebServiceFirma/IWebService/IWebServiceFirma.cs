using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using WebServiceFirma;

namespace TDJ.WebUI.Connected_Services.WebServiceFirma.IWebService
{
    [ServiceContract]
    public interface IWebServiceFirma
    {
        Task<WebservicesPortTypeClient> GetInstanceAsync();
        Task<string> GetUrlFirmado(string token, string blobFile, string sha);
    }
}
