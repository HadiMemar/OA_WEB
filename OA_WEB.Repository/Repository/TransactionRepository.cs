using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Repository.UnitOfWork;
using OA_WEB.Service.Interface;
using OA_WEB.Service.Interface.Repository;
using System.Linq;

namespace OA_WEB.Repository.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Transaction GetTransById(int id)
        {
            var result = this._context.Set<Transaction>().Where(t => t.Id == id).AsNoTracking().FirstOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Trans not found", "403");
            }
            return result;
        }

        public bool Post(Transaction t)
        {
            double qty = t.Quantity;
            if (!t.Direction)
                qty = -qty;
            update(qty, t.TargetType, t.TargetAttribute, t.TargetId);

            return true;
        }

        private void update(double quantity, string targetType, string targetAttribute, int targetId)
        {
            IUnitOfWork unitOfWork = new UnitOfWorks(_context);
            Target tar = unitOfWork.Targets.GetTarget(targetType, targetId);
            if (tar != null)
            {
                tar.Update(quantity, targetAttribute);
                unitOfWork.Targets.UpdateTarget(targetType, tar);
            }
        }
    }
}