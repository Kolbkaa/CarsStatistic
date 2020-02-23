using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStatistica.Data.Repositories
{
    public class RefuelingRepository : IRefuelingRepository<Refueling>
    {
        private readonly AppDbContext _appDbContext;
        public RefuelingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> Add(Refueling model, int carId, User user)
        {
            var car = await _appDbContext.Cars.Include(car => car.Costs).ThenInclude(costs => costs.Refuelings)
                .SingleAsync(car => car.Id == carId && car.User.Equals(user));

            car.Costs.Refuelings.Add(model);

            if (car.ActualMileage < model.Mileage)
                car.ActualMileage = model.Mileage;

            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Refueling>> GetAll(int carId, User user)
        {
            var list = await _appDbContext.Cars.Include(car => car.Costs).ThenInclude(costs => costs.Refuelings)
                .SingleAsync(x => x.Id == carId && x.User.Equals(user));
            return new List<Refueling>(list.Costs.Refuelings.OrderByDescending(x=>x.Mileage));
        }

        public async Task<bool> Delete(int refuelingId, int carId, User user)
        {
            var refuelingToDelete = _appDbContext.Cars.Include(car => car.Costs).ThenInclude(costs => costs.Refuelings)
                .Single(car => car.Id == carId && car.User.Equals(user)).Costs.Refuelings.Single(refueling => refueling.Id == refuelingId);

            _appDbContext.Refuelings.Remove(refuelingToDelete);

            var result = await _appDbContext.SaveChangesAsync();
            return result == 1;
            
        }
    }
}
