using MicroServices.FtpUserIsolation.FtpUserIsolationService.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FtpWebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassFtpUserIsolation objClassFtpUserIsolation = new ClassFtpUserIsolation();
            objClassFtpUserIsolation.UserName = "FtpUser201";
            objClassFtpUserIsolation.Password = "12345678";
            objClassFtpUserIsolation.RootFolderPath=@"D:\TestFtpSite5\LocalUser";
            objClassFtpUserIsolation.FolderName = "FtpUser201";

            string result = string.Empty;
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                result = client.UploadString("http://localhost:62483/FtpUserIsolationServiceWcfIISHost.svc/SetNewFtpUser", "POST", JsonConvert.SerializeObject(objClassFtpUserIsolation));
            }
        }
    }
}