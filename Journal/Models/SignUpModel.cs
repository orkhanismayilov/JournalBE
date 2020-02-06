using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JournalProject.Models
{
    public class SignUpModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Token { get; set; }
    }
}