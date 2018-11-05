using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesGame.Models.Repositories.Abstracts
{
    public interface IRepository<T>
    {
        bool Contains(string item);
        IEnumerable<T> GetAll();
    }
}
