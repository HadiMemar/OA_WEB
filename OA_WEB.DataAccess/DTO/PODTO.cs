using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_WEB.DataAccess.DTO
{
    public class PODTO : CompoundTransDTO
    {
        public int HubId { get; set; }
        public String StockAttribute { get; set; }
        public String AccountType { get; set; }
        public String AccountAttribute { get; set; }
    }
}
