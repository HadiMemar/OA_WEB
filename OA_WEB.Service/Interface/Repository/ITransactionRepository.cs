
using OA_WEB.DataAccess.Models;

namespace OA_WEB.Service.Interface.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        public Transaction GetTransById(int id);
        public bool Post(Transaction t);
    }
}