using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Data.Config;
using Web.Models;
using Web.Models.Shoe;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SpecificShoe> Shoe { get; set; }
        public DbSet<ShoeCategory> ShoeCategory { get; set; }
        public DbSet<ShoeColor> ShoeColor { get; set; }
        public DbSet<ShoeSizeSpecificShoe> ShoeSizeSpecificShoe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new SpecificShoeConfig());
            builder.ApplyConfiguration(new ShoeCategoryConfig());
            builder.ApplyConfiguration(new ShoeColorConfig());
            builder.ApplyConfiguration(new ShoeSizeSpecificShoeConfig());
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Web.Models.Shoe.ShoeSize> ShoeSize { get; set; }

    }
}
