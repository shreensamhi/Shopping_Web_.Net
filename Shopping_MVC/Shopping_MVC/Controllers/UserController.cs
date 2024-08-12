using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_MVC.Models;
using System;
using System.Linq;

namespace Shopping_MVC.Controllers
{
    public class UserController : Controller
    {
        DbDataContext Context = new DbDataContext();

        public IActionResult getProducts()
        {

            var products = Context.products.ToList();

            return View(products);
        }

        public IActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
           
            var existingUser = Context.users.FirstOrDefault(u => u.Number == user.Number && u.Passward == user.Passward);
            if (existingUser != null)
            {
                
                return RedirectToAction("getProducts");
            }

          
            return View(user);
        }


        public IActionResult Signin()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Signin(User user)
        {

            if (ModelState.IsValid)
            {
                if (user != null && !string.IsNullOrEmpty(user.Name))
                {
                    Context.users.Add(user);
                    Context.SaveChanges();
                    return RedirectToAction("getProducts");
                }
                return View(user);
            }
            return View (user);
      
        }
    }
    }


