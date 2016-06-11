using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ELibrary.Model.Entities;
using ELibrary.Data.Migrations;

namespace ELibrary.Data
{
    public class ELibraryEntities : DbContext
    {
        static ELibraryEntities()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ELibraryEntities, Configuration>());
        }
        public ELibraryEntities() : base("ELibraryDBConnection")
        {
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public System.Data.Entity.DbSet<Book> Books { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<Tag> Tags { get; set; }
    }
}
