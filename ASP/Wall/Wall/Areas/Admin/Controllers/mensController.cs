using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain;
using Wall.Domain.Entities;
using Wall.Models;

namespace Wall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class mensController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public mensController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public IActionResult all()
        {
            return View();
        }

        /*[Route("admin/mens/List")]
        [Route("admin/mens/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Product> products = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                products = dataManager.product.getProducts.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("tshirts", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = dataManager.product.getProducts.Where(i => i.categoryId == 2);
                    currCategory = "Футболки";
                }
                else if (string.Equals("hoods", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Кофти"));
                    currCategory = "Кофти";
                }
                else if (string.Equals("jacket", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Куртки"));
                    currCategory = "Куртки";
                }


            }
            var productObject = new ProductsListViewModel
            {
                getAllProducts = products,
                currCategory = currCategory
            };

            ViewBag.Title = "Page with products";

            return View(productObject);
        }*/

        public IActionResult tshirts()
        {
            return View(dataManager.product.getProducts.Where(i => i.categoryId == 1));
        }

        public IActionResult hoods()
        {
            return View(dataManager.product.getProducts.Where(i => i.categoryId == 2));
        }

        public IActionResult jackets()
        {
            return View(dataManager.product.getProducts.Where(i => i.categoryId == 3));
        }
    }
}
