using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Exceptions;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;
using System.Linq;

namespace OA_WEB.Repository.Repository
{
    public class HubRepository : GenericRepository<Hub>, IHubRepository
    {
        public HubRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Hub GetHubDetailsById(int id)
        {
            var result = this._context.Hubs.Where(h => h.Id == id).Include(h => h.Items).AsNoTracking().SingleOrDefault();
            if (result == null)
            {
                throw new NotFoundException("Hub not found", "403");
            }
            return result;
        }
    }
}