using SQLite;
using People.Models;

namespace People.Repository
{
    internal class PersonRepository
    {
        private SQLiteConnection conn;
        private string _dbPath; // Add this field to store the database path  

        public PersonRepository(string dbPath) // Add a constructor to initialize _dbPath  
        {
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Person>();
        }

        public void AddPerson(string name)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Nombre introducido no valido.");
                result = conn.Insert(new Person { Name = name });
            };
        }

        public List<Person> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Person>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Fallo al recibir información. {0}", ex.Message);
            }

            return new List<Person>();
        }
    }
}
