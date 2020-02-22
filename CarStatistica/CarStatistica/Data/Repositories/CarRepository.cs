using CarStatistica.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStatistica.Data.Repositories
{
    public class CarRepository:ICarRepository<Car>
    {
        private readonly AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<bool> Add(Car model)
        {
            await _appDbContext.Cars.AddAsync(model);
            var result = await _appDbContext.SaveChangesAsync();

            return result == 1;
        }

        public async Task<Car> Get(int carId, User user)
        {
            return  await _appDbContext.Cars.SingleOrDefaultAsync(car => car.Id == carId && car.User.Equals(user));
        }

        public async Task<List<Car>> GetAll(User user)
        {
           return await _appDbContext.Cars.Where(car => car.User == user).ToListAsync();
        }

        public async Task<bool> Delete(int carId, User user)
        {
            var car = await Get(carId, user);
            _appDbContext.Cars.Remove(car);
            var result = await _appDbContext.SaveChangesAsync();

            return result == 1;
        }
    }
}
