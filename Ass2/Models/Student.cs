using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass2.Models
{
    public class Student
    {
        public int? StudentID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<string> Hobbies { get; set; }
    }
}
