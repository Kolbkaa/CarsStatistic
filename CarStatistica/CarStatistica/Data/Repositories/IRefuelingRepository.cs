using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;

namespace CarStatistica.Data.Repositories
{
    public interface IRefuelingRepository<T>
    {
        Task<bool> Add(T model, int carId, User user);
        Task<List<Refueling>> GetAll(int carId, User user);

        Task<bool> Delete(int refuelingId, int carId, User user);
    }
}
