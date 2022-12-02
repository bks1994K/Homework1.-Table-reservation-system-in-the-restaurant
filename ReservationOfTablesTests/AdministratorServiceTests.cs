using FluentAssertions;
using Homework1._Table_reservation_system_in_the_restaurant;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;
using Homework1._Table_reservation_system_in_the_restaurant.Services;
using System.Text.Json;

namespace ReservationOfTablesTests
{
    public class AdministratorServiceTests
    {
        [Test]

        public void AddReservationOneTest()
        {
            Table table = new Table(11, 4);
            Reservation reservationOne = new Reservation(new DateTime(2022, 01, 01, 10, 00, 00), 1);
            Reservation reservationCheck = new Reservation(new DateTime(2022, 01, 01, 14, 00, 00), 1);
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            TableRepository tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");

            ClearTableRepository(tableRepository.Path);
            ClearReservationRepository(reservationRepository.Path);
                        
            AdministratorService admin = new AdministratorService(reservationRepository, tableRepository);
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
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            TableRepository tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");

            ClearTableRepository(tableRepository.Path);
            ClearReservationRepository(reservationRepository.Path);

            AdministratorService admin = new AdministratorService(reservationRepository, tableRepository);
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
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            TableRepository tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");

            ClearTableRepository(tableRepository.Path);
            ClearReservationRepository(reservationRepository.Path);

            AdministratorService admin = new AdministratorService(reservationRepository, tableRepository);
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

        public void ClearTableRepository(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(new Dictionary<int, Table>());
                sw.WriteLine(jsn);
            }
        }

        public void ClearReservationRepository(string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(new Dictionary<int, Reservation>());
                sw.WriteLine(jsn);
            }
        }
    }
}


