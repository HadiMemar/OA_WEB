using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;

namespace OA_WEB.Repository.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}