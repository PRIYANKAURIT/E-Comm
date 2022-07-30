using E_Comm.DAL;
using E_Comm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace E_Comm.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL db = new ProductDAL();
        CartDAL cdb = new CartDAL();
        OrderDAL ddb = new OrderDAL();
        public IActionResult Index()
        {
            var model = db.GetAllProducts();
            return View(model);
        }
        public IActionResult Products()
        {
            var model = db.GetAllProducts();
            return View(model);
        }


        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {

            try
            {
                int result = db.AddProduct(product);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                int result = db.UpdateProduct(product);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetProductById(id);
            return View(model);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = db.DeleteProduct(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    
    public IActionResult AddToCart(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Cart cart = new Cart();
            cart.p_Id = id;
            cart.userid = Convert.ToInt32(userid);
            cart.c_id = id;
            int res = cdb.AddToCart(cart);
            if (res == 1)
            {
                return RedirectToAction("ViewToCart");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ViewToCart()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = cdb.ViewProductsFromCart(userid);
            return View(model);
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int cid)
        {
            int res = cdb.RemoveFromCart(cid);
            if (res == 1)
            {
                return RedirectToAction("ViewToCart");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult ViewOrder()
        {
            string userid = HttpContext.Session.GetString("userid");
            var model = ddb.ViewOrder(userid);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddOrder(int id)
        {
            string userid = HttpContext.Session.GetString("userid");
            Order order = new Order();
            order.p_Id = id;
            order.userid = Convert.ToInt32(userid);
            order.o_id = id;
            order.Price = Convert.ToInt32(order.Price);
            order.quantity=Convert.ToInt32(order.quantity);
            int res = ddb.AddOrder(order);
            if (res == 1)
            {
                return RedirectToAction("ViewOrder");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult DeleteOrder(int cid)
        {
            int res = ddb.DeleteOrder(cid);
            if (res == 1)
            {
                return RedirectToAction("ViewOrder");
            }
            else
            {
                return View();
            }
        }
    }
}
