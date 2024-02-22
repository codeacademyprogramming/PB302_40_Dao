using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int GroupId { get; set; }
        public byte Point { get; set; }
    }
}
