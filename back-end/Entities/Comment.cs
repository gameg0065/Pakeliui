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
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
    }
}