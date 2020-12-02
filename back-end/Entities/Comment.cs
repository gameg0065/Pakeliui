using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Comment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Index(IsUnique = true)]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TravelID { get; set; }       // rename to PostID
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}