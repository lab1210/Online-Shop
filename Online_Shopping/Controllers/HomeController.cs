using Online_Shopping.IService;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using Online_Shopping.Service;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace Online_Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryService categoryService;
        private readonly ProductService productService;
        private readonly CartService cartService;

        private readonly ShoppingContext context;


        public HomeController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
            cartService = new CartService();
            context = new ShoppingContext();
        }
        public ActionResult Index(int? page)
        {

            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            var count = cartService.GetItemCount(username);
            ViewBag.count = count;
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            var Product = productService.GetAllProducts();

            if (TempData.ContainsKey("notfound"))
            {
                ViewBag.Message = TempData["notfound"];
            }

            int pagesize = 6;
            int totalProducts = Product.Count();
            int totalPages = (int)Math.Ceiling((double)totalProducts / pagesize);

            int currentPage = page ?? 1;
            currentPage = Math.Max(1, Math.Min(currentPage, totalPages));

            Product = Product.Skip((currentPage - 1) * pagesize).Take(pagesize);
            ViewBag.product = Product;
            ViewBag.TotalPages = totalPages;
            ViewBag.CurrentPage = currentPage;
            return View();
        }
        public ActionResult Search(string searchname)
        {
            IEnumerable<ProductResource> product;
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            var count = cartService.GetItemCount(username);
            ViewBag.count = count;
            if (!string.IsNullOrEmpty(searchname))
            {
                product = productService.ProductSearch(searchname);
                if (product.Any())
                {
                    return View(product);
                }
                else
                {
                    TempData["notfound"] = "Your Search '" + searchname + "'" + " does not match any record";
                }
            }

            return RedirectToAction("Index");

        }

        public ActionResult ProductsByCategory(int categoryId)
        {

            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            var products = categoryService.GetproductbyCategory(categoryId);
            ViewBag.product = products;
            return View("Index");
        }
        [HttpGet]
        public ActionResult ProductsByPrice(decimal? minprice, decimal? maxprice)
        {
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            var count = cartService.GetItemCount(username);
            ViewBag.count = count;
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            var productsprice = productService.GetAllProducts();
            if ((minprice != 0 && maxprice != 0) && (minprice < maxprice) && (maxprice > minprice))
            {
                productsprice = productsprice.Where(c => c.price >= minprice.Value && c.price <= maxprice.Value).ToList();
            }

            ViewBag.product = productsprice;
            return View("Index");
        }



        public ActionResult Item_Details(string slug, int categoryid)
        {

            if (TempData.ContainsKey("success"))
            {
                ViewBag.Message = TempData["success"];
            }
            if (TempData.ContainsKey("error"))
            {
                ViewBag.Error = TempData["error"];
            }
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            var count = cartService.GetItemCount(username);
            ViewBag.count = count;
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            var products = categoryService.GetproductbyCategory(categoryid);
            ViewBag.products = products;
            ProductResource product = productService.GetProductBySlug(slug);
            var relatedProducts = productService.GetRelatedProductsByCategory(product.CategoryID);
            ViewBag.Product = relatedProducts;
            var productReport = context.productReports.FirstOrDefault(r => r.slug == slug);
            ViewBag.InStockQuantity = productReport?.InStockQuantity ?? 0;

            return View(product);
        }
        [HttpPost]
        public ActionResult AddToCart(string slug, int quantity)
        {

            var product = productService.GetProductBySlug(slug);
            var existingitem = context.SalesCart.FirstOrDefault(r => r.slug == slug);

            if (product != null)
            {
                var username = HttpContext.Session["Name"] as string;
                if (existingitem == null)
                {
                    var cartItem = new Cart
                    {
                        slug = product.slug,
                        UserName = username,
                        Name = product.Name,
                        Price = product.Discount_Price * quantity ?? product.price * quantity,
                        ImagePath = product.imagepath,
                        Quantity = quantity,



                    };

                    cartService.AddToCart(cartItem);
                }
                else
                {
                    existingitem.Quantity += quantity;
                    existingitem.Total = existingitem.Price * existingitem.Quantity;
                    context.SaveChanges();
                }
                TempData["success"] = product.Name + " has been added to your cart";

                return RedirectToAction("Item_Details", new { slug = product.slug, categoryid = product.CategoryID });
            }
            TempData["error"] = product.Name + " couldn't been added to your cart";
            return RedirectToAction("Item_Details", new { slug = product.slug, categoryid = product.CategoryID });

        }



        public ActionResult ShoppingCart()
        {

            if (TempData.ContainsKey("deleted"))
            {
                ViewBag.Message = TempData["deleted"];
            }
            if (TempData.ContainsKey("success"))
            {
                ViewBag.Message = TempData["success"];
            }
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            productService.GetAllProducts();
            var user = HttpContext.Session["Name"] as string;
            ViewBag.Username = user;
            var username = HttpContext.Session["Name"] as string;
            var list = cartService.GetCartItems(username);
            var count = cartService.GetItemCount(user);
            ViewBag.count = count;
            ViewBag.Sum = cartService.GetTotal(user);
            return View(list);
        }
        [HttpGet]
        public ActionResult DeleteFromCart(int id)
        {
            cartService.DeleteItemFromCart(id);
            TempData["deleted"] = "Item has been removed from cart";

            return RedirectToAction("ShoppingCart");
        }
        [HttpGet]
        public ActionResult AddToSales()
        {
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            productService.GetAllProducts();
            var user = HttpContext.Session["Name"] as string;
            ViewBag.Username = user;
            var count = cartService.GetItemCount(user);
            ViewBag.count = count;
            var cartitem = cartService.GetCartByUser(user);
            var sales = cartitem.Select(cart => new Sale
            {
                Id = cart.Id,
                Name = cart.Name,
                Price = cart.Total,
                user = user,
                Quantity = cart.Quantity,


            }).ToList();
            var saleinfo = new SalesInfo()
            {

                Sale = sales,


            };
            cartService.MakeSales(sales);
            return View("Buy", saleinfo);
        }

        public ActionResult Buy()
        {
            var category = categoryService.GetCategory();
            ViewBag.Category = category;
            productService.GetAllProducts();
            var user = HttpContext.Session["Name"] as string;
            ViewBag.Username = user;
            var count = cartService.GetItemCount(user);
            ViewBag.count = count;
            ViewBag.Sum = cartService.GetTotal(user);


            return View(new SalesInfo());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(SalesInfo Saleinfo)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.Session["Name"] as string;
                Saleinfo.user = user;
                cartService.AddSales(Saleinfo);
                cartService.DeleteItemFromCartaftersale(user);
                TempData["success"] = " Item will be delivered to you shortly";
                return RedirectToAction("ShoppingCart");

            }
            return View();
        }





    }
}