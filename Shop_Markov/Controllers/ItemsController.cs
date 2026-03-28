using Microsoft.AspNetCore.Mvc;
using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.ViewModell;
using Shop_Markov.Data.Models;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Shop_Markov.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems iAllItems, ICategories iAllCategories, IWebHostEnvironment environment) 
        {
            this.IAllItems = iAllItems;
            this.IAllCategories = iAllCategories;
            this.hostingEnvironment = environment;
        }

        [HttpGet]
        public ViewResult Add()
        {
            IEnumerable<Categories> Categories = IAllCategories.AllCategories;
            return View(Categories);
        }
        
        [HttpPost]
        public RedirectResult Add(string name, string description, IFormFile files, float price, int CategoryId)
        {
            string fileName = null;
            
            if (files != null && files.Length > 0)
            {
                fileName = files.FileName;
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                
                // Создаем папку если её нет
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                
                var filePath = Path.Combine(uploads, fileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
            }

            Items newItems = new Items();
            newItems.Name = name;
            newItems.Description = description;
            newItems.Img = fileName;
            newItems.Price = Convert.ToInt32(price);
            newItems.Category = new Categories() { Id = CategoryId };
            int id = IAllItems.Add(newItems);
            return Redirect("/Items/Change?id=" + id);
        }
        
        // GET: /Items/Change
        [HttpGet]
        public IActionResult Change(int id)
        {
            Items item = IAllItems.GetItemById(id);
            
            if (item == null)
            {
                return NotFound();
            }
            
            ViewBag.Categories = IAllCategories.AllCategories;
            return View(item);
        }
        
        // POST: /Items/Change
        [HttpPost]
        public IActionResult Change(int id, string name, string description, IFormFile files, float price, int CategoryId)
        {
            Items existingItem = IAllItems.GetItemById(id);
            
            if (existingItem == null)
            {
                return NotFound();
            }
            
            // Обновляем данные
            existingItem.Name = name;
            existingItem.Description = description;
            existingItem.Price = Convert.ToInt32(price);
            existingItem.Category = new Categories() { Id = CategoryId };
            
            // Обновляем изображение если загружено новое
            if (files != null && files.Length > 0)
            {
                // Удаляем старое изображение если оно существует
                if (!string.IsNullOrEmpty(existingItem.Img))
                {
                    var oldFilePath = Path.Combine(hostingEnvironment.WebRootPath, "img", existingItem.Img);
                    if (System.IO.File.Exists(oldFilePath))
                    {
                        System.IO.File.Delete(oldFilePath);
                    }
                }
                
                // Сохраняем новое изображение
                string fileName = files.FileName;
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "img");
                var filePath = Path.Combine(uploads, fileName);
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    files.CopyTo(fileStream);
                }
                
                existingItem.Img = fileName;
            }
            
            bool result = IAllItems.Change(existingItem);
            
            if (result)
            {
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Error = "Ошибка при обновлении товара";
                ViewBag.Categories = IAllCategories.AllCategories;
                return View(existingItem);
            }
        }
        
        // GET: /Items/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Items item = IAllItems.GetItemById(id);
            
            if (item == null)
            {
                return NotFound();
            }
            
            return View(item);
        }
        
        // POST: /Items/Delete
        [HttpPost]
        public IActionResult Delete(int id, string confirm)
        {
            Items item = IAllItems.GetItemById(id);
            
            if (item == null)
            {
                return NotFound();
            }
            
            // Удаляем изображение
            if (!string.IsNullOrEmpty(item.Img))
            {
                var filePath = Path.Combine(hostingEnvironment.WebRootPath, "img", item.Img);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            
            bool result = IAllItems.Delete(id);
            
            if (result)
            {
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Error = "Ошибка при удалении товара";
                return View(item);
            }
        }
        
        public ViewResult List(int id = 0)
        {
            ViewBag.Title = "Страница с предметами";
            VMItems.Items = IAllItems.AllItems;
            VMItems.Categories = IAllCategories.AllCategories;
            VMItems.SelectCategory = id;
            return View(VMItems);
        }

        public ActionResult Basket(int idItem = -1)
        {
            if (idItem != 1)
            {
                StartupBase.BasketItem.Add(new ItemsBasket(1, IAllItems.AllItems.Where(x =>  x.Id == idItem).First()));
            }
        }
    }
}