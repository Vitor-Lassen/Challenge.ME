using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item
    {
        public string Id { get; set; } 
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Amount { get; set; }

        public Item(string? id = null)
        {
            Id = string.IsNullOrEmpty(id) ? Guid.NewGuid().ToString() : id;
        }
        public Item(DTO.Item item) : this (item.Id)
        {
            Description = item.Description;
            UnitPrice = item.UnitPrice;
            Amount = item.Amount;   
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Item))
                return false;
            var item = (Item)obj;
            if (Id == item.Id &&
                Description == item.Description &&
                UnitPrice == item.UnitPrice &&
                Amount == item.Amount)
                return true;
            return false;
             
        }

    }
}
