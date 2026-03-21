using Microsoft.AspNetCore.Mvc;
using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.ViewModell;

namespace Shop_Markov.Controllers
{
    public class ItemsController : Controller
    {
        private IItems IAllItems;
        private ICategories IAllCategories;
        VMItems VMItems = new VMItems();

        public ItemsController(IItems iAllItems, ICategories iAllCategories) {
            this.IAllItems = iAllItems;
            this.IAllCategories = iAllCategories;
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
