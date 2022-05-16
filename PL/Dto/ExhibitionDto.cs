namespace PL
{
    public class ExhibitionDto
    {
        public string? name { get; set; }
        public string? description { get; set; }
        public double price { get; set; }
        public int numberOfVisitors { get; set; }
        public DateTime beginning { get; set; }
        public DateTime end { get; set; }
    }
}
