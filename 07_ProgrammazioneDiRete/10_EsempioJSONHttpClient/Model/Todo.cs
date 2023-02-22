namespace _10_EsempioJSONHttpClient.Model
{
    public class Todo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public bool completed { get; set; }

        public override string? ToString()
        {
            return userId + " " + id + " " + title + " " + completed;
        }
    }
}
