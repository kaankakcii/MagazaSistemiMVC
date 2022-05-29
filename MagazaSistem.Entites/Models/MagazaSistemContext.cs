using MagazaSistem.Entites.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class MagazaSistemContext : DbContext
    {
        public MagazaSistemContext() : base("MagazaSistem")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubcategoryMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new ColorMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new AuthorityMap());
            modelBuilder.Configurations.Add(new PersonnelMap());
            modelBuilder.Configurations.Add(new InvoiceMap());
            modelBuilder.Configurations.Add(new InvoiceAndProductMap());


        }


        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Authority> Authority { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceAndProduct> InvoiceAndProduct { get; set; }
    }

}

