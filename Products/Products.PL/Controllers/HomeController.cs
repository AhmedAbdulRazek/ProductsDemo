using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Products.BL.Interfaces;
using Products.BL.ViewModel;
using Products.PL.Models;
using System.Diagnostics;

namespace Products.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepo ProductRepo;
        private readonly ICategoryRepo CategoryRepo;
        public HomeController(IProductRepo ProductRepo, ICategoryRepo CategoryRepo)
        {
            this.ProductRepo = ProductRepo;
            this.CategoryRepo = CategoryRepo;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                SelectList Categories = new SelectList(CategoryRepo.GetAll(), "Id", "Name");

                ViewBag.Cat = Categories;


                var Products = ProductRepo.GetAllAfterDuration();
                return View(Products);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Index(int CatId)
        {
            try
            {
                SelectList Categories = new SelectList(CategoryRepo.GetAll(), "Id", "Name");
                ViewBag.Cat = Categories;
                var Products = ProductRepo.GetAllAfterDuration(); ;
                if (CatId !=0)
                {
                    Products = ProductRepo.GetProductsByCategoryID(CatId);
                }
                

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

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}