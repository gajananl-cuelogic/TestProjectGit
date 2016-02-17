using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MicroServices.FtpUserIsolation.FtpUserIsolationService.Data;

namespace MicroServices.FtpUserIsolation.FtpUserIsolationService 
{
    public class FtpUserIsolationService : IFtpUserIsolationService
    {




        #region Create New User with Ftp Root Folder
        public string SetNewFtpUser(ClassFtpUserIsolation UserDetails)
        {
            CreateUser(UserDetails);
            CreateFolder(UserDetails);
            return "Success";
        }
        #endregion

        #region Create New User
        public string CreateUser(ClassFtpUserIsolation UserDetails)
        {

            var ad1 = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry NewUser = ad1.Children.Add(UserDetails.UserName, "user");

            bool IsUserExist = false;
            try
            {
                if ((ad1.Children.Find(UserDetails.UserName)) != null && (ad1.Children.Find(UserDetails.UserName)).SchemaClassName == "User")
                {
                    IsUserExist = true;
                }
            }
            catch (Exception e)
            {
                IsUserExist = false;
            }

            if (!IsUserExist)
            {
                NewUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
                object obRet = NewUser.Invoke("SetPassword", UserDetails.Password);
                NewUser.CommitChanges();
            }
            return "Success";
        }
        #endregion

        #region Create New Group
        public string CreateGroup(ClassFtpUserIsolation UserDetails)
        {


            var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
            DirectoryEntry newGroup = ad.Children.Add(UserDetails.GroupName, "group");
            bool IsGroupExist = false;
            try
            {
                if ((ad.Children.Find(UserDetails.GroupName)) != null && (ad.Children.Find(UserDetails.GroupName)).SchemaClassName == "Group")
                {
                    IsGroupExist = true;
                }
            }
            catch (Exception e)
            {
                IsGroupExist = false;
            }

            if (!IsGroupExist)
            {
                newGroup.Invoke("Put", new object[] { "Description", "Test Group from .NET" });
                object obRet = newGroup.Invoke("SetPassword", UserDetails.Password);
                newGroup.CommitChanges();
            }

            return "Success";
        }
        #endregion

        #region Create New Folder
        public string CreateFolder(ClassFtpUserIsolation UserDetails)
        {
            string RootFolderPathOriginal = UserDetails.RootFolderPath.Replace(@"&", @"\") + "\\" + UserDetails.FolderName;

            if (!Directory.Exists(RootFolderPathOriginal))
            {
                DirectoryInfo di = Directory.CreateDirectory(RootFolderPathOriginal);
            }
            return "Success";

        }


        #endregion

        public string TestRequest()
        {
            return "suceess";
        }








        //#region Create New User with Ftp Root Folder
        //public string SetNewFtpUser(string UserName, string Password, string RootFolderPath)
        //{
        //    CreateUser(UserName, Password);
        //    CreateFolder(RootFolderPath, UserName);
        //    return "Success";
        //}
        //#endregion

        //#region Create New User
        //public string CreateUser(string UserName, string Password)
        //{

        //    var ad1 = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
        //    DirectoryEntry NewUser = ad1.Children.Add(UserName, "user");          

        //    bool IsUserExist = false;
        //    try
        //    {
        //        if ((ad1.Children.Find(UserName)) != null && (ad1.Children.Find(UserName)).SchemaClassName == "User")
        //        {
        //            IsUserExist = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        IsUserExist = false;
        //    }

        //    if (!IsUserExist)
        //    {
        //        NewUser.Invoke("Put", new object[] { "Description", "Test User from .NET" });
        //        object obRet = NewUser.Invoke("SetPassword", Password);
        //        NewUser.CommitChanges();
        //    }
        //    return "Success";
        //}
        //#endregion

        //#region Create New Group
        //public string CreateGroup(string GroupName, string Password)
        //{


        //    var ad = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
        //    DirectoryEntry newGroup = ad.Children.Add(GroupName, "group");
        //    bool IsGroupExist = false;
        //    try
        //    {
        //        if ((ad.Children.Find(GroupName)) != null && (ad.Children.Find(GroupName)).SchemaClassName == "Group")
        //        {
        //            IsGroupExist = true;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        IsGroupExist = false;
        //    }

        //    if (!IsGroupExist)
        //    {
        //        newGroup.Invoke("Put", new object[] { "Description", "Test Group from .NET" });
        //        object obRet = newGroup.Invoke("SetPassword", Password);
        //        newGroup.CommitChanges();
        //    }

        //    return "Success";
        //}
        //#endregion

        //#region Create New Folder
        //public string CreateFolder(string RootFolderPath, string FolderName)
        //{
        //  string  RootFolderPathOriginal= RootFolderPath.Replace(@"&", @"\")+"\\" + FolderName;

        //    if (!Directory.Exists(RootFolderPathOriginal))
        //    {
        //        DirectoryInfo di = Directory.CreateDirectory(RootFolderPathOriginal);
        //    }
        //    return "Success";

        //}


        //#endregion

        //public string TestRequest()
        //{
        //    return "suceess";
        //}
    }
}
