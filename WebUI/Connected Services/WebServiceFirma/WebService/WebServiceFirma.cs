using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using TDJ.WebUI.Connected_Services.WebServiceFirma.IWebService;
using WebServiceFirma;

namespace TDJ.WebUI.Connected_Services.WebServiceFirma.WebService
{
    public class WebServiceFirma : IWebServiceFirma
    {
        public readonly string serviceUrl = "https://efirma.tsjqroo.gob.mx/Documentos/Webservices";
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public WebServiceFirma()
        {
            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding = new BasicHttpBinding(endpointAddress.Uri.Scheme.ToLower() == "http" ?
                            BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport);
            basicHttpBinding.OpenTimeout = TimeSpan.MaxValue;
            basicHttpBinding.CloseTimeout = TimeSpan.MaxValue;
            basicHttpBinding.ReceiveTimeout = TimeSpan.MaxValue;
            basicHttpBinding.SendTimeout = TimeSpan.MaxValue;
        }

        public async Task<WebservicesPortTypeClient> GetInstanceAsync()
        {
            return await Task.Run(() => new WebservicesPortTypeClient());
        }

        public async Task<string> GetUrlFirmado(string token, string base64, string sha256)
        {
            var client = await GetInstanceAsync();
            var response = await client.sendToSignAsync(token, base64, sha256);
            
            return response.result.ToString();
        }
    }
}
