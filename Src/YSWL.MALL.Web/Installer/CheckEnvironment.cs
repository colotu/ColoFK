using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Data.Sql;
using System.Data;

namespace YSWL.Web.Installer
{
    public class CheckEnvironment
    {
        public static bool CheckFileSystem()
        {
            return false;
        }

        public static bool DoCheckFileSystem(string path)
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                return false;
            }
            try
            {
                string fileName = HttpContext.Current.Server.MapPath(path + "/test.htm");
                File.WriteAllBytes(fileName, System.Text.Encoding.ASCII.GetBytes("OK"));
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //if (!isDir && !File.Exists(HttpContext.Current.Server.MapPath(path)))
            //{
            //    return false;
            //}
            //List<FileSystemRights> res = new List<FileSystemRights>();
            //res = isDir ? GetDirPermission2(path) : GetFilePermission2(path);

            //foreach (FileSystemRights item in res)
            //{
            //    if ((item & FileSystemRights.Read) == FileSystemRights.Read &&
            //        (item & FileSystemRights.Write) == FileSystemRights.Write)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        /// <summary>
        /// 获取当前用户的文件夹的读写权限
        /// </summary>
        /// <param name="path"></param>
        /// <returns>权限对应字符串</returns>
        public static List<string> GetDirPermission(string path)
        {
            List<string> res = new List<string>();
            List<FileSystemRights> res2 = GetDirPermission2(path);
            foreach (FileSystemRights item in res2)
            {
                res.Add(item.ToString());
            }
            return res;
        }
        /// <summary>
        /// 获取当前用户的文件夹的读写权限2
        /// </summary>
        /// <param name="path">权限集合</param>
        /// <returns></returns>
        public static List<FileSystemRights> GetDirPermission2(string path)
        {
            DirectorySecurity fsec = Directory.GetAccessControl(HttpContext.Current.Server.MapPath(path), AccessControlSections.Access);

            AuthorizationRuleCollection rules = fsec.GetAccessRules(true, true, typeof(SecurityIdentifier));
            List<FileSystemRights> res = new List<FileSystemRights>();
            for (int i = 0; i < rules.Count; i++)
            {
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                FileSystemAccessRule r = (FileSystemAccessRule)rules[i];
                if (wi.Owner.Value == r.IdentityReference.Value)
                    res.Add(r.FileSystemRights);
            }
            res = res.Distinct().ToList();
            return res;
        }


        /// <summary>
        /// 获取当前用户的文件的读写权限
        /// </summary>
        /// <param name="path"></param>
        /// <returns>权限对应字符串</returns>
        public static List<string> GetFilePermission(string path)
        {
            List<string> res = new List<string>();
            List<FileSystemRights> res2 = GetFilePermission2(path);
            foreach (FileSystemRights item in res2)
            {
                res.Add(item.ToString());
            }
            return res;
        }
        /// <summary>
        /// 获取当前用户的文件的读写权限2
        /// </summary>
        /// <param name="path">权限集合</param>
        /// <returns></returns>
        public static List<FileSystemRights> GetFilePermission2(string path)
        {
            FileSecurity fsec = File.GetAccessControl(HttpContext.Current.Server.MapPath(path), AccessControlSections.Access);

            AuthorizationRuleCollection rules = fsec.GetAccessRules(true, true, typeof(SecurityIdentifier));
            List<FileSystemRights> res = new List<FileSystemRights>();
            for (int i = 0; i < rules.Count; i++)
            {
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                FileSystemAccessRule r = (FileSystemAccessRule)rules[i];
                if (wi.Owner.Value == r.IdentityReference.Value)
                    res.Add(r.FileSystemRights);
            }
            res = res.Distinct().ToList();
            return res;
        }
        /// <summary>
        /// 获取sql Server 的版本号
        /// </summary>
        /// <returns></returns>
        public static List<string> GetSqlServer()
        {
            SqlDataSourceEnumerator sqldatasourceenumerator1 = SqlDataSourceEnumerator.Instance;
            DataTable datatable1 = sqldatasourceenumerator1.GetDataSources();
            List<string> list = new List<string>();
            foreach (DataRow row in datatable1.Rows)
            {
                if (row["ServerName"].ToString() == "SERVER")
                {
                    list.Add(row["Version"].ToString());
                }
            }
            return list;
        }
        /// <summary>
        /// 检查SQL server数据库是否为 2005 以上
        /// </summary>
        public static bool CheckSqlServerVersion()
        {
            List<string> list = GetSqlServer();
            if (list.Exists(c => c.StartsWith("9.00") || c.StartsWith("10") || c.StartsWith("11")))
            {
                return true;
            }
            return false;
        }
    }
}
