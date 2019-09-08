using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BdMarketWebApp.Utility
{
    public class BootstrapMessages
    {
        public static string Success(string message)
        {
            return
                "<div class=\"alert alert-success alert-dismissible\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button><strong>Success!</strong>"+message+"</div>";
        }

        public static string Failed(string message)
        {
            return
                "<div class=\"alert alert-danger alert-dismissible\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button><strong>Failed!</strong>" + message + "</div>";
        }

        public static string Warning(string message)
        {
            return
                "<div class=\"alert alert-warning alert-dismissible\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button><strong>Failed!</strong>" + message + "</div>";
        }
    }
}
