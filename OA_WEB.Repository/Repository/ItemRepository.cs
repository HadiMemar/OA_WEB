using Microsoft.EntityFrameworkCore;
using OA_WEB.DataAccess.Models;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OA_WEB.Repository.Repository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }
        
    }
}
