using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampNameApi.Services
{
    public interface INameService
    {
        bool isValid(string name);
    }
}
