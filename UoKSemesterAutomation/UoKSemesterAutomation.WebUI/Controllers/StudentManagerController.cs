using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UoKSemesterAutomation.Core.Contracts;
using UoKSemesterAutomation.Core.Models;
using UoKSemesterAutomation.Core.ViewModel;
using UoKSemesterAutomation.DataAccess.InMemory;

namespace UoKSemesterAutomation.WebUI.Controllers
{
    public class StudentManagerController : Controller
    {
        //IRepository<Product> repository;
        //IRepository<ProductCategory> product_categories;
        IRepository<Student> studentContext;
        IRepository<Department> DepartmentContext;
        //StudentRepository studentContext;
        //DepartmentRepository DepartmentContext;

        //Initalize our products repository 
        public StudentManagerController(IRepository<Student> studentcontext,IRepository<Department> departmentcontext)
        {
            studentContext = studentcontext;
            DepartmentContext = departmentcontext;

        }

        // GET: ProductManager
        public ActionResult Index()
        {
            //Get all product list from repository and save in a list named as products
            List<Student> students = studentContext.Collection().ToList();
            return View(students);
        }

        //Takes Product info input from form
        public ActionResult Create()
        {
            StudentManagerViewModel SMViewModel = new StudentManagerViewModel();
            SMViewModel.student= new Student();
            SMViewModel.departments = DepartmentContext.Collection();
            return View(SMViewModel);
           
          
        }

        ////Check validation and add product in local memory
        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            else
            {
                //if (file != null)
                //{
                //    product.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//" + product.Image));
                //}
                studentContext.Insert(student);
                studentContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Student student = studentContext.Find(Id);
            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                StudentManagerViewModel SMViewModel = new StudentManagerViewModel();
                SMViewModel.student = student;
                SMViewModel.departments = DepartmentContext.Collection();
                return View(SMViewModel);
            }
        }
        //default template returnupdated product and id of the original product
        [HttpPost]
        public ActionResult Edit(Student student, string Id)
        {
            Student studentToUpdate = studentContext.Find(Id);
            if (studentToUpdate == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(student);
                }

                //if (file != null)
                //{
                //    producToUpdate.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//" + producToUpdate.Image));
                //}
                studentToUpdate.Department = student.Department;
                studentToUpdate.Email = student.Email;
                studentToUpdate.Enrolment = student.Enrolment;
                studentToUpdate.FatherName = student.FatherName;
                studentToUpdate.Image = student.Image;
                studentToUpdate.Major = student.Major;
                studentToUpdate.Name = student.Name;
                studentToUpdate.IsRepeater = student.IsRepeater;
                studentToUpdate.RollNumber = student.RollNumber;
                studentToUpdate.Section = student.Section;
                studentToUpdate.SemesterNo = student.SemesterNo;
                studentToUpdate.Shift = student.Shift;
                studentToUpdate.Year = student.Year;
              

                studentContext.Commit();
                return RedirectToAction("Index");
            }
        }

        ////Delete Product
        public ActionResult Delete(string Id)
        {
            Student studentToDelete = studentContext.Find(Id);

            if (studentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(studentToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Student studentToDelete = studentContext.Find(Id);

            if (studentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                studentContext.Delete(Id);
                studentContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}