using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using OA_WEB.DataAccess.Models.Transactions;

namespace OA_WEB.DataAccess.Models.CompundTransactions
{
    public class PO : CompoundTransaction
    {
        public int HubId { get; set; }
        public String StockAttribute { get; set; }
        public String AccountType { get; set; }
        public String AccountAttribute { get; set; }
        public PO()
        {

        }
        public void CreateLeafTransactions(List<ItemEntry> entries)
        {
            Double total = 0;
            entries.ForEach(i =>
            {

                StockHubTrans aStockHubTrans = new StockHubTrans(StockAttribute) { HubId = HubId, Price = i.Price, TargetId = i.ItemId, Direction = Direction, Quantity = i.Qty, };
                total += aStockHubTrans.GetAmount();
                LeafTransactions.Add(aStockHubTrans);

            });
            Total = total;
            Transaction accountTrans = new AccountTransaction(AccountType, AccountAttribute) { TargetId = TargetId, Direction = Direction, Quantity = total };
            LeafTransactions.Add(accountTrans);
        }
    }
}
