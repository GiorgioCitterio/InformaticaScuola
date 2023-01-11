namespace _19_EsempioTaskFactory
{
    class CustomData
    {
        public long CreationTime;
        public int Name;
        public int ThreadNum;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((object? obj) =>
                {
                    //istruzioni task
                    //CustomData? data = obj as CustomData;
                    CustomData data = new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks };
                    if (data == null)
                        return;
                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                    Console.WriteLine("nome: " + data.Name + "\t" + "tempo: " + data.CreationTime);
                    //}, new CustomData() { Name = i, CreationTime = DateTime.Now.Ticks }); //parametro
                }, i);
            }
            Task.WaitAll(taskArray);
            foreach (var task in taskArray)
            {
                //var data = task.AsyncState as CustomData; //restituisce l'oggetto passato
                var data = task.AsyncState as int?;
                if (data != null)
                {
                    //Console.WriteLine("id: " + data.ThreadNum + "\t" + "tempo: " + data.CreationTime + "\t"
                    //+ "nome: " + data.Name + "\t" + "stato: " + task.Status);
                    Console.WriteLine("id: " + task.Id + "\t" + "oggetto passato: " 
                        + data + "\t" + task.Status);
                }
            }
        }
    }
}