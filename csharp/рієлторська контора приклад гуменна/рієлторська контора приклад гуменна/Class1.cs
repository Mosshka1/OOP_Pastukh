using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace рієлторська_контора_приклад_гуменна
{
    [Serializable]
    public class PropertyItem
    {
        public Form1.PropertyType Type { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int Rooms { get; set; }
        public int YearBuilt { get; set; }
        public decimal Price { get; set; }
        public Form1.DealStatus Status { get; set; }
        public Form1.Currency Currency { get; set; }

        public PropertyItem() { }

        public PropertyItem(
            Form1.PropertyType type,
            string address,
            decimal area,
            int rooms,
            int yearBuilt,
            decimal price,
            Form1.DealStatus status,
            Form1.Currency currency)
        {
            Type = type;
            Address = address;
            Area = area;
            Rooms = rooms;
            YearBuilt = yearBuilt;
            Price = price;
            Status = status;
            Currency = currency;
        }

    }
}

