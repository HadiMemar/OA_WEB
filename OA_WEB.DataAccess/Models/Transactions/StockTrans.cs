namespace OA_WEB.DataAccess.Models.Transactions
{
    public class StockTrans : Transaction
    {
        public StockTrans(string TargetAttribute) : base("Items", TargetAttribute)
        {
        }

        public int Price { get; set; }

        public double GetAmount()
        {
            return this.Quantity * Price;
        }

        public double GetQty()
        {
            return this.Quantity;
        }
    }
}