using CitiesGame.Models.Entities;
using CitiesGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace CitiesGame.Models.Repositories.IO
{
    public class IoRepository : RepositoryBase
    {
        protected override IEnumerable<City> ReadAll()
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + "App_Data/db.txt";
            if (File.Exists(path))
            {
                string resultStr = "";
                using (var reader = new StreamReader(path, Encoding.Default))
                {
                    resultStr = reader.ReadToEnd();
                }
                return resultStr.Split(new char[] { '\r', '\n' },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => new City { Name = s }).ToArray();
            }
            return Enumerable.Empty<City>();
        }
    }
}