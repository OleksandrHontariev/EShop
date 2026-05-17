using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.EfClasses
{
    public class Review
    {
        public int Id { get; set; }
        public string VoterName { get; set; }
        public int StarsNumber { get; set; }
        public string Comment { get; set; }

        // relationships
        public int ProductId { get; set; }
    }
}
