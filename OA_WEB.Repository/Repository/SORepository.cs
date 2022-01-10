using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.Repository.Repository
{
    public class SORepository : GenericRepository<SO>, ISORepository
    {
        public SORepository(ApplicationDbContext context) : base(context)
        {

        }
        public SO GetSODetails(int id)
        {
            var result = this._context.Sos.AsNoTracking().Where(p => p.Id == id).Include(p => p.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("So transaction not found", "403");
            }
            return result;
        }

        public SO Post(int id)
        {
            IUnitOfWork _unitOfWork = new UnitOfWorks(_context);

            var result = _context.Sos.AsNoTracking().Where(p => p.Id == id).Include(p => p.LeafTransactions).SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("So transaction not found", "403");
            }
            result.LeafTransactions.ForEach(t =>
            {
                _unitOfWork.Transactions.Post(t);
            });
            return result;
        }
    }
}
