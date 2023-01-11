namespace _24_TaskConEccezione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() =>
            {
                DateTime dat = DateTime.Now;
                if (dat == DateTime.MinValue)
                    throw new ArgumentException("The clock is not working.");
                if (dat.Hour > 17)
                    return "evening";
                else if (dat.Hour > 12)
                    return "afternoon";
                else
                    return "morning";
            });
            var c = t.ContinueWith((antecedent) =>
            {
                if (antecedent.Status == TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("Good {0}!",
                    antecedent.Result);
                    Console.WriteLine("And how are you this fine {0}?",
                    antecedent.Result);
                }
                else if (antecedent.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine(t.Exception.GetBaseException().Message);
                    }
            });
            c.Wait();
        }
    }
}