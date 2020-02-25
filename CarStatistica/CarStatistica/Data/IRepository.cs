using CarStatistica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStatistica.Data
{
    public interface IRepository<T>
    {
        Task<bool> Add(T model);
        Task<Car> Get(int carId, User user);
        Task<List<Car>> GetAll(User user);

        Task<bool> Delete(int carId, User user);
    }
}
