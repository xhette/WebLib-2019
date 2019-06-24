using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebLib.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "Длина логина должна быть от 2 до 20 символов")]
        //[RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$",
        //    ErrorMessage = "Логин должен содержать буквы и цифры, первый символ обязательно буква")]
        public string Login { get; set; }

        //[StringLength(50, MinimumLength = 6, ErrorMessage = "Длина пароля должна быть от 6 до 50 символов")]
        //[RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$", 
        //    ErrorMessage = "Пароль должен содержать строчные и прописные латинские буквы, цифры")]
        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string Password { get; set; }

        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //public string ConfirmPassword { get; set; }

        public int Post { get; set; }
    }
}
