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

        public static IEnumerable GetAllReservationOnDateTestCaseSource()
        {
            Reservation reservationOne = new Reservation
            {
                Number = 1,
                DateTime = new DateTime(2023, 01, 11)
            };
            Reservation reservationTwo = new Reservation(new DateTime(2023, 01, 11, 10, 30, 00), 2);
            reservationTwo.Number = 2;
            Reservation reservationThree = new Reservation(new DateTime(2023, 02, 11), 2);
            reservationThree.Number = 3;
            Dictionary<int, Reservation> baseReservation = new Dictionary<int, Reservation>
            {
                {reservationOne.Number, reservationOne },
                { 2, reservationTwo},
                {3, reservationThree }
            };
            DateTime date = new DateTime(2023, 01, 11);
            List<Reservation> expectedReservation = new List<Reservation>
            {
                {reservationOne },
                { reservationTwo}
            };

            yield return new Object[] { baseReservation, date, expectedReservation };

            Reservation reservFive = new Reservation(new DateTime(2023, 02, 01, 12, 00, 00), 10);
            reservFive.Number = 5;
            Reservation reservSix = new Reservation(new DateTime(2023, 02, 01, 12, 00, 00), 8);
            reservSix.Number = 6;
            Reservation reservSeven = new Reservation(new DateTime(2023, 02, 01, 12, 30, 00), 1);
            reservSeven.Number = 7;
            baseReservation = new Dictionary<int, Reservation>
            {
                {reservFive.Number, reservFive },
                { 6, reservSix},
                {7, reservSeven }
            };
            date = new DateTime(2023, 02, 01, 12, 00, 00);
            expectedReservation = new List<Reservation>
            {
                {reservFive },
                { reservSix},
                { reservSeven}
            };

            yield return new Object[] { baseReservation, date, expectedReservation };

            date = new DateTime(2023, 03, 03);
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservation, date, expectedReservation };

            Reservation emptyReservation = new Reservation();
            baseReservation = new Dictionary<int, Reservation>
            {
                {emptyReservation.Number, emptyReservation }
            };
            date = new DateTime(2023, 04, 04);

            yield return new Object[] { baseReservation, date, expectedReservation };
        }

        public static IEnumerable GetAllReservationForTableTestCaseSource()
        {
            Reservation reservationOne = new Reservation
            {
                Number = 1,
                DateTime = new DateTime(2023, 04, 05),
                TableNumber = 3
            };
            Reservation reservationTwo = new Reservation(new DateTime(2023, 03, 06, 10, 30, 00), 2);
            reservationTwo.Number = 2;
            Reservation reservationThree = new Reservation(new DateTime(2023, 06, 07), 3);
            reservationThree.Number = 3;
            Dictionary<int, Reservation> baseReservation = new Dictionary<int, Reservation>
            {
                {reservationOne.Number, reservationOne },
                { 2, reservationTwo},
                {3, reservationThree }
            };
            int numberTable = 3;
            List<Reservation> expectedReservation = new List<Reservation>
            {
                { reservationOne},
                { reservationThree}
            };

            yield return new Object[] { baseReservation, numberTable, expectedReservation };

            Reservation reservFive = new Reservation(new DateTime(2023, 11, 11), 9);
            reservFive.Number = 5;
            Reservation reservSix = new Reservation(new DateTime(2024, 01, 03), 7);
            reservSix.Number = 6;
            Reservation reservSeven = new Reservation(new DateTime(2022, 12, 12), 12);
            reservSeven.Number = 7;
            baseReservation = new Dictionary<int, Reservation>
            {
                {reservFive.Number, reservFive },
                { 6, reservSix},
                {7, reservSeven }
            };
            numberTable = 1;
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservation, numberTable, expectedReservation };

            Reservation emptyReservation = new Reservation();
            baseReservation = new Dictionary<int, Reservation>
            {
                {emptyReservation.Number, emptyReservation }
            };
            numberTable = 15;
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservation, numberTable, expectedReservation };
        }

        public static IEnumerable GetAllReservationOnDateWithCapacityTestCaseSource()
        {
            Table tableOne = new Table(1, 6);
            Table tableTwo = new Table(2, 2);
            Dictionary<int, Table> tables = new Dictionary<int, Table>
            {
                {tableOne.Number, tableOne },
                { 2, tableTwo}
            };
            Reservation reservationOne = new Reservation
            {
                Number = 1,
                DateTime = new DateTime(2023, 11, 10),
                TableNumber = 1
            };
            Reservation reservationTwo = new Reservation(new DateTime(2023, 11, 10), 1);
            reservationTwo.Number = 2;
            Reservation reservationThree = new Reservation(new DateTime(2023, 11, 10), 2);
            reservationThree.Number = 3;
            Dictionary<int, Reservation> baseReservations = new Dictionary<int, Reservation>
            {
                {reservationOne.Number, reservationOne },
                { 2, reservationTwo},
                {3, reservationThree }
            };
            int quantity = 4;
            DateTime date = new DateTime(2023, 11, 10);
            List<Reservation> expectedReservation = new List<Reservation>
            {
                { reservationOne},
                { reservationTwo}
            };

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            Table tableFive = new Table(5, 4);
            Table tableSix = new Table(6, 10);
            tables = new Dictionary<int, Table>
            {
                {5, tableFive },
                { 6, tableSix}
            };
            Reservation reservationFive = new Reservation
            {
                Number = 5,
                DateTime = new DateTime(2023, 03, 03),
                TableNumber = 5
            };
            Reservation reservationSix = new Reservation(new DateTime(2023, 11, 11), 5);
            reservationSix.Number = 6;
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive },
                { 6, reservationSix}
            };
            quantity = 3;
            date = new DateTime(2023, 03, 03);
            expectedReservation = new List<Reservation>
            {
                { reservationFive}
            };

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            tableFive = new Table(5, 4);
            tableSix = new Table(6, 6);
            Table tableSeven = new Table(7, 10);
            tables = new Dictionary<int, Table>
            {
                {5, tableFive },
                { 6, tableSix},
                { 7, tableSeven}
            };
            reservationFive = new Reservation
            {
                Number = 5,
                DateTime = new DateTime(2023, 04, 04),
                TableNumber = 5
            };
            reservationSix = new Reservation(new DateTime(2023, 04, 04), 5);
            reservationSix.Number = 6;
            Reservation reservationSeven = new Reservation(new DateTime(2023, 01, 10), 7);
            reservationSeven.Number = 7;
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive },
                { 6, reservationSix},
                { 7, reservationSeven}
            };
            quantity = 10;
            date = new DateTime(2023, 04, 04);
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            tableFive = new Table(5, 8);
            tables = new Dictionary<int, Table>
            {
                {5, tableFive }
            };
            reservationFive = new Reservation
            {
                Number = 5,
                DateTime = new DateTime(2023, 07, 07),
                TableNumber = 5
            };
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive }
            };
            quantity = 9;
            date = new DateTime(2023, 07, 07);
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            tableFive = new Table();
            tables = new Dictionary<int, Table>
            {
                {5, tableFive }
            };
            reservationFive = new Reservation
            {
                Number = 5,
                DateTime = new DateTime(2023, 09, 09),
                TableNumber = 5
            };
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive }
            };
            quantity = 4;
            date = new DateTime(2023, 09, 09);
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            tableFive = new Table(5, 10);
            tables = new Dictionary<int, Table>
            {
                {5, tableFive }
            };
            reservationFive = new Reservation();
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive }
            };
            quantity = 6;
            date = new DateTime(2023, 10, 09);
            expectedReservation = new List<Reservation>();

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };

            tableFive = new Table(5, 6);
            tables = new Dictionary<int, Table>
            {
                {5, tableFive }
            };
            reservationFive = new Reservation(new DateTime(2023, 11, 03), 5);
            reservationFive.Number = 5;
            baseReservations = new Dictionary<int, Reservation>
            {
                {reservationFive.Number, reservationFive }
            };
            quantity = 4;
            date = new DateTime(2023, 11, 03);
            expectedReservation = new List<Reservation> { reservationFive };

            yield return new Object[] { baseReservations, tables, date, quantity, expectedReservation };
        }

        public static IEnumerable AddTableTestCaseSource()
        {
            Table tableOne = new Table(1, 5);
            Dictionary<int, Table> baseTables = new Dictionary<int, Table> { { 1, tableOne } };
            Table addTable = new Table(2, 5);
            Dictionary<int, Table> expectedTables = new Dictionary<int, Table>
            {
                { 1, tableOne },
                { 2, addTable }
             };
            bool expectedTablesBool = true;

            yield return new Object[] { baseTables, addTable, expectedTables, expectedTablesBool };

            addTable = new Table(1, 4);
            expectedTables = new Dictionary<int, Table>
            {
                { 1, tableOne }
             };
            expectedTablesBool = false;

            yield return new Object[] { baseTables, addTable, expectedTables, expectedTablesBool };

            baseTables = new Dictionary<int, Table>();
            addTable = new Table(21, 14);
            expectedTables = new Dictionary<int, Table>
            {
                { addTable.Number, addTable }
            };
            expectedTablesBool = true;

            yield return new Object[] { baseTables, addTable, expectedTables, expectedTablesBool };

            addTable = new Table();
            expectedTables = new Dictionary<int, Table>
            {
                { addTable.Number, addTable }
            };
            expectedTablesBool = true;

            yield return new Object[] { baseTables, addTable, expectedTables, expectedTablesBool };

            tableOne = new Table();
            baseTables = new Dictionary<int, Table> { { 1, tableOne } };
            addTable = new Table(3, 6);
            expectedTables = new Dictionary<int, Table>
            {
                { 1, tableOne },
                { addTable.Number, addTable }
            };
            expectedTablesBool = true;

            yield return new Object[] { baseTables, addTable, expectedTables, expectedTablesBool };
        }

        public static IEnumerable RemoveTableTestCaseSource()
        {
            Table tableOne = new Table(10, 6);
            Table tableTwo = new Table(5, 4);
            Dictionary<int, Table> baseTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne},
                { tableTwo.Number, tableTwo},
            };
            int numberRemoveTable = tableTwo.Number;
            Dictionary<int, Table> expectedTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            bool expectedTablesBool = true;

            yield return new Object[] { baseTable, numberRemoveTable, expectedTable, expectedTablesBool };

            baseTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            numberRemoveTable = tableOne.Number;
            expectedTable = new Dictionary<int, Table>();

            yield return new Object[] { baseTable, numberRemoveTable, expectedTable, expectedTablesBool };

            tableOne = new Table();

            yield return new Object[] { baseTable, numberRemoveTable, expectedTable, expectedTablesBool };

            tableOne = new Table(9, 12);
            baseTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            numberRemoveTable = 2;
            expectedTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            expectedTablesBool = false;

            yield return new Object[] { baseTable, numberRemoveTable, expectedTable, expectedTablesBool };
        }
    }
}
