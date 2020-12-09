using System;
using System.Collections.Generic;
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
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string City { get; set; }
        public string ContactMethod { get; set; }
        public string UserInfo { get; set; }
        public string DriverInfo { get; set; }
        public string FacebookLink { get; set; }
        public string PicturePath { get; set; }
        public bool IsDriver { get; set; }
        public string AboutDriver { get; set; }
        public string DriverContactMethod { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
        public List<Post> Posts { get; set; }
        public List<Feedback> Feedbacks { get; set; }

    }
}