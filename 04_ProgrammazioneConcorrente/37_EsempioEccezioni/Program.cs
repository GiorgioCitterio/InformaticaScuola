namespace _37_EsempioEccezioni
{
    public class CustomException : Exception
    {
        public CustomException(String message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var task1 = Task.Run(() =>
            {
                throw new CustomException("This exception is expected!");
            });
            try
            {
                task1.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    // Handle the custom exception.
                    if (e is CustomException)
                    {
                        Console.WriteLine(e.Message);
                    }
                    // Rethrow any other exception.
                    else
                    {
                        throw;
                    }
                }
            }
        }   
    }
}