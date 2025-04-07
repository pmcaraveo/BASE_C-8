using System.Collections.Generic;

namespace MvcCore.Helpers
{
    /// <summary>
    /// Clase para devolder resultados de operaciones estándar con detalles de errores en caso de existir, además de un objeto de la clase indicada.
    /// <para>Ver <see cref="OperationResult"/> la clase base</para>
    /// </summary>
    /// <typeparam name="TEntity">Clase que espera que se devuelva en caso de que la operación sea satisfactoria.</typeparam>
    public class OperationResult<TEntity> : OperationResult
    {
        public OperationResult(bool succeeded)
            : base(succeeded) { }

        public OperationResult(bool succeeded, string message)
            : base(succeeded, message) { }

        public OperationResult(bool succeeded, TEntity entity)
            : base(succeeded)
        {
            Entity = entity;
        }

        public OperationResult(bool succeeded, TEntity entity, string message)
            : base(succeeded, message)
        {
            Entity = entity;
        }

        public OperationResult(bool succeeded, TEntity entity, string message, string error)
            : base(succeeded, message, error)
        {
            Entity = entity;
        }

        public OperationResult(bool succeeded, TEntity entity, string message, int id)
        : base(succeeded, message, id)
        {
            Entity = entity;
        }

        public OperationResult(bool succeeded, TEntity entity, string message, List<KeyValuePair<string, string>> errors)
            : base(succeeded, message, errors)
        {
            Entity = entity;
        }

        /// <summary>
        /// Objeto que se devuelve como resultado de la operación. Se considera que si la operación es satisfactoria debe devolver un objeto.
        /// </summary>
        public TEntity Entity { get; set; }
    }
}