using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain;

namespace Wall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class womansController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public womansController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }

        public ViewResult all()
        {
            return View();
        }

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
