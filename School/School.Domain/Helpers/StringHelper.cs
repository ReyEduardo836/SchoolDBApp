using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Helpers
{
    public class StringHelper
    {
        public static bool Wspaces(string[] campos)
        {
            var validacion = campos.Where(x => string.IsNullOrWhiteSpace(x));
            return validacion.Count() > 0;
        }
    }
}
