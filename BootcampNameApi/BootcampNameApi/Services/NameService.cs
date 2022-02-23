using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BootcampNameApi.Services
{
    public class NameService : INameService
    {
        public bool isValid(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }
    }
}
