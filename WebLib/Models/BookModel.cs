using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string Title { get; set; }
        public int DepartmentId { get; set; }
    }
}