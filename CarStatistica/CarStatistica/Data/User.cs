using CarStatistica.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CarStatistica.Data
{
    public class User : IdentityUser
    {
        public User(string userName) : base(userName: userName)
        {

        }


        public ICollection<Car> Cars { get; set; }
    }
}
