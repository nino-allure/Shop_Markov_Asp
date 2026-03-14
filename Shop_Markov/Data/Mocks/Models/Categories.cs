using System.Collections.Generic;
namespace Shop_Markov.Data.Mocks.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<items> Items { get; set; }
    }
}
