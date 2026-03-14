using Shop_Markov.Data.Models;
using System.Collections.Generic;
namespace Shop_Markov.Data.Interfaces
{
    public interface IItems
    {
        public IEnumerable<items> AllItems { get; }
    }
}
