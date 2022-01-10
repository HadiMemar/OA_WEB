using OA_WEB.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.DataAccess.DTO
{
    public class CompoundTransDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Direction { get; set; }
        public int TargetId { get; set; }
        public List<TransactionDTO> LeafTransactions { get; set; }
        public List<ItemEntry> Entries { get; set; }

    }
}
