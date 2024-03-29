﻿using CarRentAPI.Domain.Entities;

namespace CarRentAPI.Application.DTO
{
    public class RentDetailsDTO
    {
        public Car Car { get; set; }
        public RentRequest UserInput { get; set; }
        public string Location { get; set; }
        public float EndPrice { get; set; }
        public float FuelPrice { get; set; }
        public float NetPrice => EndPrice * (1 - 0.23f);
        public bool CanRent { get; set; }
        public string CanRentMessage { get; set; }
        public DateTime? ReservedUntil { get; set; }
        
    }
}
