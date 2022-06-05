using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RealtProWpfApp.Models
{
    class Manager
    {
        public static Frame MainFrame { get; set; }
        public static Entities.User user { get; set; }
        public static Entities.Admin admin { get; set; }
        public static Entities.Realtor realtor { get; set; }
        public static Entities.HeadOfSalesDepartment headOfSales { get; set; }
    }
}
