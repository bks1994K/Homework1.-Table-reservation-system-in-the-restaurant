using System.Text.Json;

namespace Homework1._Table_reservation_system_in_the_restaurant.Repositories
{
    public class ReservationRepository
    {
        public string Path { get; set; }

        public ReservationRepository(string path)
        {
            Path = $"{path}Repositories.txt";
        }

            //Path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Reservations.txt";
        public Dictionary<int, Reservation> GetReservations()
        {
            Dictionary<int, Reservation> reservations = LoadAll();
            return reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            Dictionary<int, Reservation> reservations = LoadAll();
            reservations.Add(reservation.Number, reservation);
            SaveAll(reservations);
        }

        public void RemoveReservation(int numberReservation)
        {
            Dictionary<int, Reservation> reservations = LoadAll();
            reservations.Remove(numberReservation);
            SaveAll(reservations);
        }

        private void SaveAll(Dictionary<int, Reservation> reservations)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                string jsn = JsonSerializer.Serialize(reservations);
                sw.WriteLine(jsn);
            }
        }

        private Dictionary<int, Reservation> LoadAll()
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string jsn = sr.ReadLine();
                    Dictionary<int, Reservation> reservations = JsonSerializer.Deserialize<Dictionary<int, Reservation>>(jsn)!;
                    return reservations;
                }
            }
            return new Dictionary<int, Reservation>();
        }
    }
}
