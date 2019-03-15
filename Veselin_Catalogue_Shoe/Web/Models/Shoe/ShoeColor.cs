using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Shoe
{
    public class ShoeColor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SpecificShoe> SpecificShoes { get; set; }
    }
}
