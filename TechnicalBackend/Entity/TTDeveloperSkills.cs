using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TechnicalBackend.Entity
{
    public class TTDeveloperSkills
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual TTDeveloper? TTDeveloperr { get; set; }
        public string Skill { get; set; }
        public int Level { get; set; }
        public int Year_of_experience { get; set; }
    }
}
