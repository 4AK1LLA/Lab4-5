namespace WebAPI.DTO
{
    public class ChangeExcursionDTO
    {
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; } = true;
    }
}
