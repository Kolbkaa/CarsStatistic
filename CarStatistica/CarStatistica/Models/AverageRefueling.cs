using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace CarStatistica.Models
{
    public class AverageRefueling
    {

        public AverageRefueling(decimal value,decimal cost,int mileage,DateTime date, string comments, decimal average)
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

        public decimal Average { get; }

    }
}
