using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MvcCore.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;
using TSJ.Domain.Entities;
using TSJ.Infraestructure.Persistence;

namespace TSJ.Infraestructure.Email
{
    public class EMailService : IEMailService
    {
        private readonly Con57DbContext _db;
        private readonly SmtpSettings _smtp;
        private readonly IHostingEnvironment _env;

        public EMailService(IOptions<SmtpSettings> smtp, IHostingEnvironment env, Con57DbContext db)
        {
            _smtp = smtp.Value;
            _env = env;
            _db = db;
        }

        public DateTime DateTimeServer()
        {
            var fecha = _db.ViewDateTimeServer.First();

            return fecha.DateTimeServer;
        }

        public async Task<OperationResult> SendEmailAsync(int id)
        {
            try
            {
                /*
                var sello = await _demanda.GetById(id);
                string wwwPath = _env.WebRootPath + "/img/Logo_TSJ.png";

                if (sello.Entity.EmailPresenta == null)
                {
                    return new OperationResult(false, "No existe correo electrónico para enviar el sello digital.");
                }

                var body = "<a href=" + sello.Entity.RutaFirmada + "> Ver el acuse del escrito.</a>";
                //var body = "<div class=\"row\">" +
                //                "<div class=\"col-md-8 offset-2\">" +
                //                    "<div class=\"card\">" +
                //                        "<div class=\"panel-header text-center\" style=\"text-align: center; background-color: #DAD2D0; border: 1px solid #DAD2D0;\">" +
                //                            "<img src=\"https://www.tsjqroo.gob.mx/images/LogoNuevo.png\" alt =\"Poder Judicial de Q.Roo\" />" +
                //                            "<p>OFICIALÍA DE PARTES COMÚN</p>" +
                //                            "<small>INICIO DEMANDA</small>" +
                //                        "</div>" +
                //                        "<div class=\"card-body\" style=\"border: 1px solid #DAD2D0;\">" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Folio: </strong>" + sello.Entity.Folio + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Recibido: </strong>" + sello.Entity.FechaRecepcion + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Documento: </strong>" + sello.Entity.TipoDocumento + " " + sello.Entity.Expediente + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Juzgado: </strong>" + sello.Entity.OrganoJudicial + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Presentó: </strong>" + sello.Entity.Presenta + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Juicio: </strong>" + sello.Entity.Juicio + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Acción: </strong>" + sello.Entity.Accion + "</p>" +
                //                            "<p style=\"margin-left: 10px;\"><strong>Anexos: </strong>" + sello.Entity.Anexo + "</p><br>" +
                //                            "<div style=\"text-align: center;\">" +
                //                                "<small>FECHA DE ENVÍO: " + DateTimeServer().ToString("dd/MM/yyyy HH:mm") + "</small>" +
                //                            "</div><br>" +
                //                        "</div>" +
                //                    "</div>" +
                //                "</div>" +
                //            "</div>";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtp.SenderName, _smtp.SenderEmail));
                message.To.Add(MailboxAddress.Parse(sello.Entity.EmailPresenta));
                message.Subject = "Recepción de " + sello.Entity.TipoDocumento + " " + sello.Entity.Expediente + " en fecha " + sello.Entity.FechaRecepcion;
                message.Body = new TextPart("html") { Text = body };
                //var builder = new BodyBuilder();
                //var path = Path.Combine("wwwroot/img", "image.jpg");
                //var imagen = builder.LinkedResources.Add(path);

                //imagen.ContentId = MimeUtils.GenerateMessageId();
                //builder.HtmlBody = body;
                //message.Body = builder.ToMessageBody();


                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    await client.ConnectAsync(_smtp.Server, _smtp.Port, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_smtp.UserName, _smtp.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                }

                return new OperationResult<ViewInicioDemanda>(true, sello.Entity, "Sello enviado con éxito al correo: " + sello.Entity.EmailPresenta);
                */
                return new OperationResult(true, "Sello enviado con éxito al correo: " + "<correo>");
            }
            catch (Exception e)
            {

                throw new InvalidCastException(e.Message);
            }
        }
    }
}