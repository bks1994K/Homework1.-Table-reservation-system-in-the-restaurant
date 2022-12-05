using Homework1._Table_reservation_system_in_the_restaurant;
using Homework1._Table_reservation_system_in_the_restaurant.Repositories;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ReservationSystemInRestaurantTests
{
    public class ReservationRepositoryTest
    {
        [Test]
        public void GetReservationsTest()
        {
            Reservation reservationOne = new Reservation(new DateTime(2023, 01, 01), 1);
            Reservation reservationTwo = new Reservation("Koly", "222222222", new DateTime(2023, 02, 02), 2, 2);
            Dictionary<int, Reservation> reservations = new Dictionary<int, Reservation>();
            reservations.Add(1, reservationOne);
            reservations.Add(2, reservationTwo);

            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\ReservationsTest.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(reservations);
                sw.WriteLine(jsn);
            }

            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            reservationRepository.Path = path;

            Dictionary<int, Reservation> actual = reservationRepository.GetReservations();
            Dictionary<int, Reservation> expected = reservations;
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetReservationsTest_WhenFileIsNotExists_ShouldEmptyDictionary()
        {
            string path = @"Reservations..Test";
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            reservationRepository.Path = path;

            Dictionary<int, Reservation> actual = reservationRepository.GetReservations();
            Dictionary<int, Reservation> expected = new Dictionary<int, Reservation>();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(ReservationRepositoryTestCaseSources), nameof(ReservationRepositoryTestCaseSources.AddReservationTestSource))]
        public void AddReservationTest(Dictionary<int, Reservation> baseReservations, Reservation addReservation, Dictionary<int, Reservation> expectedReservations)
        {
            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\ReservationsTest.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(baseReservations);
                sw.WriteLine(jsn);
            }
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            reservationRepository.Path = path;
            reservationRepository.AddReservation(addReservation);

            Dictionary<int, Reservation> actualReservations;
            using (StreamReader sr = new StreamReader(path))
            {
                string jsn = sr.ReadLine();
                actualReservations = JsonSerializer.Deserialize<Dictionary<int, Reservation>>(jsn)!;
            }
            CollectionAssert.AreEqual(expectedReservations, actualReservations);
        }

        [TestCaseSource(typeof(ReservationRepositoryTestCaseSources), nameof(ReservationRepositoryTestCaseSources.RemoveReservationTestSource))]
        public void RemoveReservationTest(Dictionary<int, Reservation> baseReservations, int numberRemoveReservation, Dictionary<int, Reservation> expectedReservations)
        {
            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\ReservationsTest.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                string jsn = JsonSerializer.Serialize(baseReservations);
                sw.WriteLine(jsn);
            }
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            reservationRepository.Path = path;
            reservationRepository.RemoveReservation(numberRemoveReservation);
            Dictionary<int, Reservation> actualReservations;
            using (StreamReader sr = new StreamReader(path))
            {
                string jsn = sr.ReadLine();
                actualReservations = JsonSerializer.Deserialize<Dictionary<int, Reservation>>(jsn)!;
            }
            CollectionAssert.AreEqual(expectedReservations, actualReservations);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\ReservationsTest.txt");
        }
    }
}
