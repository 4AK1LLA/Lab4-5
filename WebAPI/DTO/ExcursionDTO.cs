﻿namespace WebAPI.DTO
{
    public class ExcursionDTO
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public DateTime Time { get; set; }
        public bool IsReserved { get; set; }
    }
}
