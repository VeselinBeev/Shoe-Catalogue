using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.Models.Shoe;

namespace Web.Data.Config
{
    public class SpecificShoeConfig : IEntityTypeConfiguration<SpecificShoe>
    {
        public void Configure(EntityTypeBuilder<SpecificShoe> builder)
        {
            builder.ToTable(nameof(SpecificShoe));

            builder
                .HasOne(e => e.Category)
                .WithMany(p => p.Shoes);

          
        }
    }
}
