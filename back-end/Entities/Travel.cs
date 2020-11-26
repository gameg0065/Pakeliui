using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class Travel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]    public int ID { get; set; }
        public int DriverID { get; set; }
        public int CarID { get; set; }
        public int FromCityID { get; set; }
        public int ToCityID { get; set; }
        public DateTime TravelDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsCanceled { get; set; }
        public bool TwoPassengersBackseat { get; set; }
        public int Price { get; set; }
        public string TravelInfo { get; set; }
        public int MaxPassengerNo { get; set; }
    }
}