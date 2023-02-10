namespace _13_PersistenzaDati
{
    public class FileAccessHelper
    {
        public static string GetFileLocalPath(string dbname)
        {
            //percorso completo del databse
            return Path.Combine(FileSystem.AppDataDirectory, dbname);
        }
    }
}
