using Microsoft.AspNetCore.Mvc;
using Shopping_MVC.Models;
using System;

namespace Shopping_MVC.Controllers
{
    public class AdminController : Controller
    {
        DbDataContext Context = new DbDataContext();
        public IActionResult Login()
        {
            return View(new Admin());
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var existingUser = Context.admins.FirstOrDefault(u => u.Number == admin.Number && u.Passward == admin.Passward);
            if (existingUser != null)
            {

                return RedirectToAction("getProducts");
            }
            return View(admin);
        }

        public IActionResult getProducts()
        {
           
           var products = Context.products.ToList();
            
            return View(products);
        }


        public IActionResult Add()
        {
            return View();
        }
        public IActionResult AddActual(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product != null && !string.IsNullOrEmpty(product.Name))
                {
                    Context.products.Add(product);
                    Context.SaveChanges();
                    return RedirectToAction("getProducts");
                }
                return View(product);
            }

            return RedirectToAction("getProducts");
        }


        public IActionResult Edit(int id)
        {
            var product = Context.products.FirstOrDefault(s => s.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult EditActual(Product product)
        {
            if (ModelState.IsValid)
            {

                var existingProduct = Context.products.FirstOrDefault(s => s.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    Context.products.Update(existingProduct);
                    Context.SaveChanges();
                    return RedirectToAction("getProducts");
                }
            }
            return View(product);
        }

        public IActionResult Delete(int id)
            {
                if (ModelState.IsValid)
                {

                    var student = Context.products.FirstOrDefault(s => s.Id == id);
                    Context.products.Remove(student);
                    Context.SaveChanges();
                    return RedirectToAction("getProducts");
                }
                return Content("NotFound");
            }

    }

}

