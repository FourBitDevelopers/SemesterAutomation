using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoKSemesterAutomation.Core.Models;

namespace UoKSemesterAutomation.Core.ViewModel
{
    public class StudentManagerViewModel
    {
        public Student student { get; set; }
        public IEnumerable<Department> departments { get; set; }
    }
}
