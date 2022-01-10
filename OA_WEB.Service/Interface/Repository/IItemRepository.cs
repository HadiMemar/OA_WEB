using OA_WEB.DataAccess.Models;

namespace OA_WEB.Service.Interface.Repository
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        //public Target GetTarget(string tableName,int id);
        //void UpdateTarget(string type, Target tar);
    }
}