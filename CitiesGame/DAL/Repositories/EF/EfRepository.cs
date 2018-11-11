using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CitiesGame.Models.Entities;

namespace CitiesGame.Models.Repositories.EF
{
    public class EfRepository : RepositoryBase
    {
        static CityContext context = new CityContext();

        protected override IEnumerable<City> ReadAll()
        {
            return context.Cities.ToList();
        }
    }
}