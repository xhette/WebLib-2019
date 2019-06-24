using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class DeliveryModel
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public double Cost { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public int Amount { get; set; }

        public double Summ { get; set; }

        public int Shop { get; set; }
    }
}