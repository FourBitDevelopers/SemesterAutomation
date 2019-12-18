using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoKSemesterAutomation.Core.Models
{
    public class Student : BaseEntity
    {
      

        [StringLength(40)]
        [DisplayName("Student Name")]
        public string Name { get; set; }
        [StringLength(40)]
        [DisplayName("Father Name")]
        public string FatherName { get; set; }
        public int SemesterNo { get; set; }
        public string Enrolment { get; set; }
        public string RollNumber { get; set; }
        public string Major { get; set; }
        public string Section { get; set; }
        
        public string Year { get; set; }
        public string Department { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Image { get; set; }
        public string Shift { get; set; }
        public bool IsRepeater { get; set; }



       
    }
}
