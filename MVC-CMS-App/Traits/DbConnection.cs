using Microsoft.EntityFrameworkCore;
using MVC_CMS_App.Models;

namespace MVC_CMS_App.Traits
{
    public partial class DbConnection : DbContext
    {
        public DbConnection(){}

        public DbConnection(DbContextOptions<DbConnection> options)
            : base(options)
        {
        }

        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Doctors> Doctors { get; set; }
        public virtual DbSet<Nurses> Nurses { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password='';database=hospital_db;convert zero datetime=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){}
    }
}
