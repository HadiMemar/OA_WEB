using OA_WEB.Service.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OA_WEB.Service.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Items { get; }
        ICustomerRepository Customers { get; }
        ITargetRepo Targets { get; }
        ITransactionRepository Transactions { get; }
        IPORepository POs { get; }
        ISORepository SOs { get; }
        IStockHubTransRepository StockHubTransactions { get; }
        IHubRepository Hubs { get; }


        int Complete();
    }
}
