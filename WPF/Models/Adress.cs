using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF.Models
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? StreetAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string? City { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string? ZipCode { get; set; }
    }
}