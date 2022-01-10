using OA_WEB.DataAccess.Models.Transactions;
using OA_WEB.Repository.AppDbContext;
using OA_WEB.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OA_WEB.Repository.Repository
{
    public class StockHubTransRepository : GenericRepository<StockHubTrans>, IStockHubTransRepository
    {
        public StockHubTransRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
