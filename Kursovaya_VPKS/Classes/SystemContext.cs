using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_VPKS.Classes
{
    static class SystemContext
    {
        public static Users User { get; set; } = null;
        public static string isGuest { get; set; } = "No";
        public static Items Item { get; set; } = null;
        public static string isChange { get; set; } = "No";
    }
}
