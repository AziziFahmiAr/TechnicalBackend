﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechnicalBackend.DBEntities;
using TechnicalBackend.Entity;
using TechnicalBackend.Models;

namespace TechnicalBackend.Service
{
    public interface ITTDeveloperService
    {
        List<TTDeveloperGetAllModel> getAllData();
        TTDeveloperGetDetailModel getDataDetails(int Id);
        TTDeveloperGetDetailModel saveData(TTDeveloperRequestModel data);
        TTDeveloperGetDetailModel updateData(TTDeveloperGetDetailModel data);
        string deleteData(int Id);
    }

    public class TTDeveloperService : ITTDeveloperService
    {
        readonly DBContext Db = new();
        public IMapper Mapper { get; set; }

        public TTDeveloperService(DBContext dbContext)
        {
            Db = dbContext;
        }

        public string deleteData(int Id)
        {
            var del = GetDataWithID(Id);
            bool res = false;
            if (del != null)
            {
                DeleteHobbiesData(Id);
                DeleteSkillData(Id);
                Db.TTDeveloper.Remove(del);
                if (Db.SaveChanges() != 0)
                {
                    res = true;
                }
            }

            if (res)
            {
                return $"Data with ID {Id} has been successfully deleted";
            }
            return "Deleting data got issue";
        }


        public List<TTDeveloperGetAllModel> getAllData()
        {
            List<TTDeveloperGetAllModel> res = new List<TTDeveloperGetAllModel>();
            var ttDev = Db.TTDeveloper.AsNoTracking().ToList();
            if (ttDev != null)
            {
                foreach(var x in ttDev)
                {
                    TTDeveloperGetAllModel model = new TTDeveloperGetAllModel();
                    model.Id = x.Id;
                    model.Name = x.Name;
                    model.Telephone = x.Telephone;
                    model.Email = x.Email;
                    model.City = x.City;
                    model.lastUpdate = x.lastUpdate;
                    model.Hobbies = GetAllHobbyData(model.Id);
                    model.Skills = GetAllSkillsData(model.Id);
                    res.Add(model);
                }
            }
            return res;
        }

        public TTDeveloperGetDetailModel getDataDetails(int Id)
        {
            TTDeveloperGetDetailModel res = new TTDeveloperGetDetailModel();
            var data = GetDataWithID(Id);
            if(data != null)
            {
                res.Id = data.Id;
                res.Name = data.Name;
                res.Telephone = data.Telephone;
                res.Email = data.Email;
                res.City = data.City;
                res.Address1 = data.Address1;
                res.Address2 = data.Address2;
                res.Address3 = data.Address3;
                res.Postcode= data.Postcode;
                res.lastUpdate = data.lastUpdate;
                res.Hobbies = GetAllHobbyData(res.Id);
                res.Skills = GetAllSkillsData(res.Id);
            }
            return res;
        }

