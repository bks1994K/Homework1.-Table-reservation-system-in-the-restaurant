using FluentAssertions;
using Homework1._Table_reservation_system_in_the_restaurant;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;
using Homework1._Table_reservation_system_in_the_restaurant.Services;
using NUnit.Framework;
using ReservationSystemInRestaurantTests;
using System.Text.Json;

namespace ReservationOfTablesTests
{
    public class AdministratorServiceTests
    {
        private ReservationRepository _reservationRepository;
        private TableRepository _tableRepository;

        [SetUp]
        public void SetUp()
        {
            _reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            _tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
        }

        [Test]

        public void AddReservationOneTest()
        {
            Table table = new Table(11, 4);
            Reservation reservationOne = new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1);
            Reservation reservationCheck = new Reservation(new DateTime(2022, 01, 01, 14, 00, 00), 1);

            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            admin.AddTable(table);
            admin.AddReservation(reservationOne);
            admin.AddReservation(reservationCheck);
            List<Reservation> expected = new List<Reservation> { reservationOne, reservationCheck };

            List<Reservation> actual = admin.GetAllReservation();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 0)]
        [TestCase(2, 3)]
        [TestCase(4, 3)]
        [TestCase(5, 3)]
        [TestCase(6, 3)]
        [TestCase(7, 8)]
        [TestCase(7, 8)]
        [TestCase(14, 14)]
        public void AddReservationTestForTwoReservations(int mockNumber, int mockNumberExpected)
        {
            Table table = new Table(1, 4);
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            admin.AddTable(table);
            List<Reservation> reservationsForAdd = ReservationMock(mockNumber);
            admin.AddReservation(reservationsForAdd[0]);
            admin.AddReservation(reservationsForAdd[1]);
            List<Reservation> expected = ReservationMock(mockNumberExpected);
            List<Reservation> actual = admin.GetAllReservation();
            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(9, 9)]
        [TestCase(10, 11)]
        [TestCase(12, 13)]
        public void AddReservationTestForThreeReservations(int mockNumber, int mockNumberExpected)
        {
            Table table = new Table(1, 4);
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            admin.AddTable(table);
            List<Reservation> reservationsForAdd = ReservationMock(mockNumber);
            admin.AddReservation(reservationsForAdd[0]);
            admin.AddReservation(reservationsForAdd[1]);
            admin.AddReservation(reservationsForAdd[2]);

            List<Reservation> expected = ReservationMock(mockNumberExpected);
            List<Reservation> actual = admin.GetAllReservation();
            actual.Should().BeEquivalentTo(expected);
        }

        private List<Reservation> ReservationMock(int index)
        {
            switch (index)
            {
                case 0:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 14, 00, 00), 1) {Number=2 }
            };
                case 1:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 14, 00, 00), 1) {Number=2 }
            };
                case 2:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 13, 00, 00), 1) {Number=2 }
            };
                case 3:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 }
            };
                case 4:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 9, 00, 00), 1) {Number=2 }
            };
                case 5:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 7, 00, 00), 1) {Number=2 }
            };
                case 6:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 11, 00, 00), 1) {Number=2 }
            };
                case 7:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) {Number=2 }
            };
                case 8:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) {Number=2 }
            };
                case 9:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 06, 00, 00), 1) {Number=2 },
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) {Number=3 }
            };
                case 10:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) { Number = 1 } ,
                    new Reservation(new DateTime(2022, 01, 01, 08, 00, 00), 1) { Number = 2 },
                    new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1) { Number = 3 }
            };
                case 11:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) { Number = 1 } ,
                    new Reservation(new DateTime(2022, 01, 01, 08, 00, 00), 1) { Number = 2 }
            };
                case 12:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 15, 00, 00), 1) {Number=2 },
                    new Reservation(new DateTime(2022, 01, 01, 04, 59, 59), 1) {Number=3 }
            };
                case 13:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 02, 00, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 15, 00, 00), 1) {Number=2 }
            };
                case 14:
                    return new List<Reservation>
                    {
                    new Reservation(new DateTime(2022, 01, 01, 10, 30, 00), 1) {Number=1 },
                    new Reservation(new DateTime(2022, 01, 01, 13, 30, 01), 1) {Number=2 }
            };
                default:
                    throw new ArgumentException();
            }
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.RemoveReservationTestCaseSource))]
        public void RemoveReservationTest(Dictionary<int, Reservation> baseReservation, int numberRemoveReservation, Dictionary<int, Reservation> expectedReservation, bool expectedReservationBool)
        {
            using (StreamWriter sw = new StreamWriter(_reservationRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseReservation);
                sw.WriteLine(jsn);
            }
            AdministratorService admin = new AdministratorService(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            admin.RemoveReservation(numberRemoveReservation);
            Dictionary<int, Reservation> actualReservation;
            using (StreamReader sr = new StreamReader(_reservationRepository.Path))
            {
                string jsn = sr.ReadLine();
                actualReservation = JsonSerializer.Deserialize<Dictionary<int, Reservation>>(jsn)!;
            }
            CollectionAssert.AreEqual(expectedReservation, actualReservation);

            bool actualReservationBool = admin.RemoveReservation(numberRemoveReservation);
            CollectionAssert.AreEqual(expectedReservation, actualReservation);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.GetAllReservationTestCaseSource))]
        public void GetAllReservationTest(Dictionary<int, Reservation> baseReservation, List<Reservation> expectedReservation)
        {
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            using (StreamWriter sw = new StreamWriter(_reservationRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseReservation);
                sw.WriteLine(jsn);
            }
            List<Reservation> actualReservation = admin.GetAllReservation();
            CollectionAssert.AreEqual(expectedReservation, actualReservation);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.GetAllReservationOnDateTestCaseSource))]
        public void GetAllReservationOnDateTest(Dictionary<int, Reservation> baseReservation, DateTime date, List<Reservation> expectedReservation)
        {
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            using (StreamWriter sw = new StreamWriter(_reservationRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseReservation);
                sw.WriteLine(jsn);
            }
            List<Reservation> actualReservation = admin.GetAllReservationOnDate(date);
            CollectionAssert.AreEqual(expectedReservation, actualReservation);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.GetAllReservationForTableTestCaseSource))]
        public void GetAllReservationForTableTest(Dictionary<int, Reservation> baseReservation, int numberTable, List<Reservation> expectedReservation)
        {
            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\";
            AdministratorService admin = new AdministratorService(path);
            using (StreamWriter sw = new StreamWriter(_reservationRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseReservation);
                sw.WriteLine(jsn);
            }
            List<Reservation> actualReservation = admin.GetAllReservationForTable(numberTable);
            CollectionAssert.AreEqual(expectedReservation, actualReservation);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.GetAllReservationOnDateWithCapacityTestCaseSource))]
        public void GetAllReservationOnDateWithCapacityTest(Dictionary<int, Reservation> baseReservations, Dictionary<int, Table> tables, DateTime date, int quantity, List<Reservation> expectedReservation)
        {
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            using (StreamWriter sw = new StreamWriter(_reservationRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseReservations);
                sw.WriteLine(jsn);
            }
            using (StreamWriter sw = new StreamWriter(_tableRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(tables);
                sw.WriteLine(jsn);
            }
            List<Reservation> actualReservation = admin.GetAllReservationOnDateWithCapacity(date, quantity);
            CollectionAssert.AreEqual(expectedReservation, actualReservation);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.AddTableTestCaseSource))]
        public void AddTableTest(Dictionary<int, Table> baseTables, Table addTable, Dictionary<int, Table> expectedTables, bool expectedTablesBool)
        {
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            using (StreamWriter sw = new StreamWriter(_tableRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseTables);
                sw.WriteLine(jsn);
            }
            bool actualTablesBool = admin.AddTable(addTable);
            Dictionary<int, Table> actualTables;
            using (StreamReader sr = new StreamReader(_tableRepository.Path))
            {
                string jsn = sr.ReadLine();
                actualTables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn);
            }
            CollectionAssert.AreEqual(expectedTables, actualTables);
            Assert.AreEqual(expectedTablesBool, actualTablesBool);
        }

        [TestCaseSource(typeof(AdministratorServiceTestCaseSources), nameof(AdministratorServiceTestCaseSources.RemoveTableTestCaseSource))]
        public void RemoveTableTest(Dictionary<int, Table> baseTable, int numberRemoveTable, Dictionary<int, Table> expectedTable, bool expectedTablesBool)
        {
            AdministratorService admin = new AdministratorService(_reservationRepository, _tableRepository);
            using (StreamWriter sw = new StreamWriter(_tableRepository.Path))
            {
                string jsn = JsonSerializer.Serialize(baseTable);
                sw.WriteLine(jsn);
            }
            bool actualTablesBool = admin.RemoveTable(numberRemoveTable);
            Dictionary<int, Table> actualTables;
            using (StreamReader sr = new StreamReader(_tableRepository.Path))
            {
                string jsn = sr.ReadLine();
                actualTables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn)!;
            }
            CollectionAssert.AreEqual(expectedTable, actualTables);
            Assert.AreEqual(expectedTablesBool, actualTablesBool);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_reservationRepository.Path);
            File.Delete(_tableRepository.Path);
        }
    }
}


