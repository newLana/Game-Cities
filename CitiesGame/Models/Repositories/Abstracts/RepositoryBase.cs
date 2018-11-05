using CitiesGame.Models.Entities;
using CitiesGame.Models.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitiesGame.Models.Repositories
{
    public abstract class RepositoryBase:IRepository<City>
    {
        protected static IEnumerable<City> cities;

        public bool Contains(string item)
        {
            return GetAll().Any(i => i.Name == item);
        }

        public IEnumerable<City> GetAll()
        {
            if(cities == null)
            {
                cities = ReadAll();
            }
            return cities;
        }

        protected abstract IEnumerable<City> ReadAll();
    }
}