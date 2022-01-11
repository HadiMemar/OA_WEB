using System.Collections.Generic;

namespace OA_WEB.DataAccess.Models
{
    public class Hub
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}