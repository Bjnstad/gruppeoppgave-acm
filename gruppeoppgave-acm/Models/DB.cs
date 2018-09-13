using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace gruppeoppgave_acm.Models
{
    public class DB:DbContext
    {
        public DB() : base("name=ACM")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
    }
}