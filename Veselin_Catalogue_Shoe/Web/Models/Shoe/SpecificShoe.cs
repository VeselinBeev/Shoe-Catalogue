using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Shoe
{
    public class SpecificShoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public ShoeCategory Category { get; set; }
        public bool Stock { get; set; }
        public ShoeColor Color { get; set; }

        public List<ShoeSizeSpecificShoe> ShoeSizeSpecificShoes { get; set; }

    }
}
