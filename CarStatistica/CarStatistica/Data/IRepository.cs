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
        Task<List<Car>> GetAll(User user);
    }
}
