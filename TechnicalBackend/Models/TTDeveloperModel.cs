using TechnicalBackend.Entity;

namespace TechnicalBackend.Models
{
    public class TTDeveloperModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public DateTime lastUpdate { get; set; }

    }

    public class TTDeveloperInsertModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public DateTime lastUpdate { get; set; }

    }

    public class TTDeveloperHobbiesModel
    {
        public string Hobby { get; set; }
    }

    public class TTDeveloperSkillsModel
    {
        public string Skill { get; set; }
        public int Level { get; set; }
        public int Year_of_experience { get; set; }
    }

    public class TTDeveloperGetAllModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string City { get; set; }
        public DateTime lastUpdate { get; set; }
        public virtual List<TTDeveloperHobbies> Hobbies { get; set;}
        public virtual List<TTDeveloperSkills> Skills { get; set;}

    }

    public class TTDeveloperGetDetailModel : TTDeveloperModel
    {
        public virtual List<TTDeveloperHobbies>? Hobbies { get; set; }
        public virtual List<TTDeveloperSkills>? Skills { get; set; }
    }

    public class TTDeveloperRequestModel : TTDeveloperInsertModel
    {
        public virtual List<TTDeveloperHobbiesModel> Hobbies { get; set; }
        public virtual List<TTDeveloperSkillsModel> Skills { get; set; }
    }

    public struct levelString
    {
        public const string BEGINNER = "BEGINNER";
        public const string INTERMEDIATE = "INTERMEDIATE";
        public const string ADVANCE = "ADVANCE";
    }
}
