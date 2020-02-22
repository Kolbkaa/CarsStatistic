using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;

namespace CarStatistica.Data
{
    public interface IRepository <T>
    { 
        Task<bool> Add(T model);
        Task<Car> Get(int carId, User user);
        Task<List<Car>> GetAll(User user);

        Task<bool> Delete(int carId, User user);
    }
}
