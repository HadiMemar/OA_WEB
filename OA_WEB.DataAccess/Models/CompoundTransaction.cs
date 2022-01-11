using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OA_WEB.DataAccess.Models
{
    public partial class CompoundTransaction
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public bool Direction { get; set; }
        public int TargetId { get; set; }
        public List<Transaction> LeafTransactions { get; set; } = new List<Transaction>();
        public Double Total { get; set; } = 0;
    }

    public partial class CompoundTransaction
    {
        public CompoundTransaction()
        {
        }

        //public virtual bool Post()
        //{
        //    this.LeafTransactions.ForEach(t => t.Post());
        //    return true;
        //}
        public double ReturnTotalPost()
        {
            return Total;
        }
    }
}