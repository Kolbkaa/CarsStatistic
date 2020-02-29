using CarStatistica.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var car = await _appDbContext.Cars.Include(car => car.Refuelings)
                .SingleAsync(car => car.Id == carId && car.User.Equals(user));



            car.Refuelings.Add(model);

            if (car.ActualMileage < model.Mileage)
                car.ActualMileage = model.Mileage;

            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Refueling>> GetAll(int carId, User user)
        {
            var list = await _appDbContext.Cars.Include(car => car.Refuelings)
                .SingleAsync(x => x.Id == carId && x.User.Equals(user));
            return new List<Refueling>(list.Refuelings.OrderByDescending(x => x.Mileage));
        }

        public async Task<bool> Delete(int refuelingId, int carId, User user)
        {
            var refuelingToDelete = _appDbContext.Cars.Include(car => car.Refuelings)
                .Single(car => car.Id == carId && car.User.Equals(user)).Refuelings.Single(refueling => refueling.Id == refuelingId);

            _appDbContext.Refuelings.Remove(refuelingToDelete);

            var result = await _appDbContext.SaveChangesAsync();
            return result == 1;

        }

        public async Task<bool> IsRefuelingGoodOrder(Refueling model, int carId, User user)
        {
            var refuelingCount = _appDbContext.Cars.Include(car => car.Refuelings).SingleOrDefault(car => car.Id == carId && car.User.Equals(user))?.Refuelings.Count;

            if (refuelingCount == 0)
                return true;

            var earlierRefueling = await _appDbContext?.Refuelings?.Include(x => x.Car)
                ?.Where(car => car.Car.Id == carId && car.Car.User.Equals(user))?.Where(x => x.Mileage <= model.Mileage)
                ?.OrderByDescending(x => x.Mileage)?.FirstOrDefaultAsync();

            if (earlierRefueling != null)
                if (earlierRefueling.Date > model.Date)
                    return false;


            var laterRefueling = await _appDbContext?.Refuelings?.Include(x => x.Car)
                ?.Where(car => car.Car.Id == carId && car.Car.User.Equals(user))?.Where(x => x.Mileage >= model.Mileage)
                ?.OrderBy(x => x.Mileage)?.FirstOrDefaultAsync();

            if (laterRefueling != null)
                if (laterRefueling.Date < model.Date)
                    return false;


            return true;
        }
    }
}
