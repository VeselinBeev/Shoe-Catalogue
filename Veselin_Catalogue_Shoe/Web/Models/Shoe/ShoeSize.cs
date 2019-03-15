using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Shoe
{
    public class ShoeSize
    {
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public List<SpecificShoe> SpecificShoes { get; set; }

        public List<ShoeSizeSpecificShoe> ShoeSizeSpecificShoes { get; set; }
    }
}
