using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;
using Microsoft.AspNetCore.Identity;

namespace CarStatistica.Data
{
    public class User:IdentityUser
    {
        public User(string userName):base(userName:userName)
        {
            
        }


        public ICollection<Car> Cars { get; set; }
    }
}
