using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BdMarketWebApp.Utility
{
    public class FTPFileUpload
    {
        string userName = "user_name";
        string password = "password";

        public string UploadProductPicture(IFormFile picture, string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                picture.CopyTo(ms);

                byte[] data = ms.ToArray();

                WebClient webClient = new WebClient();

                string ftpAddress = "ftp://ecom.somee.com/www.ecom.somee.com/Pictures/";
                webClient.Credentials = new NetworkCredential(userName, password);
                webClient.UploadData(ftpAddress + fileName, data);
                webClient.Dispose();

                return "1";
            }
            catch (Exception ep)
            {
                return ep.ToString();
            }
        }

        public string UploadEmployeeProfilePicture(IFormFile picture, string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                picture.CopyTo(ms);

                byte[] data = ms.ToArray();

                WebClient webClient = new WebClient();

                string ftpAddress = "ftp://ecom.somee.com/www.ecom.somee.com/EmployeeProfile/";
                webClient.Credentials = new NetworkCredential(userName, password);
                webClient.UploadData(ftpAddress + fileName, data);
                webClient.Dispose();

                return "1";
            }
            catch (Exception ep)
            {
                return ep.ToString();
            }
        }
    }
}
