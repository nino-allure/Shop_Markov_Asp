using Microsoft.AspNetCore.Mvc;
using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.ViewModell;
using Shop_Markov.Data.Models;
using Microsoft.Extensions.Hosting.Internal;

namespace Shop_Markov.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IHostingEnvironment hosingEnviroment;
        private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems iAllItems, ICategories iAllCategories, IHostingEnvironment environment) {
            this.IAllItems = iAllItems;
            this.IAllCategories = iAllCategories;
            this.hosingEnviroment = environment;
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> Categories = IAllCategories.AllCategories;
            return View(Categories);
        }
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int idCategory)
        {
            if (files != null)
            {
                var uploads = Path.Combine(HostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, files.FileName);
                files.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = files.FileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = idCategory };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Update?id=" + id);
        }
        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            return View(VMItems);
        }
    }
}
