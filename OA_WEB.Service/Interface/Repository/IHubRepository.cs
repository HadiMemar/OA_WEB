using OA_WEB.DataAccess.Models;

namespace OA_WEB.Service.Interface.Repository
{
    public interface IHubRepository : IGenericRepository<Hub>
    {
        Hub GetHubDetailsById(int id);
    }
}