using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignemnet_due_weekend_of_feb_9th
{
    class Vacuum : management
    {
        public int ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string Wattage { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string Grade { get; set; }
        public string BatteryVoltage { get; set; }
        public string BatteryVoltageType { get; set; }

        public Vacuum(int itemNumber, string brand, int quantity, string wattage, string color, string price, string grade, string batteryVoltage, string batteryVoltageType)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
            Grade = grade;
            BatteryVoltage = batteryVoltage;
            BatteryVoltageType = batteryVoltageType;
        }
    }
}