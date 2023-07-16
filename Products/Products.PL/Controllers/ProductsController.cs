using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Products.BL.Interfaces;
using Products.BL.ViewModel;

namespace Products.PL.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductRepo ProductRepo;
        private readonly ICategoryRepo CategoryRepo;
        public ProductsController(IProductRepo ProductRepo , ICategoryRepo CategoryRepo)
        {
            this.ProductRepo = ProductRepo;
            this.CategoryRepo = CategoryRepo;
        }
        public IActionResult Index()
        {
            try
            {
                var Products = ProductRepo.GetAll();
                return View(Products);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                var Product = ProductRepo.GetById(id);
                return View(Product);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoriesList = new SelectList(CategoryRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductVM Product)
        {
            
            try
            {
                ViewBag.CategoriesList = new SelectList(CategoryRepo.GetAll(), "Id", "Name");

                if (ModelState.IsValid)
                {
                    ProductRepo.Create(Product);
                    return RedirectToAction("Index");
                }
                return View(Product);
            }
            catch (Exception)
            {
                return View(Product);
            }
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.CategoriesList = new SelectList(CategoryRepo.GetAll(), "Id", "Name");
            var Product = ProductRepo.GetById(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult Edit(ProductVM Product)
        {
            try
            {
                ViewBag.CategoriesList = new SelectList(CategoryRepo.GetAll(), "Id", "Name");
                if (ModelState.IsValid)
                {
                    ProductRepo.Edit(Product);
                    return RedirectToAction("Index");
                }
                return View(Product);
            }
            catch (Exception)
            {
                return View(Product);
            }

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Product = ProductRepo.GetById(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult Delete(ProductVM Product)
        {
            try
            {
                ProductRepo.Delete(Product.Id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(Product);
            }
        }





    }
}
