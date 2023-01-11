//La parola chiave await consente di iniziare un'attività senza alcun blocco e
//di continuare l'esecuzione al completamento dell'attività
using System.Diagnostics;

namespace _03_EsempioColazioneAsincrona
{
    internal class Bacon { }
    internal class Egg { }
    internal class Coffee { }
    internal class Juice { }
    internal class Toast { }
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ColazioneAsincrona(); //devo mettere la parola chiave await per chiamarlo
        }
        private static async Task ColazioneAsincrona() //metodo lanciato in asincrono
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Coffee c = PreparaCaffe();
            #region teoria spiegazione
            //un metodo asincrono restituisce un Task
            //Il task può non restituire nulla, nel caso di azione asincrona (operazione che
            //non restituisce alcun valore al chiamante)
            //oppure può restituire un oggetto, come ad esempio nel caso di una lista di Egg o di Bacon
            //ci sono due modi di utilizzare un metodo asincrono:
            //1) aspettare il completamento del task restituito dal metodo asincrono, come nel caso di:
            //Task<List<Egg>> eggs = FryEggsAsync(2);
            //2) aspettare in maniera asincrona direttamente il risultato del task, come nel caso di
            //List<Toast> toast = await MakeToastWithButterAndJamAsync();
            //in questo secondo caso si utilizza la keyword await, che vuol dire asyncronous wait.
            //con l'utilizzo della keyword await dopo il segno di = si ottiene non un Task,
            //ma direttamente il valore restituito
            //dal task, se esiste, oppure si attende la fine del task se questo non restituisce nessun valore
            #endregion
            List<Egg> uova = await FriggiUovaAsync(2);
            Task<List<Bacon>> bacon = FriggiBaconAsync(3);
            List<Toast> toast = await PrepararaToastConBurroeMarmellataAsync(2); //prende il risultato che mi da il task
            await bacon;
            Console.WriteLine("il bacon è pronto");
            //await uova;
            Console.WriteLine("le uova sono pronte");
            Console.WriteLine("il toast è pronto");
            Juice spremuta = PreparaSpremuta();
            Console.WriteLine("la spremuta è pronta");
            //quando tutto è pronto la colazione è pronta
            Console.WriteLine("La colazione è pronta!");
            sw.Stop();
            Console.WriteLine($"Il tempo per la colazione asincrona è { sw.ElapsedMilliseconds} ms");
        }
        private static Coffee PreparaCaffe()
        {
            Console.WriteLine("sto iniziando a preparare il caffè");
            Task.Delay(1000).Wait();
            return new Coffee();
        }
        private static async Task<List<Egg>> FriggiUovaAsync(int v)
        {
            Console.WriteLine($"Sto iniziando a friggere {v} uova");
            List<Egg> uova = new List<Egg>();
            for (int i = 0; i < v; i++)
            {
                await Task.Delay(200);
                uova.Add(new Egg());
            }
            return uova;
        }
        private static async Task<List<Bacon>> FriggiBaconAsync(int v)
        {
            Console.WriteLine($"Sto iniziando a friggere {v} fette di pancetta");

            List<Bacon> fetteDiPancetta = new List<Bacon>();
            for (int i = 0; i < v; i++)
            {
                await Task.Delay(200);
                fetteDiPancetta.Add(new Bacon());
            }
            return fetteDiPancetta;
        }
        private static async Task<List<Toast>> ToastBreadAsync(int v)
        {
            Console.WriteLine($"Sto iniziando a tostare {v} fette di pane");
            List<Toast> toasts = new List<Toast>();
            for (int i = 0; i < v; i++)
            {
                Console.WriteLine($"\tTosto la {i + 1}-ma fetta");
                await Task.Delay(200);
                toasts.Add(new Toast());
            }
            return toasts;
        }
        private static void SpalmaBurro(List<Toast> toast)
        {
            Console.WriteLine("Sto iniziando a spalmare il burro ");
            for (int i = 0; i < toast.Count; i++)
            {
                Task.Delay(300).Wait();
                Console.WriteLine($"\tSto spalmando il burro sulla {i + 1}-ma fetta ");
            }
        }
        private static void SpalmaMarmellata(List<Toast> toast)
        {
            Console.WriteLine("Sto iniziando a spalmare la marlellata ");
            for (int i = 0; i < toast.Count; i++)
            {
                Task.Delay(500).Wait();
                Console.WriteLine($"\tSto spalmando la marmellata sulla {i + 1}-ma fetta");
            }
        }
        private static async Task<List<Toast>> PrepararaToastConBurroeMarmellataAsync(int v)
        {
            List<Toast> toast = await ToastBreadAsync(v); //aspetta che finisca e prende la lista
            //await toast;
            SpalmaBurro(toast);//attività sincrona
            SpalmaMarmellata(toast);//attività sincrona
            return toast;
        }
        private static Juice PreparaSpremuta()
        {
            Console.WriteLine("Sto iniziando a spremere le arance");
            Task.Delay(1000).Wait();
            return new Juice();
        }
    }
}