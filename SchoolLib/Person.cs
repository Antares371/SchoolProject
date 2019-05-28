using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person(string name, string surname)
        {
            if(string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));
            Name = name;

            if(string.IsNullOrEmpty(surname))
                throw new ArgumentException(nameof(surname));
            Surname = surname;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Surname);
        }
    }
}
