using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wall.Domain;
using Wall.Domain.Entities;
using Wall.Service;

namespace Wall.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostEnvironment;
        public HomeController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
        {
            this.dataManager = dataManager;
            this.hostEnvironment = hostEnvironment;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Product() : dataManager.product.GetProductsbyId(id);
            return View(entity);
        }

        public ViewResult ChooseGender()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Product model, IFormFile mainImage)
        {
            if (ModelState.IsValid)
            {
                if (mainImage != null)
                {
                    model.img = mainImage.FileName;
                    using (var stream = new FileStream(Path.Combine(hostEnvironment.WebRootPath, "images/", mainImage.FileName), FileMode.Create))
                    {
                        mainImage.CopyTo(stream);
                    }
                }
                dataManager.product.SaveProduct(model);
                return RedirectToAction(nameof(mensController.all), nameof(mensController).CutController());
            }
            return View(model);
        }
    }
}
