using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMarket.Entities
{
    internal class Client
    {
        string? _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("The name can't be empty.");
                }
                _name = value;
            }
        }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client(string? name, string email, DateTime birthDate)
        {
            _name = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
