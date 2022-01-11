namespace OA_WEB.DataAccess.DTO
{
    public class StockHubTransactionDTO : TransactionDTO
    {
        public int HubId { get; set; }
        public double Price { get; set; }
    }
}