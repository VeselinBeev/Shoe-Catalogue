using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Shoe
{
    public class ShoeSizeSpecificShoe
    {
        public int ShoeSizeId { get; set; }
        public ShoeSize ShoeSize { get; set; }
        public int SpecificShoeId { get; set; }
        public SpecificShoe SpecificShoe { get; set; }


    }
}
