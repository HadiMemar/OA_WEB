using OA_WEB.DataAccess.Models.Transactions;
using System;
using System.Collections.Generic;

namespace OA_WEB.DataAccess.Models.CompundTransactions
{
    public class PO : CompoundTransaction
    {
        public int HubId { get; set; }

        public PO()
        {
            this.Direction = true;
        }

        public void CreateTransactionForItems(List<ItemEntry> entries)
        {
            Double total = 0;
            entries.ForEach(i =>
            {
                StockHubTrans shtop = new StockHubTrans("OnPO") { HubId = HubId, Price = i.Price, TargetId = i.ItemId, Direction = true, Quantity = i.Qty, };
                total += shtop.GetAmount();
                StockHubTrans shtoh = new StockHubTrans("OnHand")
                { HubId = HubId, Price = i.Price, TargetId = i.ItemId, Direction = false, Quantity = i.Qty, };

                LeafTransactions.Add(shtop);
                LeafTransactions.Add(shtoh);
            });
            Total = total;
            Transaction accountTrans = new AccountTransaction("Customers", "OnPO") { TargetId = TargetId, Direction = true, Quantity = total };
            LeafTransactions.Add(accountTrans);
        }
    }
}