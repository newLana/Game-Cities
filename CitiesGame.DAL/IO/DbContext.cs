using CitiesGame.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CitiesGame.DAL.IO
{
    public class DbContext
    {
        public IEnumerable<City> Cities { get; } 

        public DbContext()
        {
            Cities = GetCitiesFromFile();
        }
        
        private static IEnumerable<City> GetCitiesFromFile()
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data/db.txt";
            if (File.Exists(path))
            {
                string resultStr = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    resultStr = reader.ReadToEnd();
                }
                return resultStr.Split('\n').Select(s => new City { Name = s }).ToArray();
            }
            return Enumerable.Empty<City>();
        }
    }
}
