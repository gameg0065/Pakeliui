using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Car
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Date { get; set; }
        public string PicturePath { get; set; }
    }
}