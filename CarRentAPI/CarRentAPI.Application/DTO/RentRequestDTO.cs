﻿
namespace CarRentAPI.Application.DTO
{
    public class RentRequestDTO
    {
        public int Range { get; set; }
        public DateTime DriverLicenseYear { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
