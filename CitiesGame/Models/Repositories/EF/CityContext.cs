using CitiesGame.Models.Entities;
using System.Data.Entity;

namespace CitiesGame.Models.Repositories.EF
{
    public class CityContext:DbContext
    {
        public CityContext():base("Default")
        { }

        public DbSet<City> Cities { get; set; }
    }
}