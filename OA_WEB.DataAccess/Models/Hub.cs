using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.DataAccess.Models
{
    public class Hub
    {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
    }
}
