namespace _11_EsercizioPhoto.Model
{
    public class Photo
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? url { get; set; }
        public string? thumbnailUrl { get; set; }

        public override string? ToString()
        {
            return albumId + " " + id+" " + title + " " + url + " " + thumbnailUrl;
        }
    }
}
