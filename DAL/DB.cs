using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using oslomet_film.Model;

namespace oslomet_film.DAL
{
    public class DB : DbContext
    {
        public DB() : base("name=acm-film")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Category_Relation> Category_Relations { get; set; }
        public virtual DbSet<DBCustomer> Customers { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; } 
    }
}
