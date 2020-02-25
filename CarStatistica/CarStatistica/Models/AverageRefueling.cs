using System;
using System.ComponentModel.DataAnnotations;

namespace CarStatistica.Models
{
    public class AverageRefueling
    {

        public AverageRefueling(decimal value, decimal cost, int mileage, DateTime date, string comments, decimal average)
        {
            Value = value;
            Cost = cost;
            Mileage = mileage;
            Date = date;
            Comments = comments;
            Average = average;
        }

        [Display(Name = "Ilość paliwa")]
        public decimal Value { get; }

        [Display(Name = "Koszt")]
        public decimal Cost { get; }


        [Display(Name = "Przebieg")]
        public int Mileage { get; }

        [Display(Name = "Data tankowania")]
        public DateTime Date { get; }


        [Display(Name = "Uwagi")]
        public string Comments { get; }
        [Display(Name = "Średnie spalanie")]
        public decimal Average { get; }

    }
}
