using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.DataAccess.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Direction { get; set; }
        public Double Quantity { get; set; }
        public string TargetType { get; set; }
        public string TargetAttribute { get; set; }
    }
}
