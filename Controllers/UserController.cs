using E_Comm.DAL;
using E_Comm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Comm.Controllers
{
    public class UserController : Controller
    {
        UsersDAL db = new UsersDAL();
        // GET: UserController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Users user)
        {
            try
            {
                int result = db.UsersRegister(user);
                if (result == 1)
                {
                    return RedirectToAction("Login", "User");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UsersLogin(Users user)
        {
            Users u = db.UsersLogin(user);
            if (u.u_Password == user.u_Password)
            {
                HttpContext.Session.SetString("username", u.u_emailid.ToString()); 
                HttpContext.Session.SetString("userid", u.userid.ToString());
                
                if (user.RoleId == Roles.Admin)
                {
                    return RedirectToAction("Index", "Product");
                }
               else
                {
                    return RedirectToAction("Products", "Product");
                }
                           
            }
            else
            {
                return View();
            }
            }

        }
    }
    











