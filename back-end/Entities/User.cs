using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{

    public class User
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateDate { get; set; }
        public int CityID { get; set; }
        public int CarID { get; set; }
        public string UserInfo { get; set; }
        public string DriverInfo { get; set; }
        public int Rating { get; set; }
        public string FacebookLink { get; set; }
        public string PicturePath { get; set; }
        public bool IsDriver { get; set; }

    }
}