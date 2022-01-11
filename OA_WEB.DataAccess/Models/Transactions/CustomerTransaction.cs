using OA_WEB.DataAccess.Models.Transactions;

namespace OA_WEB.DataAccess.Model
    .Transactions
{
    public class CustomerTransaction : AccountTransaction
    {
        public CustomerTransaction(string TargetAttribute) : base("Customers", TargetAttribute)
        {
        }
    }
}