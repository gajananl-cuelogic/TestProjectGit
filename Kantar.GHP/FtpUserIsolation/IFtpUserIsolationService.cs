using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using MicroServices.FtpUserIsolation.FtpUserIsolationService.Data;
namespace MicroServices.FtpUserIsolation.FtpUserIsolationService
{
    [ServiceContract()]
    interface IFtpUserIsolationService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "SetNewFtpUser")]
        string SetNewFtpUser(ClassFtpUserIsolation UserDetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "CreateUser")]
        string CreateUser(ClassFtpUserIsolation UserDetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "CreateGroup")]
        string CreateGroup(ClassFtpUserIsolation UserDetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "CreateFolder")]
        string CreateFolder(ClassFtpUserIsolation UserDetails);

        [OperationContract]
        [WebInvoke(Method = "POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         UriTemplate = "TestRequest")]
        string TestRequest();


        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //  RequestFormat = WebMessageFormat.Json,
        //  ResponseFormat = WebMessageFormat.Json,
        //  UriTemplate = "SetNewFtpUser/{UserName}/{Password}/{RootFolderPath}")]
        //string SetNewFtpUser(string UserName, string Password, string RootFolderPath);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        // RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json,
        // UriTemplate = "CreateUser/{UserName}/{Password}")]
        //string CreateUser(string UserName, string Password);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        // RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json,
        // UriTemplate = "CreateGroup/{GroupName}/{Password}")]
        //string CreateGroup(string GroupName, string Password);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        // RequestFormat = WebMessageFormat.Json,
        // ResponseFormat = WebMessageFormat.Json,
        // UriTemplate = "CreateFolder/{RootFolderPath}/{FolderName}")]
        //string CreateFolder(string RootFolderPath, string FolderName);

        //[OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json,
        //UriTemplate = "TestRequest")]
        //string TestRequest();
    }
}
