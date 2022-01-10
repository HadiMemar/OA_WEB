using OA_WEB.DataAccess.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
