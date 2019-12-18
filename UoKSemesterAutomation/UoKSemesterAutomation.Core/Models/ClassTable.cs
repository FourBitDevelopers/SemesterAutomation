using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoKSemesterAutomation.Core.Models
{
    public class ClassTable : BaseEntity
    {
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string shift { get; set; }
        public string DepartmentID { get; set; }
       
    }
}
