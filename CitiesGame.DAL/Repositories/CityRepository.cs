using CitiesGame.DAL.Entities;
using CitiesGame.DAL.Interfaces;
using CitiesGame.DAL.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesGame.DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private DbContext db = new DbContext();

        public bool Contains(string city)
        {
            return db.Cities.Any<City>(c => string.Equals(c.Name, city, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities;
        }
    }
}
