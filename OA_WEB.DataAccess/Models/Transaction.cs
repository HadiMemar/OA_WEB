using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.DataAccess.Models
{
    public partial class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public virtual bool Direction { get; set; } = true;
        public double Quantity { get; set; } = 0;
        public string TargetType { get; set; }
        public string TargetAttribute { get; set; }
        public int TargetId { get; set; }
        [MaxLength(20)]
        public string Unit { get; set; }
    }
    public partial class Transaction
    {
        public Transaction(string TargetType, string TargetAttribute)
        {
            this.TargetType = TargetType;
            this.TargetAttribute = TargetAttribute;
        }
        //public virtual bool Post()
        //{
        //    double qty=Quantity;
        //    if (!Direction)
        //        qty = -qty;
        //    update(qty, TargetType, TargetAttribute, TargetId);

        //    return true;

        //}

        //private void update(double quantity, string targetType, string targetAttribute, int targetId)
        //{
        //    Target tar = _unitOfWork.Targets.GetTarget(targetType, targetId);
        //    if (tar != null)
        //    {
        //        tar.Update(quantity, targetAttribute);
        //        _unitOfWork.Targets.UpdateTarget(targetType, tar);
        //    }

        //}
        ////public void UnPost()
        ////{
        ////    if (Direction)//true for income 
        ////        Quantity = -Quantity;
        ////    this.Gateway.GetTargetObjectAndUpdate(TargetId, Quantity);

        ////}

    }
}