        public TTDeveloperGetDetailModel saveData(TTDeveloperRequestModel res)
        {
            TTDeveloper devData = new TTDeveloper
            {
                Id = 0,
                Name = res.Name,
                Telephone = res.Telephone,
                Email = res.Email,
                City = res.City,
                Address1 = res.Address1,
                Address2 = res.Address2,
                Address3 = res.Address3,
                Postcode = res.Postcode,
                lastUpdate = res.lastUpdate,
            };
            var data = SaveData(devData);

            TTDeveloperGetDetailModel model = new TTDeveloperGetDetailModel();
            model.Id = data.Id;
            model.Name = data.Name;
            model.Email = data.Email;
            model.Telephone = data.Telephone;
            model.City = data.City;
            model.Address1 = data.Address1;
            model.Address2 = data.Address2;
            model.Address3 = data.Address3;
            model.Postcode = data.Postcode;
            model.lastUpdate = data.lastUpdate;

            if (res.Hobbies != null)
            {
                foreach (var h in res.Hobbies)
                {
                    TTDeveloperHobbies hobi = new TTDeveloperHobbies
                    {
                        Hobby = h.Hobby,
                        TTDeveloperr = data,
                        Id = 0
                    };
                    var hobby = SaveHobbiesData(hobi);
                    try
                    {
                        model.Hobbies.Add(hobby);
                    }
                    catch {
                        continue;
                    }
                }
            }

            if (res.Skills != null)
            {
                foreach (var s in res.Skills)
                {
                    TTDeveloperSkills skil = new TTDeveloperSkills
                    {
                        Id = 0,
                        TTDeveloperr = data,
                        Skill = s.Skill,
                        Year_of_experience = s.Year_of_experience,
                        Level = s.Level
                    };
                    var skill = SaveSkillData(skil);
                    try
                    {
                        model.Skills.Add(skill);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }

            return model;
        }

        public TTDeveloperGetDetailModel updateData(TTDeveloperGetDetailModel res)
        {
            TTDeveloper devData = new TTDeveloper
            {
                Id = res.Id,
                Name = res.Name,
                Telephone = res.Telephone,
                Email = res.Email,
                City = res.City,
                Address1 = res.Address1,
                Address2 = res.Address2,
                Address3 = res.Address3,
                Postcode = res.Postcode,
                lastUpdate = res.lastUpdate
            };
            var data = updateData(devData);

            TTDeveloperGetDetailModel model = new TTDeveloperGetDetailModel();
            model.Id = data.Id;
            model.Name = data.Name;
            model.Email = data.Email;
            model.Telephone = data.Telephone;
            model.City = data.City;
            model.Address1 = data.Address1;
            model.Address2 = data.Address2;
            model.Address3 = data.Address3;
            model.Postcode = data.Postcode;
            model.lastUpdate = data.lastUpdate;

            if (res.Hobbies != null)
            {
                foreach (var h in res.Hobbies)
                {
                    var hobby = UpdateHobbiesData(h);
                    try
                    {
                        model.Hobbies.Add(hobby);
                    }
                    catch {
                        continue;
                    }
                }
            }

            if (res.Skills != null)
            {
                foreach (var s in res.Skills)
                {
                    var skill = UpdateSkillData(s);
                    try
                    {
                        model.Skills.Add(skill);
                    }
                    catch { continue; }
                }
            }

            return model;
        }

        #region Private Method
        private TTDeveloper GetDataWithID(int ID)
        {
            return Db.TTDeveloper.Find(ID);
        }
        private TTDeveloper SaveData(TTDeveloper tTDeveloper)
        {
            Db.TTDeveloper.Add(tTDeveloper);
            Db.SaveChanges();
            
            return tTDeveloper;
        }

        public TTDeveloperHobbies SaveHobbiesData(TTDeveloperHobbies tTDeveloperHobbies)
        {
            Db.TTDeveloperHobbies.Add(tTDeveloperHobbies);
            Db.SaveChanges();
            
            return tTDeveloperHobbies;
        }

        public TTDeveloperSkills SaveSkillData(TTDeveloperSkills tTDeveloperSkill)
        {
            Db.TTDeveloperSkills.Add(tTDeveloperSkill);
            Db.SaveChanges();
            
            return tTDeveloperSkill;
        }

        private TTDeveloper updateData(TTDeveloper tTDeveloper)
        {
            Db.Entry(tTDeveloper).State = EntityState.Modified;
            Db.SaveChanges();

            return tTDeveloper;
        }

        public TTDeveloperHobbies UpdateHobbiesData(TTDeveloperHobbies tTDeveloperHobbies)
        {
            Db.Entry(tTDeveloperHobbies).State = EntityState.Modified;
            Db.SaveChanges();

            return tTDeveloperHobbies;
        }

        public TTDeveloperSkills UpdateSkillData(TTDeveloperSkills tTDeveloperSkill)
        {
            Db.Entry(tTDeveloperSkill).State = EntityState.Modified;
            Db.SaveChanges();

            return tTDeveloperSkill;
        }

        private List<TTDeveloperHobbies> GetAllHobbyData(int Id)
        {
            return Db.TTDeveloperHobbies.AsNoTracking().Where(x => x.TTDeveloperr.Id == Id).ToList();
        }

        private List<TTDeveloperSkills> GetAllSkillsData(int Id)
        {
            return Db.TTDeveloperSkills.AsNoTracking().Where(x => x.TTDeveloperr.Id == Id).ToList();
        }

        private void DeleteHobbiesData(int ID)
        {
            var dev = GetAllHobbyData(ID);

            if (dev != null)
            {
                foreach (var dh in dev)
                {
                    Db.TTDeveloperHobbies.Remove(dh);
                    Db.SaveChanges();
                }
            }
        }

        private void DeleteSkillData(int ID)
        {
            var dev = GetAllSkillsData(ID);
            if (dev != null)
            {
                foreach (var ds in dev)
                {
                    Db.TTDeveloperSkills.Remove(ds);
                    Db.SaveChanges();
                }

            }
        }
        #endregion
    }
}
