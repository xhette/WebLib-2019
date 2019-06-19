using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class SupplyModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public int Quanity { get; set; }
    }
}