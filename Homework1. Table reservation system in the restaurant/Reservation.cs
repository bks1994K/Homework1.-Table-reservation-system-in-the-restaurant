using System.Data;
using System.Xml.Linq;

namespace Homework1._Table_reservation_system_in_the_restaurant
{
    public class Reservation
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateTime { get; set; }

        public int QuantityOfPeople { get; set; }

        public int TableNumber { get; set; }

        public Reservation(string name, string phoneNumber, DateTime dateTime, int quantityOfPeople, int tableNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            DateTime = dateTime;
            TableNumber = tableNumber;
            QuantityOfPeople = quantityOfPeople;
        }

        public Reservation(DateTime dateTime, int tableNumber)
        {
            DateTime = dateTime;
            TableNumber = tableNumber;
        }

        public Reservation()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Reservation reservation &&
                   Number == reservation.Number &&
                   Name == reservation.Name &&
                   PhoneNumber == reservation.PhoneNumber &&
                   DateTime == reservation.DateTime &&
                   QuantityOfPeople == reservation.QuantityOfPeople &&
                   TableNumber == reservation.TableNumber;
        }
    }
}
