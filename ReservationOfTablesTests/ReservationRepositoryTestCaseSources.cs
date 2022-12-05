using Homework1._Table_reservation_system_in_the_restaurant;
using System.Collections;

namespace ReservationSystemInRestaurantTests
{
    public static class ReservationRepositoryTestCaseSources
    {
        public static IEnumerable AddReservationTestSource()
        {
            Reservation reservOne = new Reservation
            {
                Number = 1,
                DateTime = new DateTime(2023, 01, 01),
                TableNumber = 1
            };
            Reservation reservTwo = new Reservation("Rita", "222222222", new DateTime(2023, 02, 02), 4, 2);
            reservTwo.Number = 2;
            Reservation reservThree = new Reservation
            {
                Number = 3
            };
            Dictionary<int, Reservation> baseReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
                { reservTwo.Number, reservTwo },
                { reservThree.Number, reservThree }
            };
            Reservation addReservation = new Reservation(new DateTime(2023, 10, 01), 3);
            addReservation.Number = 4;
            Dictionary<int, Reservation> expectedReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
                { reservTwo.Number, reservTwo },
                { reservThree.Number, reservThree },
                {addReservation.Number, addReservation }
            };

            yield return new Object[] { baseReservations, addReservation, expectedReservations };

            baseReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne }
            };
            addReservation = new Reservation(new DateTime(2023, 01, 01), 1);
            addReservation.Number = 2;
            expectedReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
                { addReservation.Number, addReservation}
            };

            yield return new Object[] { baseReservations, addReservation, expectedReservations };

            baseReservations = new Dictionary<int, Reservation>();
            addReservation = new Reservation(new DateTime(2023, 01, 01), 1);
            addReservation.Number = 1;
            expectedReservations = new Dictionary<int, Reservation>
            {
                { addReservation.Number, addReservation }
            };

            yield return new Object[] { baseReservations, addReservation, expectedReservations };

            reservOne = new Reservation();
            baseReservations = new Dictionary<int, Reservation> { { reservOne.Number, reservOne } };
            addReservation = new Reservation(new DateTime(2023, 01, 01), 1);
            addReservation.Number = 1;
            expectedReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
                {addReservation.Number, addReservation }
            };

            yield return new Object[] { baseReservations, addReservation, expectedReservations };
        }

        public static IEnumerable RemoveReservationTestSource()
        {
            Reservation reservOne = new Reservation()
            {
                Number = 1,
                DateTime = new DateTime(2023, 01, 01),
                TableNumber = 1
            };
            Reservation reservTwo = new Reservation()
            {
                Number = 2,
                DateTime = new DateTime(2023, 01, 02),
                TableNumber = 1
            };
            Reservation reservThree = new Reservation()
            {
                Number = 3,
                DateTime = new DateTime(2023, 01, 03),
                TableNumber = 3
            };
            Dictionary<int, Reservation> baseReservations = new Dictionary<int, Reservation>
            {
            { reservOne.Number, reservOne },
                { reservTwo.Number, reservTwo },
                { reservThree.Number, reservThree }
            };
            int numberRemoveReservation = reservThree.Number;
            Dictionary<int, Reservation> expectedReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
                { reservTwo.Number, reservTwo }
            };

            yield return new Object[] { baseReservations, numberRemoveReservation, expectedReservations };

            baseReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
            };
            numberRemoveReservation = reservOne.Number;
            expectedReservations = new Dictionary<int, Reservation>();

            yield return new Object[] { baseReservations, numberRemoveReservation, expectedReservations };

            numberRemoveReservation = 5;
            expectedReservations = new Dictionary<int, Reservation>
            {
                { reservOne.Number, reservOne },
            };

            yield return new Object[] { baseReservations, numberRemoveReservation, expectedReservations };
        }
    }
}
