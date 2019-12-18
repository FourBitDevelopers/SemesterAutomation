using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoKSemesterAutomation.Core.Models
{
    public class Repeaters : BaseEntity
    {
        public string StudentId { set; get; }
        public string ClassTableId { set; get; }
        public string TeacherId { set; get; }
        public string Department { set; get; }

    }
}
