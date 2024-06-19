using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalBackend.Entity
{
    public class TTDeveloperSkills
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public virtual TTDeveloper? TTDeveloperr { get; set; }
        public string Skill { get; set; }
        public int Level { get; set; }
        public int Year_of_exp { get; set; }
    }
}
