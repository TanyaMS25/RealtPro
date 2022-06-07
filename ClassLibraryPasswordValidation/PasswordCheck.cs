using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPasswordValidation
{
    public class PasswordCheck
    {
        /// <summary>
        /// метод проверки корректности пароля
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool CheckPassword(string pass)
        {
            if(pass != null)
            {
                if (pass.Length < 6 || pass.Length > 50)
                    return false;
                if (!pass.Any(Char.IsDigit))
                    return false;
                if (!pass.Any(Char.IsLetter))
                    return false;
                if (pass.All(Char.IsDigit))
                    return false;
                if (pass.All(Char.IsLetter))
                    return false;
                if (pass.Intersect("#$%^&_№:").Count() > 0)
                    return false;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
