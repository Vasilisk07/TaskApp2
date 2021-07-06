using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskApp2.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("DefaultConnection")
        { }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<ActualTaskModel> ActualModels { get; set; }


    }
}