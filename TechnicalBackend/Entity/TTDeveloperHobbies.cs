using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalBackend.Entity
{
    public class TTDeveloperHobbies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual TTDeveloper? TTDeveloperr { get; set; }
        [Required]
        public string Hobby { get; set; }
    }
}
