using OA_WEB.Repository.AppDbContext;
using OA_WEB.Repository.Repository;
using OA_WEB.Service.Interface;
using OA_WEB.Service.Interface.Repository;

namespace OA_WEB.Repository.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWorks(ApplicationDbContext context)
        {
            _context = context;
            Items = new ItemRepository(_context);
            Customers = new CustomerRepository(_context);
            Targets = new TargetRepo(_context);
            Transactions = new TransactionRepository(_context);
            POs = new PORepository(_context);
            SOs = new SORepository(_context);
            StockHubTransactions = new StockHubTransRepository(_context);
            Hubs = new HubRepository(_context);
        }

        public IItemRepository Items { get; private set; }
        public ICustomerRepository Customers { get; private set; }
        public ITargetRepo Targets { get; private set; }
        public ITransactionRepository Transactions { get; private set; }
        public IPORepository POs { get; private set; }
        public ISORepository SOs { get; private set; }
        public IStockHubTransRepository StockHubTransactions { get; private set; }

        public IHubRepository Hubs { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}