using _13_PersistenzaDati.Model;
using SQLite;

namespace _13_PersistenzaDati
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection connection;

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task Init()
        {
            if(connection != null)
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath);
            await connection.CreateTableAsync<Person>();
        }

        public async Task AddPerson(string name)
        {
            int result;
            try
            {
                await Init();
                if(string.IsNullOrEmpty(name))
                {
                    throw new Exception("Name is null");
                }
                result = await connection.InsertAsync(new Person() { Name = name});
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
