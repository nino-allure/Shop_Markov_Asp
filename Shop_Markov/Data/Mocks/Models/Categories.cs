using System.Collections.Generic;
using Shop_Markov.Data.Models;
namespace Shop_Markov.Data.Mocks.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Items> Items { get; set; }
    }
}
