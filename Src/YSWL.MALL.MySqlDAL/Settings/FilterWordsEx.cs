/**
* FilterWordsEx.cs
*
* 功 能： [N/A]
* 类 名： FilterWordsEx
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/8/24 11:27:26  Rock    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System.Data;
using System.Text;
using YSWL.DBUtility;

namespace YSWL.MALL.MySqlDAL.Settings
{
    public partial class FilterWords
    {
        public DataSet GetForbidWords()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  FilterId,WordPattern,IsForbid,IsMod,RepalceWord ");
            strSql.Append(" FROM SA_FilterWords");
            strSql.Append(" WHERE IsForbid=1");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetModWords()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  FilterId,WordPattern,IsForbid,IsMod,RepalceWord ");
            strSql.Append(" FROM SA_FilterWords");
            strSql.Append(" WHERE IsMod=1");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public DataSet GetReplaceWords()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  FilterId,WordPattern,IsForbid,IsMod,RepalceWord ");
            strSql.Append(" FROM SA_FilterWords");
            strSql.Append(" WHERE  IsForbid=0 and IsMod=0");
            return DbHelperMySQL.Query(strSql.ToString());
        }
    }
}