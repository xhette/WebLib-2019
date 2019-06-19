using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLib.Models
{
    public class AuthorModel
    {
            public int Id { get; set; }
            [Required (ErrorMessage = "Пожалуйста, заполните это поле")]
            public string Surname { get; set; }
            [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
            public string FirstName { get; set; }
            public string Patronymic { get; set; }
    
    }
}