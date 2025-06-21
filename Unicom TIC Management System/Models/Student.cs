using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicom_TIC_Management_System.Models
{
    public class Student
    {
        public int StudentID { get; set; }       
        public string Name { get; set; }       
        public int CourseID { get; set; }       
        public int NIC {  get; set; }
        public DateTime Dateofbirth  { get; set; }
        public string Guardian  { get; set; }
        public int PhoneNB { get; set; } 
        public string SpecificEDU { get; set; }
    }
}