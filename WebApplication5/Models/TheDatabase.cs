using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace WebApplication5.Models
{
    public class TheDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskX> Tasks { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}