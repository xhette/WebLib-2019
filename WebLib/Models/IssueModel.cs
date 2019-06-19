using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class IssueModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime OccupiedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public bool IsReturned { get; set; }
    }
}