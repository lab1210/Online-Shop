using Microsoft.Ajax.Utilities;
using Microsoft.Win32;
using Online_Shopping.IService;
using Online_Shopping.Models;
using Online_Shopping.Resources;
using Online_Shopping.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Online_Shopping.Controllers
{
    public class AdminController : Controller
    {
        private readonly CategoryService _categoryService;
        private readonly SupplierService supplierService;

        private readonly ProductService productService;
        private readonly PurchaseService purchaseService;
        private readonly RegisterService registerService;
        private readonly LoginService loginService;
        private readonly CartService cartService;
        private readonly ShoppingContext context;

        private readonly EmailService _emailService;

      /*  public AdminController(EmailService emailservice)
        {
            _emailService=emailservice;
        }*/



       

        public AdminController()
        {
           /* _emailService = new EmailService();*/
            _categoryService = new CategoryService();
            supplierService = new SupplierService();
            productService = new ProductService();
            purchaseService = new PurchaseService();
            registerService = new RegisterService();
            loginService = new LoginService();
            cartService = new CartService();
            context = new ShoppingContext();
        }
        // Dashboard
        public ActionResult DashBoard()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }
            if (TempData.ContainsKey("error"))
            {
                ViewBag.error = TempData["error"];
            }
            if (TempData.ContainsKey("err"))
            {
                ViewBag.err = TempData["err"];
            }

            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            IEnumerable<Category> category = _categoryService.GetAllCategories();
            ViewBag.categories = new SelectList(category, "Id", "Name");
            IEnumerable<Supplier> supplier = supplierService.GetSuppliers();
            ViewBag.supplier = new SelectList(supplier, "Id", "Name");
            ViewBag.highpurchasecount = cartService.GetHighPurchaseCount();
            ViewBag.lowpurchasecount = cartService.GetLowPurchaseCount();
            ViewBag.sales = cartService.GetSalesCount();

            ViewBag.purchase = cartService.GetPurchaseCount();
            ViewBag.outofstock = cartService.GetOutOfStockCount();
            ViewBag.salesum = cartService.GetSalesSum();

            ViewBag.purchsum = cartService.GetPurchaseSum();





            return View();
        }



        // Category
        [HttpGet]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _categoryService.AddCategory(category);
                    TempData["message"] = category.Name + " has been added";
                    return RedirectToAction("DashBoard", "Admin");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("DashBoard", "Admin");

                }

            }

            return View(category);
        }

        public ActionResult CategoryList()
        {
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            IEnumerable<Category> category = _categoryService.GetAllCategories();
            ViewBag.categories = new SelectList(category, "Id", "Name");
            IEnumerable<Supplier> supplier = supplierService.GetSuppliers();
            ViewBag.supplier = new SelectList(supplier, "Id", "Name");
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpGet]
        public ActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("CategoryList");
        }


        // Product

        [HttpPost]
        public ActionResult AddProduct(ProductResource productResource)
        {
            if (ModelState.IsValid)
            {
                string filepath = " ";

                if (productResource.image != null && productResource.image.ContentLength > 0)
                {
                    // Save the uploaded image to the server
                    var filename = Path.GetFileName(productResource.image.FileName);
                    var path = Path.Combine(Server.MapPath("~/ProductUploads"), filename);
                    productResource.image.SaveAs(path);
                    filepath = "/ProductUploads/" + filename;
                }


                var newProduct = new Product
                {
                    Name = productResource.Name,
                    imagepath = filepath,
                    CategoryID = productResource.CategoryID,
                    SupplierID = productResource.SupplierID,
                    SKU = productResource.SKU,
                    Slug = productResource.slug,
                    price = productResource.price,
                    Discount_Price = productResource.Discount_Price,
                };

                productService.SaveProduct(newProduct);

                TempData["message"] = productResource.Name + " has been added";
                return RedirectToAction("DashBoard", "Admin");
            }

            TempData["error"] = "Error encountered";
            return RedirectToAction("DashBoard", "Admin");

        }


        public ActionResult EditProduct(string slug)
        {
            IEnumerable<Category> category = _categoryService.GetAllCategories();
            ViewBag.categories = new SelectList(category, "Id", "Name");
            IEnumerable<Supplier> supplier = supplierService.GetSuppliers();
            ViewBag.supplier = new SelectList(supplier, "Id", "Name");
            ProductResource edit = productService.GetProductBySlug(slug);
            return View(edit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ProductResource productResource)
        {
            if (ModelState.IsValid)
            {
                string filepath = " ";

                if (productResource.image != null && productResource.image.ContentLength > 0)
                {
                    // Save the uploaded image to the server
                    var filename = Path.GetFileName(productResource.image.FileName);
                    var path = Path.Combine(Server.MapPath("~/ProductUploads"), filename);
                    productResource.image.SaveAs(path);
                    filepath = "/ProductUploads/" + filename;
                }
                productResource.imagepath = filepath;
                productService.UpdateProduct(productResource);
                return RedirectToAction("ProductList", "Admin");

            }
            return RedirectToAction("ProductList", "Admin");

        }

        public ActionResult ProductList()
        {
            var list = productService.GetAllProducts();
            return View(list);
        }
        [HttpGet]
        public ActionResult DeleteProduct(string slug)
        {
            productService.DeleteProduct(slug);
            return RedirectToAction("ProductList", "Admin");
        }



        // Supplier

        [HttpGet]
        public ActionResult AddSupplier(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    supplierService.AddSupplier(supplier);
                    TempData["message"] = supplier.Name + " has been added";
                    return RedirectToAction("DashBoard", "Admin");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("DashBoard", "Admin");

                }

            }

            return View(supplier);
        }


        public ActionResult SupplierList()
        {
            var list = supplierService.GetSuppliers();
            return View(list);

        }
        public ActionResult EditSupplier(int id)
        {
            Supplier supplier = supplierService.GetSupplierByID(id);
            return View(supplier);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSupplier(Supplier Supplier)
        {
            if (ModelState.IsValid)
            {
                supplierService.UpdateSupplier(Supplier);
                return RedirectToAction("SupplierList", "Admin");
            }
            return View(Supplier);
        }
        [HttpGet]
        public ActionResult DeleteSupplier(int id)
        {
            supplierService.DeleteSupplier(id);
            return RedirectToAction("SupplierList");
        }



        // Inventory

        public ActionResult Inventory()
        {
            var list = productService.GetInventory();

            return View(list);
        }

        // Admin

        public ActionResult CreateAdmin()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(Register register)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    register.Role = "Admin";
                    registerService.SaveUser(register);
                    TempData["message"] = register.LastName + " " + register.FirstName + " has been made an Admin";

                    return RedirectToAction("DashBoard", "Admin");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }


        public ActionResult AdminList()
        {
            return View(registerService.AdminList());
        }
        public ActionResult DriverList()
        {
            return View(registerService.DriverList());
        }
       


        // Purchase

        public ActionResult MakePurchase()
        {
            var suppliers = purchaseService.GetSupplier();
            ViewBag.Supplier = suppliers;
            var details = purchaseService.GetProducts();
            return View(details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MakePurchase(PurchaseResource purchase)
        {
            var username = HttpContext.Session["Name"] as string;
            purchase.Created_By = username;
            try
            {
                var result = purchaseService.AddPurchase(purchase);
                if (result)
                {
                    TempData["message"] = " Purchase Successful";

                    return RedirectToAction("DashBoard", "Admin");
                }
                else

                    return View();
            }
            catch
            {
                TempData["error"] = "Error encountered";

                return RedirectToAction("DashBoard", "Admin");

            }
        }

        public ActionResult PurchaseList()
        {
            var list = purchaseService.GetAllPurchases();
            return View(list);
        }
        public ActionResult PurchasedProducts(int id)
        {

            PurchaseResource purchase = purchaseService.GetPurchaseByID(id);
            return View(purchase);
        }
        
        public ActionResult Outofstock()
        {
            productService.GetAllProducts();

            var list = productService.Stock();
            return View(list);
        }


        // Sales


        public ActionResult SalesReport()
        {

            return View(cartService.getverifiedsales());
        }
        public ActionResult LowPurchase()
        {

            return View(cartService.getLowsales());
        }
        public ActionResult Highlypurchased()
        {

            return View(cartService.getHighSales());
        }

        public ActionResult AddCourier()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCourier(Register register)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    register.Role = "Driver";
                    registerService.SaveUser(register);
                    TempData["message"] = register.LastName + " " + register.FirstName + " has been made a Driver";

                    return RedirectToAction("DashBoard", "Admin");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View();
        }

        public ActionResult ChooseClient()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;

            return View(cartService.getsale());
        }
        [HttpGet]
        public ActionResult AssignToDriver(int id)
        {
            try
            {
                var sales = cartService.GetSale(id);
                var username = HttpContext.Session["Name"] as string;
                var salesitem = new OnRoute
                {
                    SaleCode = sales.Id,
                    Driver = username,
                    name = sales.user,
                    Address = sales.Address,
                    SaleDate = DateTime.Now,


                };

                cartService.AddTodriverList(salesitem);
                /*var drivermail = HttpContext.Session["mail"] as string;
                _emailService.SendConfirmationEmail(drivermail, sales.user);*/
                TempData["message"] = "Added";
                return RedirectToAction("VerifySales");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;

            }
            return RedirectToAction("ChooseClient");


        }
        public ActionResult VerifySales()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.Message = TempData["message"];
            }
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;
            var list = context.onRoutes.Where(c => c.Driver == username);
            return View(list);

        }
        [HttpGet]
        public ActionResult Verify(int id)
        {
            var sales = cartService.Getroute(id);
            var username = HttpContext.Session["Name"] as string;
            var salesitem = new VerifiedSale
            {
                SaleCode = sales.SaleCode,
                SaleDate = sales.SaleDate,
                Driver = username,
                name = sales.name,
                Address = sales.Address

            };
            cartService.CompleteSales(salesitem);
            cartService.Deletefromroute(id);
            TempData["message"] = "Successful";

            return RedirectToAction("VerifySales");

        }
        public ActionResult DeliveryAbort(int id)
        {
            var username = HttpContext.Session["Name"] as string;
            ViewBag.Username = username;

            cartService.Getroute(id);


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult DeliveryAbort(int id,AbortedDeleveries aborted)
        {
            var remove=cartService.Getroute(id);
            var username = HttpContext.Session["Name"] as string;
            aborted.name= username;
            aborted.Address = remove.Address;
            aborted.SaleDate=remove.SaleDate;
            aborted.Customer = remove.name;
            cartService.Deletefromroute(remove.id);
            cartService.AbortDelivery(aborted);
            TempData["message"] = "Client has been removed";

            return RedirectToAction("VerifySales");

        }
        public ActionResult DeliveryStatus()
        {
            ViewBag.Complete = cartService.verifiedSales().ToList();
            ViewBag.Cancelled=cartService.GetAbortedDeleveries().ToList(); 

            return View();
        }
    }
}