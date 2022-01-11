namespace OA_WEB.DataAccess.Models.Transactions
{
    public class AccountTransaction : Transaction
    {
        public AccountTransaction(string TargetType, string TargetAttribute) : base(TargetType, TargetAttribute)
        {
        }
    }
}