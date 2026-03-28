using Shop_Markov.Data.Models;

namespace Shop_Markov.Data.Mocks.Models
{
    public class ItemsBasket : Items
    {
        public int Count { get; set; }

        public ItemsBasket(int Count, Items item) : base(item)
        {
            this.Count = Count;
        }
    }
}
