using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Reflection;
using oslomet_film.Model;

namespace oslomet_film.DAL
{
    public class DB : DbContext
    {
        private static readonly string LOG_DATABASE_FILE_PATH = "database.txt";
        private string path;

        public DB() : base("name=acm-film")
        {
            //Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
            LoadFile();
            this.Database.Log = str => LogRequets(str);
        }

        private void LoadFile()
        {
            path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), LOG_DATABASE_FILE_PATH);
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
            }
        }

        private void LogRequets(string str)
        {
            StreamWriter sw = File.AppendText(path);
            sw.Write("\r\nLog Entry : ");
            sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            sw.WriteLine("  :");
            sw.WriteLine("  :{0}", str);
            sw.WriteLine("-------------------------------");
            sw.Close();
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
