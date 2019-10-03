using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [Required(ErrorMessage = "Пожалуйста, заполните это поле")]
        public string PhoneNumber { get; set; }

        public int UserId { get; set; }

        public string ConcatName
        {
            get
            {
                return String.Format("{0} {1} {2}", Surname, FirstName, Patronymic);
            }
        }
    }
}
