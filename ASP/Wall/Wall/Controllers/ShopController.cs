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

namespace Wall.Controllers
{
    public class ShopController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public ShopController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public ViewResult All()
        {
            return View();
        }

        [Route("Shop/Products")]
        [Route("Shop/ProductsforMen/{category?}")]
        public IActionResult ProductsforMen(string category)
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
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Футболки") || ((i.sex == "Ч") && (i.sex == "У"))); 
                    currCategory = "Футболки";
                }
                else if(string.Equals("hoods", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Кофти") || ((i.sex == "Ч") && (i.sex == "У")));
                    currCategory = "Кофти";
                }
                else if (string.Equals("jacket", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Куртки") || ((i.sex == "Ч") && (i.sex == "У")));
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
        }

        [Route("Shop/ProductsforWoman/{category?}")]
        public IActionResult ProductsforWoman(string category)
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
                    products = dataManager.product.getProducts.Where(i => i.category.categoryName.Equals("Футболки"));
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
        }

        public ViewResult Show(Guid id)
        {
            return View(dataManager.product.GetProductsbyId(id));
        }
    }
}
