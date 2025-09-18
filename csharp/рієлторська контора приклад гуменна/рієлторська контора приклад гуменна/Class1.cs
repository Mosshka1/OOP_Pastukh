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
        public string Type { get; set; }
        public string Address { get; set; }
        public decimal Area { get; set; }
        public int Rooms { get; set; }
        public int YearBuilt { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; } 


        public PropertyItem() { }

        public PropertyItem(string type, string address, decimal area, int rooms, int yearBuilt, decimal price, string status)
            {
                Type = type;
                Address = address;
                Area = area;
                Rooms = rooms;
                YearBuilt = yearBuilt;
                Price = price;
                Status = status;
            }
        }
   
    }

