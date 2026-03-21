using Shop_Markov.Data.Models;
using System.Collections.Generic;
namespace Shop_Markov.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<Items> AllItems { get; }
        public int Add(Items item);
        bool Change(Items item);
        bool Delete(int id);
        Items GetItemById(int id);
    }
}
