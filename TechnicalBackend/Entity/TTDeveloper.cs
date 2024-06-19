using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalBackend.Entity
{
    public class TTDeveloper
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set;}
        [Required]
        public int Postcode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public virtual List<TTDeveloperHobbies>? TTDeveloperHobbies { get; set; }
        [Required]
        public virtual List<TTDeveloperSkills>? TTDeveloperSkills { get; set; }
        [Required]
        public DateTime lastUpdate { get; set; }
    }
}
