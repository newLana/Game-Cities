using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesGame.Models.Interfaces
{
    interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        bool Contains(string item);
    }
}
