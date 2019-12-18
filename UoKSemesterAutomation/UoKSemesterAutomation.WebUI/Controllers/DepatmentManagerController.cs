using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UoKSemesterAutomation.Core.Models;
using UoKSemesterAutomation.DataAccess.InMemory;

namespace UoKSemesterAutomation.WebUI.Controllers
{
    public class DepatmentManagerController : Controller
    {
        // IRepository<Product> repository;
        //IRepository<ProductCategory> product_categories;
        InMemoryRepository<Department> DepartmentContext;

        //Initalize our products repository 
        public DepatmentManagerController()
        {
            DepartmentContext = new InMemoryRepository<Department>();

        }

        // GET: ProductManager
        public ActionResult Index()
        {
            //Get all product list from repository and save in a list named as products
            List<Department> departments = DepartmentContext.Collection().ToList();
            return View(departments);
        }

        //Takes Product info input from form
        public ActionResult Create()
        {
            //ProductManagerViewModel PMViewModel = new ProductManagerViewModel();
            //PMViewModel.Product = new Product();
            //PMViewModel.ProductCategories = product_categories.Collection();
            //return View(PMViewModel);
            Department department = new Department();
            return View(department);
        }

        ////Check validation and add product in local memory
        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }
            else
            {
                //if (file != null)
                //{
                //    product.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//" + product.Image));
                //}
                DepartmentContext.Insert(department);
                DepartmentContext.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Department department = DepartmentContext.Find(Id);
            if (department == null)
            {
                return HttpNotFound();
            }
            else
            {
                //ProductManagerViewModel PMViewModel = new ProductManagerViewModel();
                //PMViewModel.Product = product;
                //PMViewModel.ProductCategories = product_categories.Collection();
                //return View(PMViewModel);
                return View(department);
            }
        }
        //default template returnupdated product and id of the original product
        [HttpPost]
        public ActionResult Edit(Department department, string Id)
        {
            Department DepartmentToUpdate = DepartmentContext.Find(Id);
            if (DepartmentToUpdate == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(department);
                }

                //if (file != null)
                //{
                //    producToUpdate.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages//" + producToUpdate.Image));
                //}
                DepartmentToUpdate.DepartmentName = department.DepartmentName;
              

                DepartmentContext.Commit();
                return RedirectToAction("Index");
            }
        }

        ////Delete Product
        public ActionResult Delete(string Id)
        {
            Department DepartmentToDelete = DepartmentContext.Find(Id);

            if (DepartmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(DepartmentToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {

            Department DepartmentToDelete = DepartmentContext.Find(Id);

            if (DepartmentToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                DepartmentContext.Delete(Id);
                DepartmentContext.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}