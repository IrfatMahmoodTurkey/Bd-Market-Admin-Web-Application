using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Utility
{
    public static class ActionAttributes
    {
        public static string ActionInsert { get; set; }
        public static string ActionUpdate { get; set; }
        public static string ActionRemove { get; set; }

        static ActionAttributes()
        {
            ActionInsert = "INSERTED";
            ActionUpdate = "UPDATED";
            ActionRemove = "REMOVED";
        }
    }
}
