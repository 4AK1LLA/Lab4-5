namespace DAL.Entities
{
    public class Excursion
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; }
    }
}