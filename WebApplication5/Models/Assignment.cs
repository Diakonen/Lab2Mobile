using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication5.Models
{
    public class Assignment
    {
        [Key]
        [Column(Order = 0)]
        public int TaskID { get; set; }
        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }

        public string Comment { get; set; }

        public DateTime time { get; set; }
    }
}