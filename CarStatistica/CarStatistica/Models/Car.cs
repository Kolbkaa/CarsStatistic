using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarStatistica.Data;

namespace CarStatistica.Models
{
    public class Car
    {
        private int _id;
        private string _brand;
        private string _type;
        private int _actualMileage;

        public Car()
        {
            CreateDate = DateTime.Now;
        }

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                ChangeEditDate();
            } 
        }
        [Display(Name = "Marka")]
        public string Brand
        {
            get => _brand;
            set
            {
                _brand = value;
                ChangeEditDate();
            }
        }
        [Display(Name = "Model")]
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                ChangeEditDate();
            }
        }
        [Display(Name = "Przebieg startowy")]
        public int StartMileage { get; set; }
        [Display(Name = "Aktualny przebieg")]
        public int ActualMileage
        {
            get => _actualMileage;
            set
            {
                _actualMileage = value;
                ChangeEditDate();
            }
        }
        [Display(Name = "Data utworzenia")]
        public DateTime CreateDate { get; }
        [Display(Name = "Ostatnia data edycji")]
        public DateTime LastEdit { get; private set; }

        public User User { get; set; }
        private void ChangeEditDate()
        {
            LastEdit = DateTime.Now;
        }
    }
}
