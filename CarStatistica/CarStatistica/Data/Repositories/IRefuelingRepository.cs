using CarStatistica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStatistica.Data.Repositories
{
    public interface IRefuelingRepository<T>
    {
        Task<bool> Add(T model, int carId, User user);
        Task<List<Refueling>> GetAll(int carId, User user);

        Task<bool> Delete(int refuelingId, int carId, User user);

        Task<bool> IsRefuelingGoodOrder(T model, int carId, User user);
    }
}
