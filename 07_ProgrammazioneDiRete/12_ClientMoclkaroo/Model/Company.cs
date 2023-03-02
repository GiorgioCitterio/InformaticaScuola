namespace _12_ClientMoclkaroo.Model
{

    public class Company
    {   
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Revenue { get; set; }
        public Headquarter? Headquarter { get; set; }
        public Location[]? Locations { get; set; }
    }

    public class Headquarter
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Location
    {
        public string? City { get; set; }
        public int Employee { get; set; }
        public string? State { get; set; }
    }
    
}
