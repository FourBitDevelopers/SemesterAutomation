using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoKSemesterAutomation.Core.Models;

namespace UoKSemesterAutomation.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Student> students { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<ClassTable> classtable { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Repeaters> repeaters { get; set; }
    
    }
}
