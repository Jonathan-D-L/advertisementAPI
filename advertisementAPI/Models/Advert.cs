namespace advertisementAPI.Models
{
    public class Advert
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? Img { get; set; }
        public string? Description { get; set; }
        public string? CallToAction { get; set; }
        public int Clicks { get; set; }
    }
}
