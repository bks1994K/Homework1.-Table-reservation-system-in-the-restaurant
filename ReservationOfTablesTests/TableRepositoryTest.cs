using Homework1._Table_reservation_system_in_the_restaurant.Services;
using Homework1._Table_reservation_system_in_the_restaurant;
using System.Text.Json;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;

namespace ReservationSystemInRestaurantTests
{
    public class TableRepositoryTest
    {
        [Test]

        public void GetTables()
        {
            Table table = new Table(1, 4);
            Table table1 = new Table(2, 8);
            Dictionary<int, Table> tables = new Dictionary<int, Table>() { { 1, table } };
            tables.Add(table1.Number, table1);
            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\TableTest.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(tables);
                sw.WriteLine(jsn);
            }
            TableRepository tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            tableRepository.Path = path;
            Dictionary<int, Table> expectedTables = tables;
            Dictionary<int, Table> actualTables = tableRepository.GetTables();
            CollectionAssert.AreEqual(expectedTables, actualTables);

        }
    }
}
