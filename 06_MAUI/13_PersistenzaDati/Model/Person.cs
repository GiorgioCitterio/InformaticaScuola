using SQLite;

namespace _13_PersistenzaDati.Model
{
    [Table("People")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(120), Unique]
        public string Name { get; set; }
    }
}
