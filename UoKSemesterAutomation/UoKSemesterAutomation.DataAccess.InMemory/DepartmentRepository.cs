using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using UoKSemesterAutomation.Core.Models;


namespace UoKSemesterAutomation.DataAccess.InMemory
{
    public class DepartmentRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Department> departments;

        public DepartmentRepository()
        {
            departments = cache["departments"] as List<Department>;
            if (departments == null)
            {
                departments = new List<Department>();
            }
        }

        //Save Product in to local memory
        public void Commit()
        {
            cache["departments"] = departments;

        }

        //Insert Product in a list
        public void Insert(Department department)
        {
            departments.Add(department);
        }

        //Update Product Information

        public void Update(Department department)
        {
            Department departmentToUpdate = departments.Find(c => c.Id == department.Id);

            if (departmentToUpdate != null)
            {
                departmentToUpdate = department;
            }
            else
            {
                throw new Exception("Department Not found");
            }

        }

        //Find Product
        public Department Find(string Id)
        {
            Department departmentToFind = departments.Find(c => c.Id == Id);
            if (departmentToFind != null)
            {
                return departmentToFind;
            }
            else
            {
                throw new Exception("Department Not Found");
            }

        }

        //Return List of Products
        public IQueryable<Department> Collection()
        {
            return departments.AsQueryable();
        }

        //Delete Product
        public void Delete(string Id)
        {
            Department departmentToDelete = departments.Find(c => c.Id == Id);
            if (departmentToDelete != null)
            {
                departments.Remove(departmentToDelete);
            }
            else
            {
                throw new Exception("Department not found");
            }
        }
    }
}
