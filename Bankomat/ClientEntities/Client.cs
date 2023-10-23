using Bankomat.AccountEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.ClientEntities
{
    public class Client
    {
        public string Password { get; set; }
        public Account Account { get; set; }

        public Client()
        {
            Password = GeneratePassword();
            Account = new Account("AccountNumberHere", 0);
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }

        private string GeneratePassword()
        {
            return "GeneratedPassword";
        }
    }
}
