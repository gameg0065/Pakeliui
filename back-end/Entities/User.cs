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
        // public string FirstName { get; set; }       // remove
        // public string LastName { get; set; }        // remove
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CreateDate { get; set; }      // rename to RegistrationDate
        public int CityID { get; set; }             // make it a string: Vilnius, Kaunas, etc
        public int CarID { get; set; }
        public string UserInfo { get; set; }
        public string DriverInfo { get; set; }         // Cia neaisku, kas yra. Turi buti objektas.
        // public int Rating { get; set; }             // remove
        public string FacebookLink { get; set; }
        public string PicturePath { get; set; }
        public bool IsDriver { get; set; }

        // add BirthDate (string)
        // add contactMethod (string): email, facebook, phone
        // change City - make string, not int
        // add Name(string): vartotojo vardas ir pavarde, stringas
        // rating - istrinti, pullinsim is Feebbacku
    }
}