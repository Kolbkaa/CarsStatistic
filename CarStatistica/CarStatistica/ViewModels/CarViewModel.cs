using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;

namespace CarStatistica.ViewModels
{
    public class CarViewModel
    {
        [Display(Name = "Marka")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Brand { get; set; }

        [Display(Name = "Model")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Type { get; set; }

        [Display(Name = "Aktualny przebieg")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public int StartMileage { get; set; }


        public Car GetCar()
        {
            return  new Car()
            {
                Brand = Brand,
                Type = Type,
                StartMileage = StartMileage
            };
        }
    }
}
