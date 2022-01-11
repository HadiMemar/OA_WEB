using Microsoft.EntityFrameworkCore;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;

namespace OA_WEB.Repository.Repository
{
    public class TargetRepo : ITargetRepo
    {
        protected readonly ApplicationDbContext _context;

        public TargetRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        public Target GetTarget(string tableName, int id)
        {
            var target = (Target)this._context.GetTable(tableName).Find(id);
            if (target != null)
            {
                return target;
            }
            return null;
        }

        //public Target GetTarget(string tableName, int id, int hubId)
        //{
        //    var target = (Target)_context.Items.AsNoTracking().Where(i => i.HubId == hubId).FirstOrDefault();

        //    if (target != null)
        //    {
        //        return target;
        //    }
        //    return null;
        //}

        public void UpdateTarget(string tableName, Target tar)
        {
            _context.Entry(tar).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}