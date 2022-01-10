using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OA_WEB.Repository.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Variables
        protected readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods
        public T Add(T entity)
        {
            var x = _context.Set<T>().Add(entity);
            return x.Entity;
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
        public T GetById(int id)
        {
            var result = _context.Set<T>().Find(id);
            if (result == null)
            {
                throw new NotFoundException("Data doesn't exist", "404");
            }
            return result;

        }
        public T Update(T entity)
        {
            //var res = _context.Set<T>().AsNoTracking().;
            //if (res == null)
            //{
            //    throw new NotFoundException("Data doesn't exist", "404");
            //}
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
        public bool Remove(int id)
        {
            var ent = _context.Set<T>().Find(id);
            if (ent == null)
            {
                throw new NotFoundException("Data doesn't exist", "404");
            }
            _context.Set<T>().Remove(ent);
            return true;
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
        #endregion
    }
}
