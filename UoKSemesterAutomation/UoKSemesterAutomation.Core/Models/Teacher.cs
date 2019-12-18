using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoKSemesterAutomation.Core.Models
{
    public class Teacher : BaseEntity
    {
        [StringLength(40)]
        [DisplayName("Teacher Name")]
        public string Name { get; set; }
        [StringLength(40)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Department { get; set; }
        
        public int Contact { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Degree { get; set; }
        public bool IsChairPerson { get; set; }
        public string Teacher_Abb { get; set; }
        
       

    }
}
