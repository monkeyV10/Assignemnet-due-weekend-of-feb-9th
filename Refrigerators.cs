using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnet_due_weekend_of_feb_9th
{
    class Refrigerator : management
    {
        public int ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string Wattage { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string NumberOfDoors { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }

        public Refrigerator(int itemNumber, string brand, int quantity, string wattage, string color, string price, string numberOfDoors, string height, string width)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
            NumberOfDoors = numberOfDoors;
            Height = height;
            Width = width;

        }
    }
}