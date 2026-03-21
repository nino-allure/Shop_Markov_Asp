using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.Models;
using System.Collections.Generic;

namespace Shop_Markov.Data.ViewModell
{
    public class VMItems
    {
        public IEnumerable<Items> Items { get; set; }

        public IEnumerable<Categories>  Categories { get; set; }

        public int SelectCategory = 0;
    }
}
