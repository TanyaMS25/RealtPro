using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtProWpfApp.Entities
{
    public partial class Client
    {
        public string FullName
        {
            get
            {
                var fullName = $"{LastName} {FirstName}";

                if (string.IsNullOrWhiteSpace(Patronymic) == false)
                {
                    fullName += $" {Patronymic}";
                }

                return fullName;
            }
        }
        public string BackgroundColor
        {
            get
            {
                return (ObjectStatusId == 1) ? "#DDF7DF" : "White";
            }
        }
    }
}
