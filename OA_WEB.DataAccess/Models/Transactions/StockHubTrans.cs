namespace OA_WEB.DataAccess.Models.Transactions
{
    public class StockHubTrans : StockTrans
    {
        public StockHubTrans(string TargetAttribute) : base(TargetAttribute)
        {
        }

        public int HubId { get; set; }
    }
}