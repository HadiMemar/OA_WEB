using Microsoft.EntityFrameworkCore;
using OA_WEB.Common.Base;
using OA_WEB.DataAccess.Model;
using OA_WEB.DataAccess.Models;
using OA_WEB.DataAccess.Models.CompundTransactions;
using OA_WEB.DataAccess.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_WEB.Repository.AppDbContext
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<StockHubTrans> StockHubTransaction { get; set; }
        public DbSet<CompoundTransaction> CompoundTransactions { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<PO> POs { get; set; }
        public DbSet<SO> Sos { get; set; }
        public DbSet<Hub> Hubs { get; set; }


        public dynamic GetTable(string tableName)
        {

            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentException($"'{nameof(tableName)}' cannot be null or whitespace.", nameof(tableName));
            }

            if (this.GetType().GetProperty(tableName) != null)
            {
                var table = this.GetType().GetProperty(tableName).GetValue(this);

                return table;
            }
            return null;
        }
    }
}
