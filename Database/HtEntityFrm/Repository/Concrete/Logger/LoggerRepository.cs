﻿using System.Data.Entity;
using System.Linq;
using EntityFrameworkDomain.Context.Interfaces;
using EntityFrameworkDomain.Repository.Interfaces.Logger;
using HardTrainingPoco.POCO.Logger;

namespace EntityFrameworkDomain.Repository.Concrete.Logger
{
    public class LoggerRepository : ILoggerRepo
    {
        private readonly IHardTrainingContext _db;

        public LoggerRepository(IHardTrainingContext loggerContext)
        {
            this._db = loggerContext;
        }

        public IQueryable<Profile> GetProfiles()
        {
            return this._db.Profiles;
        }

        public bool IsExistProfile(int id)
        {
            var profile = this._db.Profiles.FirstOrDefault(p => p.Id == id);
            if (profile == null)
            {
                return false;
            }

            return true;
        }

        public bool IsExistProfile(string login, string password)
        {
            var profile = this._db.Profiles.FirstOrDefault(p => p.Name == login && p.Password == password);
            if (profile == null)
            {
                return false;
            }

            return true;
        }

        public void AddProfile(Profile profile)
        {
            if (profile != null)
            {
                this._db.Profiles.Add(profile);
            }
        }

        public void DeleteProfile(Profile profile)
        {
            if (profile != null)
            {
                this._db.Profiles.Remove(profile);
            }
        }

        public void UpdateProfile(Profile profile)
        {
            if (this.IsExistProfile(profile.Id))
            {
                this._db.Entry(profile).State = EntityState.Modified;
            }
        }

        public void SaveChanges()
        {
            this._db.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
