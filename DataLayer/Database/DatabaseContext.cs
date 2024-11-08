using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Database
{
     public class DatabaseContext:DbContext
    {
        public DbSet<DatabaseUser> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string databaseFile = "Welocme.db";
            string databasePath = Path.Combine(solutionFolder, databaseFile);
            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseUser>().Property(e =>e.Id).ValueGeneratedOnAdd();
            
            var user = new DatabaseUser()
            {
                Id = 1,
                Name = "Bat Vancho",
                Password = "password",
                Email = "example@mail.com",
                FacultyNumber = "123456789",
                Role = Welcome.Others.UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddYears(10),
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user);

            var user1 = new DatabaseUser()
            {
                Id = 2,
                Name = "Bat Yanko",
                Password = "password1",
                Email = "example1@mail.com",
                FacultyNumber = "123456788",
                Role = Welcome.Others.UserRolesEnum.STUDENT,
                Expires = DateTime.Now.AddYears(5),
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user1);

            var user2 = new DatabaseUser()
            {
                Id = 3,
                Name = "Bat Tseko",
                Password = "password2",
                Email = "example2@mail.com",
                FacultyNumber = "123456787",
                Role = Welcome.Others.UserRolesEnum.PROFESSOR,
                Expires = DateTime.Now.AddYears(3),
            };

            modelBuilder.Entity<DatabaseUser>()
                .HasData(user2);
        }
        
    }
}
