using System;
using System.ComponentModel.DataAnnotations;

namespace OA_WEB.DataAccess.Models
{
    public partial class Item : Target
    {
        [Key]
        public int Id { get; set; }

        public int HubId { get; set; }
        public Hub Hub { get; set; }
        public int OnHand { get; set; } = 0;
        public int OnPO { get; set; } = 0;
    }

    public partial class Item : Target
    {
        public override int GetTargetId()
        {
            return this.Id;
        }

        public override bool Update(double quantity, string attribute)
        {
            if (this.GetType().GetProperty(attribute) != null)
            {
                int value = (int)this.GetType().GetProperty(attribute).GetValue(this);

                this.GetType().GetProperty(attribute).SetValue(this, value + (int)quantity);
                Console.WriteLine("Item (" + Id + ") : " + this.GetType().GetProperty(attribute).Name + " updated " + value + " -> " + this.GetType().GetProperty(attribute).GetValue(this).ToString() + "\n");

                return true;
            }
            return false;
        }
    }
}