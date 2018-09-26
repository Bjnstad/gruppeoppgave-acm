﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using oslomet_film.Models;

namespace oslomet_film.DAL
{
    public class DB : DbContext
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
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Category_Relation> Category_Relations { get; set; }
    }
}
