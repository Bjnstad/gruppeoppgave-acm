using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using oslomet_film.Models;

namespace DAL
{
    public class DB : DbContext
    {
        public DB() : base("name=ACM")
        {
            Database.CreateIfNotExists();
            //Database.SetInitializer(new DBInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Movie> Movie { get; set; }
    }
}
