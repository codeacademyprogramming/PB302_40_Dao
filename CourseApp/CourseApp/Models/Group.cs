using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    internal class Group
    {
        public Group()
        {
            
        }
        public Group(int id,string no,byte limit)
        {
            Id = id;
            No = no;
            Limit = limit;
        }
        public int Id { get; set; }
        public string No { get; set; }
        public byte Limit { get; set; }
        public int StudentsCount { get; set; }

        public override string ToString()
        {
            return Id+"-"+No+"-"+Limit;
        }
    }
}
