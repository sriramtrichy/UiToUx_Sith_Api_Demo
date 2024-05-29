using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UitoUx.Domain.Models
{
    public class Register
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string MiddelName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
        public DateTime RegisterDateAndTime { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Register()
        {
            RegisterDateAndTime = DateTime.Now;
        }
    }
}
