using System.Collections.Generic;

namespace MvcCore.Helpers
{
    /// <summary>
    /// Clase para devolver resultados de operaciones estándar con detalles de errores en caso de existir.
    /// <para>Ver <see cref="OperationResult{TEntity}"/> la clase genérica</para>
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Lista de errores encontrados durante la operación.
        /// </summary>
        public List<KeyValuePair<string, string>> Errors { get; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Constructor con el resultado de la operación
        /// </summary>
        /// <param name="succeeded">Indica si la operación fue existosa o no.</param>
        public OperationResult(bool succeeded)
        {
            Succeeded = succeeded;
            Errors = new List<KeyValuePair<string, string>>();
        }

        public OperationResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<KeyValuePair<string, string>>();
        }

        public OperationResult(bool succeeded, string message, int id)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<KeyValuePair<string, string>>();
            Id = id;
        }

        public OperationResult(bool succeeded, string message, string error)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<KeyValuePair<string, string>>();
            AddError("", error);
        }

        public OperationResult(bool succeeded, string message, List<KeyValuePair<string, string>> errors)
        {
            Succeeded = succeeded;
            Message = message;
            Errors = new List<KeyValuePair<string, string>>();
            AddErrors(errors);
        }

        /// <summary>
        /// Indica si la operación de realizó con éxito o no.
        /// </summary>
        public bool Succeeded { get; private set; }

        public int Id { get; private set; }

        /// <summary>
        /// SIN USO: Indica si el resultado tiene un mensaje amigable para el usuario.
        /// </summary>
        public bool HasMessage { get; private set; }

        private string _message = string.Empty;

        /// <summary>
        /// Mensaje amigable para el usuario.
        /// </summary>
        public string Message { 
            get { return _message;}
            set
            {
                _message = value;
                if (!string.IsNullOrWhiteSpace(value))
                {
                  HasMessage = true;
                }
                else
                {
                    HasMessage = false;
                }            
            }
        }

        /// <summary>
        /// Agregar un error a la descripción. IMPORTANTE: Cuando se agrega un error el resultado de la operación se establece a falso.
        /// </summary>
        /// <param name="error">Descripción del error.</param>
        /// <param name="key">Nombre de la propiedad en la que se encontró el error. Pasar cadena vacía en caso de ser un error general.</param>
        public void AddError(string key, string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                Errors.Add(new KeyValuePair<string, string>(key, error));
                Succeeded = false;
            }
        }

        /// <summary>
        /// Agregar un lista de errorres al resultado de la operación. IMPORTANTE: Cuando se agrega un error el resultado de la operación se establece a falso.
        /// </summary>
        /// <param name="errors">Lista de errores a agregar.</param>
        public void AddErrors(List<KeyValuePair<string,string>> errors)
        {
            foreach (var error in errors)
            {
                AddError(error.Key, error.Value);
            }
        }
    }
}