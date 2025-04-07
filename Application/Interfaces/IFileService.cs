using Microsoft.AspNetCore.Http;
using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TSJ.Application.Interfaces
{
    public interface IFileService
    {
        //string NombreAcuerdo(IFormFile file, int acuerdoId, int tipoAcuerdo);
        string NombrePdf(IFormFile file, int nodoId, int tipoNodoId, int inicioId);
        Task<OperationResult> SaveFile(string uploads, string filePath, IFormFile file);
        void DeleteFile(string filePath);
        Task<OperationResult> SaveFileLinux(string uploads, string filePath, IFormFile file);
        Task<OperationResult> SaveFileLinux2(string uploads, List<IFormFile> file, int id, int tipoNodoId, int inicioId);
        OperationResult ValidateSize(List<IFormFile> file);
    }
}