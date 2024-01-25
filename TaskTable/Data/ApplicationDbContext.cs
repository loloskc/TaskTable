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
            UploadDefaultData upseed = new UploadDefaultData(this);
            upseed.UploadStatusName();
        }
    }
}
