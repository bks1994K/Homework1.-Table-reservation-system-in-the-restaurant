using Homework1._Table_reservation_system_in_the_restaurant;
using System.Text.Json;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;

namespace ReservationSystemInRestaurantTests
{
    public class TableRepositoryTest
    {
        private string _path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\TableTest.txt";
        private TableRepository _tableRepository;

        [SetUp]
        public void SetUp()
        {
            _tableRepository = new TableRepository("");
            _tableRepository.Path = _path;
        }

        [Test]
        public void GetTables()
        {
            Table table = new Table(1, 4);
            Table table1 = new Table(2, 8);
            Dictionary<int, Table> tables = new Dictionary<int, Table>() { { 1, table } };
            tables.Add(table1.Number, table1);
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(tables);
                sw.WriteLine(jsn);
            }
            Dictionary<int, Table> expectedTables = tables;
            Dictionary<int, Table> actualTables = _tableRepository.GetTables();
            CollectionAssert.AreEqual(expectedTables, actualTables);
        }

        [TestCaseSource(typeof(TableRepositoryTestCaseSources), nameof(TableRepositoryTestCaseSources.AddTableTestSource))]
        public void AddTableTest(Dictionary<int, Table> baseTables, Table addTable, Dictionary<int, Table> expectedTables)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(baseTables);
                sw.WriteLine(jsn);
            }
            _tableRepository.AddTable(addTable);
            Dictionary<int, Table> actualTables;
            using (StreamReader sr = new StreamReader(_path))
            {
                string jsn = sr.ReadLine();
                actualTables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn);
            }
            CollectionAssert.AreEqual(expectedTables, actualTables);
        }

        [TestCaseSource(typeof(TableRepositoryTestCaseSources), nameof(TableRepositoryTestCaseSources.RemoveTableTestSource))]
        public void RemoveTableTest(Dictionary<int, Table> baseTable, int numberRemoveTable, Dictionary<int, Table> expectedTables, bool expectedTablesBool)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(baseTable);
                sw.WriteLine(jsn);
            }
            bool actualTablesBool = _tableRepository.RemoveTable(numberRemoveTable);
            Dictionary<int, Table> actualTables;
            using (StreamReader sr = new StreamReader(_path))
            {
                string jsn = sr.ReadLine();
                actualTables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn)!;
            }
            CollectionAssert.AreEqual(expectedTables, actualTables);
            Assert.AreEqual(expectedTablesBool, actualTablesBool);
        }

        [TestCaseSource(typeof(TableRepositoryTestCaseSources), nameof(TableRepositoryTestCaseSources.GetTableByNumberTestSource))]
        public void GetTableByNumberTest(Dictionary<int, Table> baseTable, int tableNumber, Table expectedTable)
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                string jsn = JsonSerializer.Serialize(baseTable);
                sw.WriteLine(jsn);
            }
            Table actualTable = _tableRepository.GetTableByNumber(tableNumber);
            Assert.AreEqual(expectedTable, actualTable);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_path);
        }
    }
}

