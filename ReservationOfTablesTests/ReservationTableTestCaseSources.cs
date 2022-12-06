using Homework1._Table_reservation_system_in_the_restaurant;
using System.Collections;
using System.Collections.Generic;

namespace ReservationSystemInRestaurantTests
{
    public static class TableRepositoryTestCaseSources
    {
        public static IEnumerable AddTableTestSource()
        {
            Table table = new Table(1, 4);
            Dictionary<int, Table> baseTables = new Dictionary<int, Table> { { table.Number, table } };
            Table addTable = new Table(2, 6);
            Dictionary<int, Table> expectedTables = new Dictionary<int, Table> { { table.Number, table }, { addTable.Number, addTable } };

            yield return new Object[] { baseTables, addTable, expectedTables };

            baseTables = new Dictionary<int, Table>();
            expectedTables = new Dictionary<int, Table> { { addTable.Number, addTable } };

            yield return new Object[] { baseTables, addTable, expectedTables };

            table = new Table();

            yield return new Object[] { baseTables, addTable, expectedTables };
        }

        public static IEnumerable RemoveTableTestSource()
        {
            Table tableOne = new Table(1, 4);
            Table tableTwo = new Table(2, 2);
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

            tableOne = new Table(3,10);
            baseTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            numberRemoveTable = 6;
            expectedTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne}
            };
            expectedTablesBool = false;

            yield return new Object[] { baseTable, numberRemoveTable, expectedTable, expectedTablesBool };
        }

        public static IEnumerable GetTableByNumberTestSource()
        {
            Table tableOne = new Table(1, 4);
            Table tableTwo = new Table(2, 2);
            Dictionary<int, Table> baseTable = new Dictionary<int, Table>
            {
                { tableOne.Number, tableOne},
                { tableTwo.Number, tableTwo},
            };
            int tableNumber = tableOne.Number;
            Table expectedTable = tableOne;

            yield return new Object[] { baseTable, tableNumber, expectedTable };

            Table table = new Table();
            baseTable = new Dictionary<int, Table> { { table.Number, table } };
            tableNumber = table.Number;
            expectedTable = table;

            yield return new Object[] { baseTable, tableNumber, expectedTable };
        }
    }
}

