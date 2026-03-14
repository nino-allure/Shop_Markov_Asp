using Shop_Markov.Data.Interfaces;
using Shop_Markov.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop_Markov.Data.Mocks
{
    public class MockItmes : IItems
    {
        public ICategories _category = new MockCategories();
        public Enumerable<Items> AllItems
        {
            get
            {
                return new List<Items>()
                {
                    new Items() {
                        Id = 0,
                        Name = "ЧЕРНЫЙ",
                        Description = "Очень круто",
                        Img =  "https://img-webcalypt.ru/uploads/admin/images/meme-templates/58b2e3a5bd73b36a6eec323264b6962a.jpg",
                        Price = 1488,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "PRADA NYLON",
                        Description = "Мега нейлон",
                        Img =  "https://images.capitoliumart.com/auction-images/492/303687.jpg",
                        Price = 9999,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "BMW",
                        Description = "bimmer",
                        Img =  "https://motor.ru/imgs/2024/05/08/07/6460671/ea354a10ec13c7443a1b2c42ff40b00888742c7b.jpg",
                        Price = 3333333,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Трон",
                        Description = "Модный",
                        Img =  "https://i.pinimg.com/236x/60/9d/d8/609dd800fe653e4354878375584e96f5.jpg",
                        Price = 10000000,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    },
                    new Items() {
                        Id = 0,
                        Name = "Бананы",
                        Description = "Слышно",
                        Img =  "https://storage.mrgeek.ru/Jqc06Dd5c233U01xHOc1coTNkMaI5LsCl0fmLMXTKLY/fit/1080/1080/no/1/aHR0cHM6Ly9tcmdlZWsucnUvaW1hZ2VzL3Byb2R1Y3RfcGljdHVyZXNfbmV3LzEwMDAvMTIwMC8xMjU1L3Byb2R1Y3RfcGljdHVyZXMvb3JpZ2luYWwvMTI1NS0xLmpwZw.jpg",
                        Price = 10000000,
                        Category = _category.AllCategories.Where(x => x.Id == 0).First()
                    }
                };
            }
        }
    }
}
