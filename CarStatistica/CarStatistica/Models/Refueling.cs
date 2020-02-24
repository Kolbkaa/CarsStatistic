using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarStatistica.Models
{
    public class Refueling
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Ilość paliwa")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Tylko wartości dodatnie")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Koszt")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Tylko wartości dodatnie")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Przebieg")]
        [Range(0,Int32.MaxValue,ErrorMessage = "Tylko wartości dodatnie")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [Display(Name = "Data tankowania")]
        public DateTime Date { get; set; }


        [Display(Name = "Uwagi")]
        public string Comments { get; set; }
        [NotMapped]
        [Display(Name = "Cena")]
        public decimal Price => Cost != 0 ? (Cost / Value) : 0;


        public int CostsId { get; set; }
        public Costs Costs { get; set; }


    }
}
