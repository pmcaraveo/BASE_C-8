﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceFirma
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://efirma.tsjqroo.gob.mx/soap/Webservices", ConfigurationName="WebServiceFirma.WebservicesPortType")]
    public interface WebservicesPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="#obtenerUsuarios", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.obtenerUsuariosResponse> obtenerUsuariosAsync(WebServiceFirma.obtenerUsuariosRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#datosDocumento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.datosDocumentoResponse> datosDocumentoAsync(WebServiceFirma.datosDocumentoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#getFirmantesDocumento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.getFirmantesDocumentoResponse> getFirmantesDocumentoAsync(WebServiceFirma.getFirmantesDocumentoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#finalizarService", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.finalizarServiceResponse> finalizarServiceAsync(WebServiceFirma.finalizarServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#cancelarService", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.cancelarServiceResponse> cancelarServiceAsync(WebServiceFirma.cancelarServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#protegerDocumento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.protegerDocumentoResponse> protegerDocumentoAsync(WebServiceFirma.protegerDocumentoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#desProtegerDocumento", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.desProtegerDocumentoResponse> desProtegerDocumentoAsync(WebServiceFirma.desProtegerDocumentoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#sendToSign", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.sendToSignResponse> sendToSignAsync(WebServiceFirma.sendToSignRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#suma", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.sumaResponse> sumaAsync(WebServiceFirma.sumaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="#sumaProtegida", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, SupportFaults=true, Use=System.ServiceModel.OperationFormatUse.Encoded)]
        System.Threading.Tasks.Task<WebServiceFirma.sumaProtegidaResponse> sumaProtegidaAsync(WebServiceFirma.sumaProtegidaRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerUsuarios", WrapperNamespace="", IsWrapped=true)]
    public partial class obtenerUsuariosRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        public obtenerUsuariosRequest()
        {
        }
        
        public obtenerUsuariosRequest(string tokenData)
        {
            this.tokenData = tokenData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="obtenerUsuariosResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class obtenerUsuariosResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public obtenerUsuariosResponse()
        {
        }
        
        public obtenerUsuariosResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="datosDocumento", WrapperNamespace="", IsWrapped=true)]
    public partial class datosDocumentoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public datosDocumentoRequest()
        {
        }
        
        public datosDocumentoRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="datosDocumentoResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class datosDocumentoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public datosDocumentoResponse()
        {
        }
        
        public datosDocumentoResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFirmantesDocumento", WrapperNamespace="", IsWrapped=true)]
    public partial class getFirmantesDocumentoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public getFirmantesDocumentoRequest()
        {
        }
        
        public getFirmantesDocumentoRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="getFirmantesDocumentoResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class getFirmantesDocumentoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public getFirmantesDocumentoResponse()
        {
        }
        
        public getFirmantesDocumentoResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="finalizarService", WrapperNamespace="", IsWrapped=true)]
    public partial class finalizarServiceRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public finalizarServiceRequest()
        {
        }
        
        public finalizarServiceRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="finalizarServiceResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class finalizarServiceResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public finalizarServiceResponse()
        {
        }
        
        public finalizarServiceResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cancelarService", WrapperNamespace="", IsWrapped=true)]
    public partial class cancelarServiceRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public cancelarServiceRequest()
        {
        }
        
        public cancelarServiceRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="cancelarServiceResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class cancelarServiceResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public cancelarServiceResponse()
        {
        }
        
        public cancelarServiceResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="protegerDocumento", WrapperNamespace="", IsWrapped=true)]
    public partial class protegerDocumentoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public protegerDocumentoRequest()
        {
        }
        
        public protegerDocumentoRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="protegerDocumentoResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class protegerDocumentoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public protegerDocumentoResponse()
        {
        }
        
        public protegerDocumentoResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="desProtegerDocumento", WrapperNamespace="", IsWrapped=true)]
    public partial class desProtegerDocumentoRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string id_documento;
        
        public desProtegerDocumentoRequest()
        {
        }
        
        public desProtegerDocumentoRequest(string tokenData, string id_documento)
        {
            this.tokenData = tokenData;
            this.id_documento = id_documento;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="desProtegerDocumentoResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class desProtegerDocumentoResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public desProtegerDocumentoResponse()
        {
        }
        
        public desProtegerDocumentoResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendToSign", WrapperNamespace="", IsWrapped=true)]
    public partial class sendToSignRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public string blob_File;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public string sha256File;
        
        public sendToSignRequest()
        {
        }
        
        public sendToSignRequest(string tokenData, string blob_File, string sha256File)
        {
            this.tokenData = tokenData;
            this.blob_File = blob_File;
            this.sha256File = sha256File;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sendToSignResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class sendToSignResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public sendToSignResponse()
        {
        }
        
        public sendToSignResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="suma", WrapperNamespace="", IsWrapped=true)]
    public partial class sumaRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public int numero1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public int numero2;
        
        public sumaRequest()
        {
        }
        
        public sumaRequest(int numero1, int numero2)
        {
            this.numero1 = numero1;
            this.numero2 = numero2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sumaResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class sumaResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public sumaResponse()
        {
        }
        
        public sumaResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sumaProtegida", WrapperNamespace="", IsWrapped=true)]
    public partial class sumaProtegidaRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string tokenData;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
        public int numero1;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
        public int numero2;
        
        public sumaProtegidaRequest()
        {
        }
        
        public sumaProtegidaRequest(string tokenData, int numero1, int numero2)
        {
            this.tokenData = tokenData;
            this.numero1 = numero1;
            this.numero2 = numero2;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="sumaProtegidaResponse", WrapperNamespace="", IsWrapped=true)]
    public partial class sumaProtegidaResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
        public string result;
        
        public sumaProtegidaResponse()
        {
        }
        
        public sumaProtegidaResponse(string result)
        {
            this.result = result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface WebservicesPortTypeChannel : WebServiceFirma.WebservicesPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class WebservicesPortTypeClient : System.ServiceModel.ClientBase<WebServiceFirma.WebservicesPortType>, WebServiceFirma.WebservicesPortType
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public WebservicesPortTypeClient() : 
                base(WebservicesPortTypeClient.GetDefaultBinding(), WebservicesPortTypeClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.WebservicesPort.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebservicesPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(WebservicesPortTypeClient.GetBindingForEndpoint(endpointConfiguration), WebservicesPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebservicesPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(WebservicesPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebservicesPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(WebservicesPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public WebservicesPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.obtenerUsuariosResponse> WebServiceFirma.WebservicesPortType.obtenerUsuariosAsync(WebServiceFirma.obtenerUsuariosRequest request)
        {
            return base.Channel.obtenerUsuariosAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.obtenerUsuariosResponse> obtenerUsuariosAsync(string tokenData)
        {
            WebServiceFirma.obtenerUsuariosRequest inValue = new WebServiceFirma.obtenerUsuariosRequest();
            inValue.tokenData = tokenData;
            return ((WebServiceFirma.WebservicesPortType)(this)).obtenerUsuariosAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.datosDocumentoResponse> WebServiceFirma.WebservicesPortType.datosDocumentoAsync(WebServiceFirma.datosDocumentoRequest request)
        {
            return base.Channel.datosDocumentoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.datosDocumentoResponse> datosDocumentoAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.datosDocumentoRequest inValue = new WebServiceFirma.datosDocumentoRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).datosDocumentoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.getFirmantesDocumentoResponse> WebServiceFirma.WebservicesPortType.getFirmantesDocumentoAsync(WebServiceFirma.getFirmantesDocumentoRequest request)
        {
            return base.Channel.getFirmantesDocumentoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.getFirmantesDocumentoResponse> getFirmantesDocumentoAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.getFirmantesDocumentoRequest inValue = new WebServiceFirma.getFirmantesDocumentoRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).getFirmantesDocumentoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.finalizarServiceResponse> WebServiceFirma.WebservicesPortType.finalizarServiceAsync(WebServiceFirma.finalizarServiceRequest request)
        {
            return base.Channel.finalizarServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.finalizarServiceResponse> finalizarServiceAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.finalizarServiceRequest inValue = new WebServiceFirma.finalizarServiceRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).finalizarServiceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.cancelarServiceResponse> WebServiceFirma.WebservicesPortType.cancelarServiceAsync(WebServiceFirma.cancelarServiceRequest request)
        {
            return base.Channel.cancelarServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.cancelarServiceResponse> cancelarServiceAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.cancelarServiceRequest inValue = new WebServiceFirma.cancelarServiceRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).cancelarServiceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.protegerDocumentoResponse> WebServiceFirma.WebservicesPortType.protegerDocumentoAsync(WebServiceFirma.protegerDocumentoRequest request)
        {
            return base.Channel.protegerDocumentoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.protegerDocumentoResponse> protegerDocumentoAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.protegerDocumentoRequest inValue = new WebServiceFirma.protegerDocumentoRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).protegerDocumentoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.desProtegerDocumentoResponse> WebServiceFirma.WebservicesPortType.desProtegerDocumentoAsync(WebServiceFirma.desProtegerDocumentoRequest request)
        {
            return base.Channel.desProtegerDocumentoAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.desProtegerDocumentoResponse> desProtegerDocumentoAsync(string tokenData, string id_documento)
        {
            WebServiceFirma.desProtegerDocumentoRequest inValue = new WebServiceFirma.desProtegerDocumentoRequest();
            inValue.tokenData = tokenData;
            inValue.id_documento = id_documento;
            return ((WebServiceFirma.WebservicesPortType)(this)).desProtegerDocumentoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.sendToSignResponse> WebServiceFirma.WebservicesPortType.sendToSignAsync(WebServiceFirma.sendToSignRequest request)
        {
            return base.Channel.sendToSignAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.sendToSignResponse> sendToSignAsync(string tokenData, string blob_File, string sha256File)
        {
            WebServiceFirma.sendToSignRequest inValue = new WebServiceFirma.sendToSignRequest();
            inValue.tokenData = tokenData;
            inValue.blob_File = blob_File;
            inValue.sha256File = sha256File;
            return ((WebServiceFirma.WebservicesPortType)(this)).sendToSignAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.sumaResponse> WebServiceFirma.WebservicesPortType.sumaAsync(WebServiceFirma.sumaRequest request)
        {
            return base.Channel.sumaAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.sumaResponse> sumaAsync(int numero1, int numero2)
        {
            WebServiceFirma.sumaRequest inValue = new WebServiceFirma.sumaRequest();
            inValue.numero1 = numero1;
            inValue.numero2 = numero2;
            return ((WebServiceFirma.WebservicesPortType)(this)).sumaAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebServiceFirma.sumaProtegidaResponse> WebServiceFirma.WebservicesPortType.sumaProtegidaAsync(WebServiceFirma.sumaProtegidaRequest request)
        {
            return base.Channel.sumaProtegidaAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebServiceFirma.sumaProtegidaResponse> sumaProtegidaAsync(string tokenData, int numero1, int numero2)
        {
            WebServiceFirma.sumaProtegidaRequest inValue = new WebServiceFirma.sumaProtegidaRequest();
            inValue.tokenData = tokenData;
            inValue.numero1 = numero1;
            inValue.numero2 = numero2;
            return ((WebServiceFirma.WebservicesPortType)(this)).sumaProtegidaAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebservicesPort))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.WebservicesPort))
            {
                return new System.ServiceModel.EndpointAddress("https://efirma.tsjqroo.gob.mx/Documentos/Webservices?wsdl");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return WebservicesPortTypeClient.GetBindingForEndpoint(EndpointConfiguration.WebservicesPort);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return WebservicesPortTypeClient.GetEndpointAddress(EndpointConfiguration.WebservicesPort);
        }
        
        public enum EndpointConfiguration
        {
            
            WebservicesPort,
        }
    }
}
