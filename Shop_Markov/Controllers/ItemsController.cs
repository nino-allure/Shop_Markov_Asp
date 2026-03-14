using Microsoft.AspNetCore.Mvc;
using Shop_Markov.Data.Interfaces;

namespace Shop_Markov.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategories;

        public ItemsController(IItems iAllItems, ICategories iAllCategories) {
            this.IAllItems = iAllItems;
            this.IAllCategories = iAllCategories;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Страница с предметами";

            var cars = IAllItems.AllItems;
            return View(cars);
        }
    }
}
