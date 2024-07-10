
using System.Linq.Expressions;


namespace BoletoBus.Common.Data.Repository
{
    /// <summary>
    /// Interfaces base para los repositorios de datos
    /// </summary>
    /// <typeparam name="TEntity">Entidad con la que se va a trabajar</typeparam>
    /// <typeparam name="TType">Id Por donde se va a buscar</typeparam>
    public interface IBaseRepository<TEntity, TType> where TEntity : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Agregar (TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Editar (TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Eliminar (TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<TEntity> GetAll();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntityBy (TType id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        bool Exists (Expression<Func<TEntity, bool>> filter);
       

    }
}
