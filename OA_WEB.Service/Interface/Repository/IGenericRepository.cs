using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OA_WEB.Service.Interface.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets Entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Finds Entity by expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// Update existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// Adds a range of entities at one time
        /// </summary>
        /// <param name="entities"></param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Removes entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Remove(int id);

        /// <summary>
        /// Removes a set of entities
        /// </summary>
        /// <param name="entities"></param>
        void RemoveRange(IEnumerable<T> entities);
    }
}