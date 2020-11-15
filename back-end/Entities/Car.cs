using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Car
    {
        [Key]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public int Model { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string PicturePath { get; set; }
    }
}