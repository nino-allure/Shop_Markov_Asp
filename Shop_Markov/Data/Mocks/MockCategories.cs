using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Mocks.Models;
using Shop_Markov.Data.Models;
using System.Collections.Generic;

namespace Shop_Markov.Data.Mocks
{
    public class MockCategories : ICategories
    {
        public IEnumerable<Categories> AllCategory
        {
            get
            {
                return new List<Categories>
                {
                    new Categories()
                    {
                        Id = 0,
                        Name = "Темно",
                        Description = "Нужно свет"
                    },
                    new Categories()
                    {
                        Id = 1,
                        Name = "Дорого и Стильно",
                        Description = "Верхний тир"
                    },
                    new Categories()
                    {
                        Id = 2,
                        Name = "Тачки",
                        Description = "топ колесницы"
                    }
                };
            }
        }
    }
}
