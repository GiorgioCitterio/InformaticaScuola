using _13_PersistenzaDati.Model;
using SQLite;

namespace _13_PersistenzaDati
{
    public class PersonRepository
    {
        string _dbPath;
        private SQLiteAsyncConnection connection; //istanza connessione
        public string StatusMessage { get; private set; }

        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath; //percorso
        }

        public async Task Init()
        {
            if(connection != null) //se la connessione esiste già non faccio niente
            {
                return;
            }
            connection = new SQLiteAsyncConnection(_dbPath); //se no creo la connessione
            await connection.CreateTableAsync<Person>(); //crea la tabella se non esiste se no effettua solo la connessione
        }

        public async Task AddPerson(string name) //aggiungo persona al db
        {
            int result = default;
            try
            {
                await Init(); //chiamo l'initi
                if(string.IsNullOrEmpty(name)) //se non inserisco niente eccezione
                {
                    throw new Exception("Name is null");
                }
                result = await connection.InsertAsync(new Person() { Name = name});
                //inserisce l'oggetto e incrementa la chiave primaria se presente
                //se va a buon fine restituisce le righe aggiunte alla tabella (1)
                //se non va a buon fine restituisce 0
                StatusMessage = $"Inserito {name} e db restituisce {result}";
            }
            catch (Exception e)
            {
                StatusMessage = $"Errore inserimento {name} e db restituisce {result} con eccezione {e.Message}";
            }
        }

        public async Task<List<Person>> GetAllPeople()
        {
            try
            {
                await Init(); //mi aggancio al db
                var lista = await connection.Table<Person>().ToListAsync(); //va nella tabella e restituisce una lista di persone
                //connection.DeleteAsync(persona); rimuove la persona passata utilizzando la chiave primaria
                return lista; //se funziona ritorno la lista
            }
            catch (Exception e)
            {
                StatusMessage = $"Errore recupero persone: {e.Message}";
            }
            return new List<Person>(); // se non funziona ritorno una lista vuota
        }
    }
}
