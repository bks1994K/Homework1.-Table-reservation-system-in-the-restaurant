using Homework1._Table_reservation_system_in_the_restaurant;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using System.Collections.Generic;

namespace ReservationSystemInRestaurantTests
{
    public static class AdministratorServiceTestCaseSources
    {
        public static IEnumerable RemoveReservationTestCaseSource()
        {
            Reservation reservationOne = new Reservation(new DateTime(2023, 10, 10, 10, 00, 00), 1);
            Reservation reservationTwo = new Reservation(new DateTime(2023, 10, 20, 20, 00, 00), 1);
            Reservation reservationThree = new Reservation(new DateTime(2023, 10, 30, 13, 00, 00), 2);
            Dictionary<int, Reservation> baseReservation = new Dictionary<int, Reservation>
            {
                { 1, reservationOne},
                { 2, reservationTwo},
                { 3, reservationThree}
            };
            int numberRemoveReservation = 3;
            Dictionary<int, Reservation> expectedReservation = new Dictionary<int, Reservation>
            {
                { 1, reservationOne},
                { 2, reservationTwo}
            };
            bool expectedReservationBool = true;

            yield return new Object[] { baseReservation, numberRemoveReservation, expectedReservation, expectedReservationBool };

            baseReservation = new Dictionary<int, Reservation>
            {
                { 1, reservationOne}
            };
            numberRemoveReservation = 1;
            expectedReservation = new Dictionary<int, Reservation>();

            yield return new Object[] { baseReservation, numberRemoveReservation, expectedReservation, expectedReservationBool };

            baseReservation = new Dictionary<int, Reservation>
            {
                { 5, reservationOne},
                { 6, reservationTwo}
            };
            numberRemoveReservation = 10;
            expectedReservation = new Dictionary<int, Reservation>
            {
                { 5, reservationOne},
                { 6, reservationTwo}
            };
            expectedReservationBool = false;

            yield return new Object[] { baseReservation, numberRemoveReservation, expectedReservation, expectedReservationBool };
        }

        public static IEnumerable GetAllReservationTestCaseSource()
        {
            Reservation reservationOne = new Reservation(new DateTime(2023, 02, 11), 2);
            reservationOne.Number = 9;
            Reservation reservationTwo = new Reservation(new DateTime(2023, 02, 11), 2);
            reservationTwo.Number = 10;
            Reservation reservationThree = new Reservation
            {
                Number = 11
            };
            Dictionary<int, Reservation> baseReservation = new Dictionary<int, Reservation>
            {
                {reservationOne.Number, reservationOne },
                {10, reservationTwo },
                {reservationThree.Number, reservationThree }
            };
            List<Reservation> expectedReservation = new List<Reservation>
            {
                { reservationOne },
                {reservationTwo },
                {reservationThree }
            };

            yield return new Object[] { baseReservation, expectedReservation };

            baseReservation = new Dictionary<int, Reservation>();
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservation, expectedReservation };

            Reservation reservation = new Reservation();
            baseReservation = new Dictionary<int, Reservation> { { reservation.Number, reservation } };
            expectedReservation = new List<Reservation> { reservation };

            yield return new Object[] { baseReservation, expectedReservation };
        }
    }
}

