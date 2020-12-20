using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Post
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public int Price { get; set; }
        public int seetCount { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Info { get; set; }
        public double Distance { get; set; }
        public string IntermediateCities { get; set; }
        public string Dropoff { get; set; }
        public string TravelFrom { get; set; }
        public string TravelTo { get; set; }
        public string Pickup { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<Reservation> Passengers { get; set; }
        public List<Comment> Comments { get; set; }
    }
}