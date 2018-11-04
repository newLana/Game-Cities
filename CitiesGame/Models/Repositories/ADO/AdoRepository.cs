using CitiesGame.Models.Entities;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace CitiesGame.Models.Repositories.ADO
{
    public class AdoRepository : RepositoryBase
    {
        string connectionString = ConfigurationManager.ConnectionStrings["Default"]
            .ConnectionString;

        protected override IEnumerable<City> ReadAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                ICollection<City> _cities = new List<City>();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Name FROM Cities";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        _cities.Add(new City
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
                return _cities;
            }
        }
    }
}