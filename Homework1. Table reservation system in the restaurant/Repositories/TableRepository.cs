using System.Text.Json;

namespace Homework1._Table_reservation_system_in_the_restaurant.Repositories
{
    public class TableRepository
    {
        //private Dictionary<int, Table> _tables = new Dictionary<int, Table>();

        

        public string Path { get; set; }

        public TableRepository(string path)
        {
            Path = $"{path}Tables.txt";
        }

            //Path = @"C:\Users\Кристина\Desktop\MakeUPro\Коды\Tables.txt";

        public Dictionary<int, Table> GetTables()
        {
            Dictionary<int, Table> tables = LoadAll();
            return tables;
        }

        public Table GetTableByNumber(int tableNumber)
        {
            var tables = LoadAll();
            tables.TryGetValue(tableNumber, out Table value);
            return value;
        }

        //public void SaveTables(Dictionary<int, Table> tables)
        //{
        //    _tables = tables;
        //}

        public void AddTable(Table table)
        {
            Dictionary<int, Table> tables = LoadAll();
            tables.Add(table.Number, table);
            SaveAll(tables);
        }

        public void RemoveTable(int numberTable)
        {
            Dictionary<int, Table> tables = LoadAll();
            tables.Remove(numberTable);
            SaveAll(tables);
        }

        //    public void StreamWriterInFile()
        //{ 
        // StreamWriter sw = new StreamWriter(@"C:\Users\Кристина\Desktop\MakeUPro\Коды\Reservation", false);
        //sw.WriteLine("hhh");
        //sw.Close();
        //}

        private void SaveAll(Dictionary<int, Table> tables)
        {
            using (StreamWriter sw = new StreamWriter(Path))
            {
                string jsn = JsonSerializer.Serialize(tables);
                sw.WriteLine(jsn);
            }
        }

        private Dictionary<int, Table> LoadAll()
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    string jsn = sr.ReadLine();
                    Dictionary<int, Table> tables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn)!;
                    return tables;
                }
            }
            return new Dictionary<int, Table>();
        }
    }
}
