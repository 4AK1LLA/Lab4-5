namespace DAL.Entities
{
    public class Exhibition
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int NumberOfVisitors { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
    }
}