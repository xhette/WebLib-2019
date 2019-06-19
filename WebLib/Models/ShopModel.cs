using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class ShopModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string PhoneNumber { get; set; }
    }
}