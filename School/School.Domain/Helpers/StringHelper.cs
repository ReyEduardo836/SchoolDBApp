using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace School.Domain.Helpers
{
    public class StringHelper
    {
        public static bool Wspaces(string[] campos)
        {
            var validacion = campos.Where(x => string.IsNullOrWhiteSpace(x));
            return validacion.Count() > 0;
        }

        public static string ValidateEstudiantes(string[] campos)
        {
            int n;
            if (!int.TryParse(campos[6], out n))
            {
                return $"Escriba un formato valido en los campos";
            }
            if (!int.TryParse(campos[7], out n))
            {
                return $"Escriba un formato valido en los campos";
            }
            if (!int.TryParse(campos[8], out n))
            {
                return $"Escriba un formato valido en los campos";
            }
            if (!int.TryParse(campos[9], out n))
            {
                return $"Escriba un formato valido en los campos";
            }
            return "";
        }
    }
}
