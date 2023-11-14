using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7_FileJsonSerialise_Due14Nov
{
    internal record Student
    {
        public Student(string name, string surname, string code)
        {
            Name = name;
            Surname = surname;
            Code = code;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Code { get; set; }
    }
}
