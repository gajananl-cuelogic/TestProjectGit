using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;


namespace MicroServices.FtpUserIsolation.FtpUserIsolationService.Data
{
    [DataContract]
    public class ClassFtpUserIsolation
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string GroupName { get; set; }
        [DataMember]
        public string RootFolderPath { get; set; }
        [DataMember]
        public string FolderName { get; set; }
    }
   
}
