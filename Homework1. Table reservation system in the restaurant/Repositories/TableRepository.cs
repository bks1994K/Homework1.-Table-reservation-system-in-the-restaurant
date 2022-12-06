using System.Text.Json;

namespace Homework1._Table_reservation_system_in_the_restaurant.Repositories
{
    public class TableRepository
    {
                
        private Dictionary<int, Table> _tables;

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

        public void AddTable(Table table)
        {
            Dictionary<int, Table> tables = LoadAll();
            tables.Add(table.Number, table);
            SaveAll(tables);
        }

        public bool RemoveTable(int numberTable)
        {
            Dictionary<int, Table> tables = LoadAll();
            if(tables.Remove(numberTable))
            {
                SaveAll(tables);
                return true;
            }
            return false;
        }

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
            if (_tables is null)
            {
                if (File.Exists(Path))
                {
                    using (StreamReader sr = new StreamReader(Path))
                    {
                        string jsn = sr.ReadLine();
                        Dictionary<int, Table> tables = JsonSerializer.Deserialize<Dictionary<int, Table>>(jsn)!;
                        _tables = tables;
                    }
                }
                else
                {
                    _tables = new Dictionary<int, Table>();
                }
            }
            return _tables;
        }
    }
}
