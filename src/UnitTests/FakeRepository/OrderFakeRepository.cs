using Domain.Contracts.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.FakeRepository
{
    public class OrderFakeRepository : IOrderRepository
    {
        public void Add(Order entity)
        {
            return;
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return new List<Order>() {
                new Order()
                {
                    Id = "123456",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Description = "Item A",
                            Qtd = 5,
                            UnitPrice = 10
                        },
                        new Item()
                        {
                            Description = "Item B",
                            UnitPrice = 5,
                            Qtd= 2
                        }
                    }
                },
                new Order()
                {
                    Id = "one",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Description = "Item A",
                            Qtd = 2,
                            UnitPrice = 10
                        }
                    }
                },
                 new Order()
                {
                    Id = "oneQtd",
                    Items = new List<Item>()
                    {
                        new Item()
                        {
                            Description = "Item A",
                            Qtd = 1,
                            UnitPrice = 20
                        }
                    }
                }
            };
        }

        public Order GetById(string id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);

        }

        public void Remove(Order entity)
        {
            return;
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
