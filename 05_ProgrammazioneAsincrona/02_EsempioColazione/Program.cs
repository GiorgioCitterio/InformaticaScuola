using System.Diagnostics;

namespace _02_EsempioColazione
{
    internal class Bacon { }
    internal class Egg { }
    internal class Coffee { }
    internal class Juice { }
    internal class Toast { }
    internal class Program
    {
        static void Main(string[] args)
        {
            //ColazioneSincrona();
            ColazioneParallela();
        }
        private static void ColazioneParallela()
        {
            //in questo esempio ci sono alcune attività che sono svolte in parallelo
            //e alcune attività che sono svolte in maniera sincrona
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Coffee c = PreparaCaffe(); //attività sincrona
            Console.WriteLine("il caffè è pronto");
            Task<List<Egg>> uova = Task.Factory.StartNew(() => FriggiUova(2));
            Task<List<Bacon>> bacon = Task.Factory.StartNew(() => FriggiBacon(3));
            Task<List<Toast>> toast = Task.Factory.StartNew(() => TostoIlPane(2));
            //vado a spalmare la marmellata sul pane (dopo che il toast sia pronto)
            toast.Wait();
            SpalmaBurro(toast); //attività sincrona
            SpalmaMarmellata(toast); //attività sincrona
            Console.WriteLine("il toast è pronto");
            Juice spremuta = PreparaSpremuta();//attività sincrona
            Console.WriteLine("la spremuta è pronta");
            //quando tutto è pronto la colazione è pronta (aspetto che tutti abbiano finito)
            Task.WaitAll(uova, bacon);
            Console.WriteLine("le uova sono pronte");
            Console.WriteLine("il bacon è pronto");
            Console.WriteLine("La colazione è pronta!");
            sw.Stop();
            Console.WriteLine($"Il tempo per la colazione parallela è { sw.ElapsedMilliseconds} ms");
        }
        private static void ColazioneSincrona()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Coffee cup = PreparaCaffe();
            Console.WriteLine("il caffè è pronto");
            List<Egg> eggs = FriggiUova(2);
            Console.WriteLine("le uova sono pronte");
            List<Bacon> bacon = FriggiBacon(3);
            Console.WriteLine("il bacon è pronto");
            List<Toast> toast = TostoIlPane(2);
            //SpalmaBurro(toast);
            //SpalmaMarmellata(toast);
            Console.WriteLine("il toast è pronto");
            Juice oj = PreparaSpremuta();
            Console.WriteLine("la spremuta è pronta");
            Console.WriteLine("La colazione è pronta");
            sw.Stop();
            Console.WriteLine($"Il tempo per la colazione sincrona è {sw.ElapsedMilliseconds} ms");
        }
        private static Coffee PreparaCaffe()
        {
            Console.WriteLine("sto iniziando a preparare il caffè");
            Task.Delay(1000).Wait();
            return new Coffee();
        }
        private static List<Egg> FriggiUova(int v)
        {
            Console.WriteLine($"Sto iniziando a friggere {v} uova");
            List<Egg> uova = new List<Egg>();
            for (int i = 0; i < v; i++)
            {
            Task.Delay(200).Wait();
                uova.Add(new Egg());
            }
            return uova;
        }
        private static List<Bacon> FriggiBacon(int v)
        {
            Console.WriteLine($"Sto iniziando a friggere {v} fette di pancetta");

            List<Bacon> fetteDiPancetta = new List<Bacon>();
            for (int i = 0; i < v; i++)
            {
                Task.Delay(200).Wait();
                fetteDiPancetta.Add(new Bacon());
            }
            return fetteDiPancetta;
        }
        private static List<Toast> TostoIlPane(int v)
        {
            Console.WriteLine($"Sto iniziando a tostare {v} fette di pane");
            List<Toast> toasts = new List<Toast>();
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine($"\tTosto la {i + 1}-ma fetta");
                Task.Delay(200).Wait();
                toasts.Add(new Toast());
            }
            return toasts;
        }
        private static void SpalmaBurro(Task<List<Toast>> toast)
        {
            Console.WriteLine("Sto iniziando a spalmare il burro ");
            for (int i = 0; i < toast.Result.Count; i++)
            {
                Task.Delay(300).Wait();
                Console.WriteLine($"\tSto spalmando il burro sulla {i + 1}-ma fetta ");
            }
        }
        private static void SpalmaMarmellata(Task<List<Toast>> toast)
        {
            Console.WriteLine("Sto iniziando a spalmare la marlellata ");
            for (int i = 0; i < toast.Result.Count; i++)
            {
                Task.Delay(500).Wait();
                Console.WriteLine($"\tSto spalmando la marmellata sulla {i + 1}-ma fetta");
            }
        }
        private static Juice PreparaSpremuta()
        {
            Console.WriteLine("Sto iniziando a spremere le arance");
            Task.Delay(1000).Wait();
            return new Juice();
        }
    }
}