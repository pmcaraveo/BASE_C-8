using DocXToPdfConverter;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
//using TDJ.WebUI.Connected_Services.WebServiceFirma.IWebService;
using TSJ.Application.Interfaces;
using TSJ.Domain.Enums;

namespace TDJ.WebUI.HelpersWeb
{
    public static class ConvertToPdf
    {
        public static void ConvertWordToPdf(string path, string nameWord, string namePdf)
        {
            // initialize LibreOffice soffice.exe filepath
            //string locationOfLibreOfficeSoffice = @"F:\Proyectos\PortableOffice\LibreOfficePortablePrevious\App\libreoffice\program\soffice.exe";
            //string locationOfLibreOfficeSoffice = @"D:\PortableApps\LibreOfficePortable\App\libreoffice\program\soffice.exe";
            //string locationOfLibreOfficeSoffice = "/lib/libreoffice/program/soffice";
            string locationOfLibreOfficeSoffice = "/opt/libreoffice6.4/program/soffice";

            // define placeholders
            var placeholders = new Placeholders
            {
                NewLineTag = "",
                TextPlaceholderStartTag = "##",
                TextPlaceholderEndTag = "##",
                TablePlaceholderStartTag = "==",
                TablePlaceholderEndTag = "==",
                ImagePlaceholderStartTag = "++",
                ImagePlaceholderEndTag = "++"
            };
            // initialize report generator
            var pdf = new ReportGenerator(locationOfLibreOfficeSoffice);

            // convert DOCX to PDF
            pdf.Convert(path + nameWord, path + namePdf, placeholders);

        }
/*
        public static async Task<string> GetUID(string rutaCompleta, int id, IWebServiceFirma wsf)
        {
            //Elementos de TokenData: 0->Token del Usuario, 1-> Categoria del Documento, 2 -> URL de referencia, 3 -> ID Unico del documento como referencia (Númerico o Cadena)
            string[] config = { Uri.EscapeDataString("TSHZnkTGylYjHFcLTXyYzGbO6bSr1BEti1W0Vd3kKKk="), "6", "10.75.55.49", id.ToString() };
            string jsonString = JsonSerializer.Serialize(config);
            string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));

            //Leemos el archivo y convertimos a B64
            byte[] AsBytes = System.IO.File.ReadAllBytes(rutaCompleta);
            string base64String = Convert.ToBase64String(AsBytes);

            //Obtenemos su Hash256
            string sha256 = GetChecksum(HashingAlgoTypes.SHA256, rutaCompleta);

            //Llamamos al Webservice
            var eFirma = await wsf.GetUrlFirmado(token, base64String, sha256);
            dynamic data = JObject.Parse(eFirma);

            return data.UID;
        }
*/
        public static string GetChecksum(HashingAlgoTypes hashingAlgoType, string filename)
        {
            using var hasher = System.Security.Cryptography.HashAlgorithm.Create(hashingAlgoType.ToString());
            using var stream = System.IO.File.OpenRead(filename);
            var hash = hasher.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}