using POS_DBProj.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace POS_DBProj.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<POS_Categories> POS_Categories { get; set; }
        public DbSet<POS_Leads> POS_Leads { get; set; }
        public DbSet<POS_ModuleRoles> POS_ModuleRoles { get; set; }
        public DbSet<POS_Modules> POS_Modules { get; set; }
        public DbSet<POS_Pricing> POS_Pricing { get; set; }
        public DbSet<POS_Products> POS_Products { get; set; }
        public DbSet<POS_Roles> POS_Roles { get; set; }
        public DbSet<POS_TransactionDetails> POS_TransactionDetails { get; set; }
        public DbSet<POS_TransactionHeader> POS_TransactionHeader { get; set; }
        public DbSet<POS_UserRoles> POS_UserRoles { get; set; }
        public DbSet<POS_Users> POS_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure decimal precision and scale
            modelBuilder.Entity<POS_Pricing>()
                .Property(p => p.ProductPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<POS_TransactionHeader>()
                .Property(t => t.PriceBeforeTax)
                .HasPrecision(18, 2);

            modelBuilder.Entity<POS_TransactionHeader>()
                .Property(t => t.AmountTendered)
                .HasPrecision(18, 2);

            modelBuilder.Entity<POS_TransactionHeader>()
                .Property(t => t.VatAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<POS_TransactionHeader>()
                .Property(t => t.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<POS_TransactionDetails>()
               .Property(d => d.ProductPrice)
               .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
