using System.Diagnostics;

namespace EsericizioPasso
{
    public class Info
    {
        public string nome { get; set; }
    }
    internal class Program
    {
        static SemaphoreSlim codaCasello = new SemaphoreSlim(2, 2);
        static void Casello(object nomeObj)
        {
            Info diocane = (Info)nomeObj;
            string nome = diocane.nome;
            Stopwatch crono = new Stopwatch();
            crono.Restart();
            Console.WriteLine("il camion {0} è in coda per il casello", nome);
            codaCasello.Wait();
            Task.Delay(2000).Wait();
            codaCasello.Release();
            Task.Delay(1000).Wait();
            crono.Stop();
            Console.WriteLine("il camion {0} è uscito dal casello e ci ha messo {1}", nome, crono.ElapsedMilliseconds);
        }
        static void Main(string[] args)
        {
            //5 Camion, percorrono una strada, e per passare devono arrivare ad un casello che li tiene occupati per 2s,
            //la coda del casello è di 2 camion, una volta passato il casello aspettano 1s
            //(questo delay è rappresentato dal tempo che ci impiega il camion ad arrivare), ed una volta arrivati alla loro
            //destinazione stampano il tempo che ci hanno messo. 
            //il numero di camion è variabile, quindi l'esercizio senza modifche deve funzionare con 5-10-20 camion e via cosi
            Task[] truppaDiCamion = new Task[20];
            for (int i = 0; i < truppaDiCamion.Length; i++)
            {
                truppaDiCamion[i] = Task.Factory.StartNew(Casello, new Info { nome = "camion " + i });
            }
            Task.WaitAll(truppaDiCamion);
        }
    }
}