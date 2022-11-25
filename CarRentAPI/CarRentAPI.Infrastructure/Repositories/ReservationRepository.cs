﻿using CarRentAPI.Domain.Entities;
using CarRentAPI.Domain.Interfaces;
using CarRentAPI.Infrastructure.DbData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarRentDbContext context;

        public ReservationRepository(CarRentDbContext _context)
        {
            context = _context;
        }

        public void Delete(Reservation entity)
        {
            context.Reservations.Remove(entity);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return context.Reservations.ToList();
        }

        public Reservation GetByCarId(int carId)
        {
            return context.Reservations.Where(res => res.ReservedCar.Id == carId).FirstOrDefault();
        }

        public Reservation GetById(int entityId)
        {
            return context.Reservations.Find(entityId);
        }

        public void Insert(Reservation entity)
        {
            context.Reservations.Add(entity);
        }

        public void Update(Reservation entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}