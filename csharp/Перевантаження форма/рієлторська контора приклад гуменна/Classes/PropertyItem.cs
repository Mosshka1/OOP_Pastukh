using System;
using рієлторська_контора_приклад_гуменна.Enums;

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
        public DealStatus Status { get; set; }
        public Form1.Currency Currency { get; set; }

        public PropertyItem() { }

        public PropertyItem(
            Form1.PropertyType type,
            string address,
            decimal area,
            int rooms,
            int yearBuilt,
            decimal price,
            DealStatus status,
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

        private static void EnsureSameCurrency(PropertyItem a, PropertyItem b)
        {
            if (a is null || b is null) throw new ArgumentNullException();
            if (a.Currency != b.Currency)
                throw new InvalidOperationException("Різні валюти — порівняння/операція неможливі.");
        }
        public static bool operator !(PropertyItem x)
            => x == null || x.Status == DealStatus.Продано;
        public static bool operator true(PropertyItem x)
            => x != null && x.Status != DealStatus.Продано;
        public static bool operator false(PropertyItem x) => !(x);

        public static PropertyItem operator ++(PropertyItem x)
        { if (x != null) x.Rooms++; return x; }

        public static PropertyItem operator --(PropertyItem x)
        { if (x != null && x.Rooms > 0) x.Rooms--; return x; }

        public override bool Equals(object obj)
        {
            var o = obj as PropertyItem;
            if (o == null) return false;
            return Type == o.Type
                && YearBuilt == o.YearBuilt
                && string.Equals(Address ?? "", o.Address ?? "", StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Type.GetHashCode();
                hash = hash * 23 + (Address?.ToLowerInvariant().GetHashCode() ?? 0);
                hash = hash * 23 + YearBuilt.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(PropertyItem a, PropertyItem b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);
        }
        public static bool operator !=(PropertyItem a, PropertyItem b) => !(a == b);

        public static bool operator <(PropertyItem a, PropertyItem b)
        { EnsureSameCurrency(a, b); return a.Price < b.Price; }

        public static bool operator >(PropertyItem a, PropertyItem b)
        { EnsureSameCurrency(a, b); return a.Price > b.Price; }

        public static bool operator <=(PropertyItem a, PropertyItem b) => !(a > b);
        public static bool operator >=(PropertyItem a, PropertyItem b) => !(a < b);
    }
}
