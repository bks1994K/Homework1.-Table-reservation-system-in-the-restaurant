namespace Homework1._Table_reservation_system_in_the_restaurant
{
    public class Table
    {
        public int Number { get; set; }

        public int CapacityOfOneTable { get; set; }

        public bool isReserved { get; set; }

        public Table(int number, int capacity)
        {
            Number = number;
            CapacityOfOneTable = capacity;
            isReserved = false;
        }
        public Table()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Table table &&
                   Number == table.Number &&
                   CapacityOfOneTable == table.CapacityOfOneTable &&
                   isReserved == table.isReserved;
        }
    }
}
