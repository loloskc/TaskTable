using TaskTable.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTable.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MyTask> MyTasks  { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Создана" },
                new Status { StatusId = 2, StatusName = "В работе" },
                new Status { StatusId = 3, StatusName = "Завершена" }
                );
        }
    }
}
