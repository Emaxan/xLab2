namespace xLab2.Models
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class CityList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string smphoto { get; set; }
        public string bgphoto { get; set; }
        public string description { get; set; }
        public Coord coord { get; set; }
    }
}