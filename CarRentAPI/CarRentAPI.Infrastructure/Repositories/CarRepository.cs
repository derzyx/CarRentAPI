using CarRentAPI.Application.DTO;
using CarRentAPI.Application.Interfaces;
using CarRentAPI.Domain.Entities;
using CarRentAPI.Infrastructure.DbData;
using CarRentAPI.Infrastructure.Repositories.Generic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.Infrastructure.Repositories
{
    public class CarRepository : BasicDbOpsRepository<Car>
    {
        private readonly CarRentDbContext context;

        public CarRepository(CarRentDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
