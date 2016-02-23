using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime DeadLineDate { get; set; }
        public string Title { get; set; }
        public string Req { get; set; }
    }
}