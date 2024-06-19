using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TechnicalBackend.DBEntities;
using TechnicalBackend.Entity;

namespace TechnicalBackend.Repositories
{
    public interface ITTDeveloperRepository
    {
        TTDeveloper GetDataWithID(Guid ID);
        List<TTDeveloper> GetAllData();
        TTDeveloper SaveData(TTDeveloper tTDeveloper);
        bool DeleteData(Guid ID);
        TTDeveloperHobbies GetHobbyDataWithID(Guid ID);
        List<TTDeveloperHobbies> GetAllHobbyData(Guid Id);
        TTDeveloperHobbies SaveHobbiesData(TTDeveloperHobbies tTDeveloperHobbies);
        void DeleteHobbiesData(Guid ID);
        TTDeveloperSkills GetSkillsDataWithID(Guid ID);
        List<TTDeveloperSkills> GetAllSkillsData(Guid Id);
        TTDeveloperSkills SaveSkillData(TTDeveloperSkills tTDeveloperSkill);
        void DeleteSkillData(Guid ID);

    }

    public class TTDeveloperRepository : ITTDeveloperRepository
    {
        readonly DBContext Db = new();

        public TTDeveloperRepository(DBContext dbContext)
        {
            Db = dbContext;
        }

        public bool DeleteData(Guid ID)
        {
            var dev = GetDataWithID(ID);
            bool res = false;
            if (dev != null)
            {
                Db.Set<TTDeveloper>().Remove(dev);
                if (Db.SaveChanges() != 0)
                {
                    DeleteHobbiesData(ID);
                    DeleteSkillData(ID);
                    res = true;
                }
            }
            return res;
        }

        public void DeleteHobbiesData(Guid ID)
        {
            var dev = GetAllHobbyData(ID);
            
            if (dev != null)
            {
                foreach (var dh in dev)
                {
                    Db.Set<TTDeveloperHobbies>().Remove(dh);
                    Db.SaveChanges();
                } 
            }
        }

        public void DeleteSkillData(Guid ID)
        {
            var dev = GetAllSkillsData(ID);
            if (dev != null)
            {
                foreach (var ds in dev)
                {
                    Db.Set<TTDeveloperSkills>().Remove(ds);
                    Db.SaveChanges();
                }
                
            }
        }

        public List<TTDeveloper> GetAllData()
        {
            return Db.Set<TTDeveloper>().ToList();
        }

        public List<TTDeveloperHobbies> GetAllHobbyData(Guid Id)
        {
            return Db.Set<TTDeveloperHobbies>().Where(x => x.TTDeveloperr.Id == Id).ToList();
        }

        public List<TTDeveloperSkills> GetAllSkillsData(Guid Id)
        {
            return Db.Set<TTDeveloperSkills>().Where(x => x.TTDeveloperr.Id == Id).ToList();
        }

        public TTDeveloper GetDataWithID(Guid ID)
        {
            return Db.Set<TTDeveloper>().Find(ID);
        }

        public TTDeveloperHobbies GetHobbyDataWithID(Guid ID)
        {
            return Db.Set<TTDeveloperHobbies>().Find(ID);
        }

        public TTDeveloperSkills GetSkillsDataWithID(Guid ID)
        {
            return Db.Set<TTDeveloperSkills>().Find(ID);
        }

        public TTDeveloper SaveData(TTDeveloper tTDeveloper)
        {
            if(tTDeveloper.Id == null)
            {
                Db.Set<TTDeveloper>().Add(tTDeveloper);
                Db.SaveChanges();
            }
            else
            {
                Db.Entry(tTDeveloper).State = EntityState.Modified;
                Db.SaveChanges();
            }
            return tTDeveloper;
        }

        public TTDeveloperHobbies SaveHobbiesData(TTDeveloperHobbies tTDeveloperHobbies)
        {
            if (tTDeveloperHobbies.Id == null)
            {
                Db.Set<TTDeveloperHobbies>().Add(tTDeveloperHobbies);
                Db.SaveChanges();
            }
            else
            {
                Db.Entry(tTDeveloperHobbies).State = EntityState.Modified;
                Db.SaveChanges();
            }
            return tTDeveloperHobbies;
        }

        public TTDeveloperSkills SaveSkillData(TTDeveloperSkills tTDeveloperSkill)
        {
            if (tTDeveloperSkill.Id == null)
            {
                Db.Set<TTDeveloperSkills>().Add(tTDeveloperSkill);
                Db.SaveChanges();
            }
            else
            {
                Db.Entry(tTDeveloperSkill).State = EntityState.Modified;
                Db.SaveChanges();
            }
            return tTDeveloperSkill;
        }
    }
}
