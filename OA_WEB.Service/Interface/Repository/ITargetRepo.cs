using OA_WEB.DataAccess.Models;

namespace OA_WEB.Service.Interface.Repository
{
    public interface ITargetRepo
    {
        public Target GetTarget(string tableName, int id);

        //public Target GetTarget(string tableName, int id,int hubId);
        void UpdateTarget(string type, Target tar);
    }
}