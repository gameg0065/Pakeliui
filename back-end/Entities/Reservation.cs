using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Reservation
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public int PassengerID { get; set; }
        public int TravelID { get; set; }
        public bool IsVerified { get; set; }
        public bool IsCanceled { get; set; }
        public string ReservationInfo { get; set; }
        public DateTime ReservationDate { get; set; }
        public int PassengerRating { get; set; }
        public int DriverRating { get; set; }
    }
}