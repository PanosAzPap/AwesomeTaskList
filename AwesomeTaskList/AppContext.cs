using AwesomeTaskList.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AwesomeTaskList
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=AppContext")
        {

        }

        public DbSet<Task> Tasks { get; set; }

        //fluentapi
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .ToTable("Tasks")
                .HasKey(i => i.Id);
        }
    }
}