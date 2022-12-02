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
            reservations.Add(reservationOne.Number, reservationOne);
            reservations.Add(reservationTwo.Number, reservationTwo);

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

        public void GetReservationsTest_WhenFileIsNotExists_ShouldThrowDirectoryNotFoundException()
        {
            string path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\ReservationsTest.txt..";
            ReservationRepository reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tests\");
            reservationRepository.Path = path;
            Assert.Throws<DirectoryNotFoundException>(() => reservationRepository.GetReservations());
        }
    }
}
