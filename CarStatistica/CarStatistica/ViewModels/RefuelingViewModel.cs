using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Models;

namespace CarStatistica.ViewModels
{
    public class RefuelingViewModel
    {
        

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Ilość paliwa")]
        
        public decimal Value { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Koszt")]
        [DataType(DataType.Currency, ErrorMessage = "Nie prawidłowa wartość")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Przebieg")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Data tankowania")]
        [DataType(DataType.Date,ErrorMessage = "Nie prawidłowa wartość")]
        public DateTime Date { get; set; } = DateTime.Now;


        [Display(Name = "Uwagi")]
        public string Comments { get; set; }

        public Refueling GetRefueling()
        {
            return new Refueling() { Comments = Comments, Cost = Cost, Date = Date, Mileage = Mileage, Value = Value };
        }
    }
}
