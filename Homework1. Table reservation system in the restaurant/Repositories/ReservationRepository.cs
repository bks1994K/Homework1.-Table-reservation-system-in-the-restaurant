using System.Text.Json;

namespace Homework1._Table_reservation_system_in_the_restaurant.Repositories
{
    public class ReservationRepository
    {
        private int _id;

        private Dictionary<int, Reservation> _reservations;

        public string Path { get; set; }

        public ReservationRepository(string path)
        {
            Path = $"{path}ReservationRepositories.txt";
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
            _id++;
            reservation.Number = _id;
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
            if (_reservations is null)
            {
                if (File.Exists(Path))
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        string jsn = sr.ReadLine();
                        Dictionary<int, Reservation> reservations = JsonSerializer.Deserialize<Dictionary<int, Reservation>>(jsn)!;
                        _reservations = reservations;
                    }
                }
                else
                {
                    _reservations = new Dictionary<int, Reservation>();
                }
                SetLastId();
            }
            return _reservations;
        }

        private void SetLastId()
        {
            int max = 0;
            foreach (var reservation in _reservations.Keys)
            {
                if (reservation > max)
                {
                    max = reservation;
                }
            }
            _id = max;
        }
    }
}
