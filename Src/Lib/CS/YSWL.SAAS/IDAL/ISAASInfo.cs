using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YSWL.SAAS.IDAL
{
    public interface ISAASInfo
    {
        #region  成员方法

        DataSet GetSAASUserInfo(string userName, byte[] encPassword, int userType = 1,  long enterpriseId = 0);

        string GetSysValue(string key);

        string GetBusinnessConStr(string applicationTag);

        bool IsDBExists();

        bool CreateSAASUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, int userType = 1, string applicationids = "",bool isCover=false);

        int IsExistsUser(string userName);

        bool IsExistsUserLink(int userId, int applicationId);

        bool SetPassword(string userName, byte[] encPassword);

        bool UpdateUser(string userName, byte[] encPassword, string trueName, string phone,
            long enterpriseId, bool activity);

        bool AppIsOpen(string tag, int enterpeiseId);

        string GetSystemValue(string Keyname);

        DataSet GetSAASEnterprises();

        int GetUserCounts(int usertype, long enterpriseId);

        int GetSAASEntIdByDomain(string domain);

        bool IsBuy(int applicationId, long enterpriseId);

        DateTime GetEndTime(int applicationId, long enterpriseId);

        DataSet GetOpenApps(long enterpriseId);

        #endregion  MethodEx
    }
}
