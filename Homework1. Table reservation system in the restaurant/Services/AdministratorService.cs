using Homework1._Table_reservation_system_in_the_restaurant.Repositories;
using System.Data;
using System.Text.Json;

namespace Homework1._Table_reservation_system_in_the_restaurant.Services
{
    public class AdministratorService
    {
        private ReservationRepository _reservationRepository;

        private TableRepository _tableRepository;

        public AdministratorService(ReservationRepository reservationRepository, TableRepository tableRepository)
        {
            _reservationRepository = reservationRepository;
            _tableRepository = tableRepository;
        }

        public AdministratorService()
        {
            _reservationRepository = new ReservationRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\");
            _tableRepository = new TableRepository(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\");
        }

        public bool AddReservation(Reservation reservation)
        {
            var reservations = _reservationRepository.GetReservations();
            foreach (var item in reservations)
            {
                if (item.Value.TableNumber == reservation.TableNumber
                    && !(item.Value.DateTime > reservation.DateTime.AddHours(3)
                    || item.Value.DateTime.AddHours(3) < reservation.DateTime))
                {
                    return false;
                }
            }
            _reservationRepository.AddReservation(reservation);
            return true;
        }

        public void RemoveReservation(int numberReservation)
        {
            _reservationRepository.RemoveReservation(numberReservation);
        }

        public List<Reservation> GetAllReservation()
        {
            var reservations = _reservationRepository.GetReservations();
            return reservations.Values.ToList();
        }

        public List<Reservation> GetAllReservationOnDate(DateTime date)
        {
            var reservations = _reservationRepository.GetReservations();
            List<Reservation> result = new List<Reservation>();
            foreach (var item in reservations)
            {
                if (item.Value.DateTime.Date == date.Date)
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }

        public List<Reservation> GetAllReservationForTable(int numberTable)
        {
            var reservations = _reservationRepository.GetReservations();
            List<Reservation> result = new List<Reservation>();
            foreach (var item in reservations)
            {
                if (item.Value.TableNumber == numberTable)
                {
                    result.Add(item.Value);
                }
            }
            return result;
        }

        public List<Reservation> GetAllReservationOnDateWithCapacity(DateTime date, int quantity)
        {
            var reservations = GetAllReservationOnDate(date);
            List<Reservation> result = new List<Reservation>();
            foreach (var item in reservations)
            {
                Table table = _tableRepository.GetTableByNumber(item.TableNumber);
                if (table.CapacityOfOneTable >= quantity)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public void AddTable(Table table)
        {
            _tableRepository.AddTable(table);
        }

        public void RemoveTable(int numberTable)
        {
            _tableRepository.RemoveTable(numberTable);
        }
    }
}

