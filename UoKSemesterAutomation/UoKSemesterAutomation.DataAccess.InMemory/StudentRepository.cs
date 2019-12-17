using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using UoKSemesterAutomation.Core.Models;

namespace UoKSemesterAutomation.DataAccess.InMemory
{
    public class StudentRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Student> students;

        public StudentRepository()
        {
            students = cache["students"] as List<Student>;
            if (students == null)
            {
                students = new List<Student>();
            }
        }

        //Save Product in to local memory
        public void Commit()
        {
            cache["students"] = students;

        }

        //Insert Product in a list
        public void Insert(Student student)
        {
            students.Add(student);
        }

        //Update Product Information

        public void Update(Student student)
        {
            Student studentToUpdate = students.Find(c => c.StudentId == student.StudentId);

            if (studentToUpdate != null)
            {
                studentToUpdate = student;
            }
            else
            {
                throw new Exception("Product Not found");
            }

        }

        //Find Product
        public Student Find(string Id)
        {
            Student StudentToFind = students.Find(c => c.StudentId== Id);
            if (StudentToFind != null)
            {
                return StudentToFind;
            }
            else
            {
                throw new Exception("Product Not Found");
            }

        }

        //Return List of Products
        public IQueryable<Student> Collection()
        {
            return students.AsQueryable();
        }

        //Delete Product
        public void Delete(string Id)
        {
            Student studentToDelete = students.Find(c => c.StudentId == Id);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
