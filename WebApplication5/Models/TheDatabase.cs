using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication5.Models
{
    public class TheDatabase
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}