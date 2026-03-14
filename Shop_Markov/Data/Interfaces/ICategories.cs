using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.Models;
using System.Collections.Generic;
namespace Shop_Markov.Data.Interfaces
{
    public interface ICategories
    {
        IEnumerable<Categories> AllCategories { get; }
    }
}
