using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public static class PersonInfo
    {
        public static string GetPersonInfo(Person person)
        {
            return $"Name: {person.Name}, Age: {person.Age}";
        }
    }
}
