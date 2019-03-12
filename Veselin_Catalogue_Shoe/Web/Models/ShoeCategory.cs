using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ShoeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Shoe> Shoes { get; set; }
    }
}
