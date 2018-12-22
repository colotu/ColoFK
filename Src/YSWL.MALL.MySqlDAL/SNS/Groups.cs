/**
* Groups.cs
*
* 功 能： N/A
* 类 名： Groups
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:42   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
    /// <summary>
    /// 数据访问类:Groups
    /// </summary>
    public partial class Groups : IGroups
    {
        public Groups()
        { }
        #region  BasicMethod



        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GroupName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SNS_Groups");
            strSql.Append(" where GroupName=?GroupName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50)
            };
            parameters[0].Value = GroupName;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string GroupName, int groupId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SNS_Groups");
            strSql.Append(" where GroupName=?GroupName and groupId <>?GroupId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?GroupId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupName;
            parameters[1].Value = groupId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.SNS.Groups model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_Groups(");
            strSql.Append("GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags)");
            strSql.Append(" values (");
            strSql.Append("?GroupName,?GroupDescription,?GroupUserCount,?CreatedUserId,?CreatedNickName,?CreatedDate,?GroupLogo,?GroupLogoThumb,?GroupBackground,?ApplyGroupReason,?IsRecommand,?TopicCount,?TopicReplyCount,?Status,?Sequence,?Privacy,?Tags)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?GroupDescription", MySqlDbType.VarChar),
                    new MySqlParameter("?GroupUserCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?GroupLogo", MySqlDbType.VarChar,200),
                    new MySqlParameter("?GroupLogoThumb", MySqlDbType.VarChar,200),
                    new MySqlParameter("?GroupBackground", MySqlDbType.VarChar,200),
                    new MySqlParameter("?ApplyGroupReason", MySqlDbType.VarChar),
                    new MySqlParameter("?IsRecommand", MySqlDbType.Int32,4),
                    new MySqlParameter("?TopicCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?TopicReplyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
                    new MySqlParameter("?Tags", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.GroupDescription;
            parameters[2].Value = model.GroupUserCount;
            parameters[3].Value = model.CreatedUserId;
            parameters[4].Value = model.CreatedNickName;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.GroupLogo;
            parameters[7].Value = model.GroupLogoThumb;
            parameters[8].Value = model.GroupBackground;
            parameters[9].Value = model.ApplyGroupReason;
            parameters[10].Value = model.IsRecommand;
            parameters[11].Value = model.TopicCount;
            parameters[12].Value = model.TopicReplyCount;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.Sequence;
            parameters[15].Value = model.Privacy;
            parameters[16].Value = model.Tags;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.SNS.Groups model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_Groups set ");
            strSql.Append("GroupName=?GroupName,");
            strSql.Append("GroupDescription=?GroupDescription,");
            strSql.Append("GroupUserCount=?GroupUserCount,");
            strSql.Append("CreatedUserId=?CreatedUserId,");
            strSql.Append("CreatedNickName=?CreatedNickName,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("GroupLogo=?GroupLogo,");
            strSql.Append("GroupLogoThumb=?GroupLogoThumb,");
            strSql.Append("GroupBackground=?GroupBackground,");
            strSql.Append("ApplyGroupReason=?ApplyGroupReason,");
            strSql.Append("IsRecommand=?IsRecommand,");
            strSql.Append("TopicCount=?TopicCount,");
            strSql.Append("TopicReplyCount=?TopicReplyCount,");
            strSql.Append("Status=?Status,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Privacy=?Privacy,");
            strSql.Append("Tags=?Tags");
            strSql.Append(" where GroupID=?GroupID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?GroupDescription", MySqlDbType.VarChar),
                    new MySqlParameter("?GroupUserCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?CreatedUserId", MySqlDbType.Int32,4),
                    new MySqlParameter("?CreatedNickName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
                    new MySqlParameter("?GroupLogo", MySqlDbType.VarChar,200),
                    new MySqlParameter("?GroupLogoThumb", MySqlDbType.VarChar,200),
                    new MySqlParameter("?GroupBackground", MySqlDbType.VarChar,200),
                    new MySqlParameter("?ApplyGroupReason", MySqlDbType.VarChar),
                    new MySqlParameter("?IsRecommand", MySqlDbType.Int32,4),
                    new MySqlParameter("?TopicCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?TopicReplyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?Privacy", MySqlDbType.Int16,2),
                    new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
                    new MySqlParameter("?GroupID", MySqlDbType.Int32,4)};
            parameters[0].Value = model.GroupName;
            parameters[1].Value = model.GroupDescription;
            parameters[2].Value = model.GroupUserCount;
            parameters[3].Value = model.CreatedUserId;
            parameters[4].Value = model.CreatedNickName;
            parameters[5].Value = model.CreatedDate;
            parameters[6].Value = model.GroupLogo;
            parameters[7].Value = model.GroupLogoThumb;
            parameters[8].Value = model.GroupBackground;
            parameters[9].Value = model.ApplyGroupReason;
            parameters[10].Value = model.IsRecommand;
            parameters[11].Value = model.TopicCount;
            parameters[12].Value = model.TopicReplyCount;
            parameters[13].Value = model.Status;
            parameters[14].Value = model.Sequence;
            parameters[15].Value = model.Privacy;
            parameters[16].Value = model.Tags;
            parameters[17].Value = model.GroupID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int GroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_Groups ");
            strSql.Append(" where GroupID=?GroupID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string GroupIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_Groups ");
            strSql.Append(" where GroupID in (" + GroupIDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.SNS.Groups GetModel(int GroupID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags from SNS_Groups ");
            strSql.Append(" where GroupID=?GroupID");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupID", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupID;

            YSWL.MALL.Model.SNS.Groups model = new YSWL.MALL.Model.SNS.Groups();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.SNS.Groups DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.SNS.Groups model = new YSWL.MALL.Model.SNS.Groups();
            if (row != null)
            {
                if (row["GroupID"] != null && row["GroupID"].ToString() != "")
                {
                    model.GroupID = int.Parse(row["GroupID"].ToString());
                }
                if (row["GroupName"] != null)
                {
                    model.GroupName = row["GroupName"].ToString();
                }
                if (row["GroupDescription"] != null)
                {
                    model.GroupDescription = row["GroupDescription"].ToString();
                }
                if (row["GroupUserCount"] != null && row["GroupUserCount"].ToString() != "")
                {
                    model.GroupUserCount = int.Parse(row["GroupUserCount"].ToString());
                }
                if (row["CreatedUserId"] != null && row["CreatedUserId"].ToString() != "")
                {
                    model.CreatedUserId = int.Parse(row["CreatedUserId"].ToString());
                }
                if (row["CreatedNickName"] != null)
                {
                    model.CreatedNickName = row["CreatedNickName"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["GroupLogo"] != null)
                {
                    model.GroupLogo = row["GroupLogo"].ToString();
                }
                if (row["GroupLogoThumb"] != null)
                {
                    model.GroupLogoThumb = row["GroupLogoThumb"].ToString();
                }
                if (row["GroupBackground"] != null)
                {
                    model.GroupBackground = row["GroupBackground"].ToString();
                }
                if (row["ApplyGroupReason"] != null)
                {
                    model.ApplyGroupReason = row["ApplyGroupReason"].ToString();
                }
                if (row["IsRecommand"] != null && row["IsRecommand"].ToString() != "")
                {
                    model.IsRecommand = int.Parse(row["IsRecommand"].ToString());
                }
                if (row["TopicCount"] != null && row["TopicCount"].ToString() != "")
                {
                    model.TopicCount = int.Parse(row["TopicCount"].ToString());
                }
                if (row["TopicReplyCount"] != null && row["TopicReplyCount"].ToString() != "")
                {
                    model.TopicReplyCount = int.Parse(row["TopicReplyCount"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["Privacy"] != null && row["Privacy"].ToString() != "")
                {
                    model.Privacy = int.Parse(row["Privacy"].ToString());
                }
                if (row["Tags"] != null)
                {
                    model.Tags = row["Tags"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags ");
            strSql.Append(" FROM SNS_Groups ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags ");
            strSql.Append(" FROM SNS_Groups ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SNS_Groups ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.GroupID desc");
            }
            strSql.Append(")AS Row, T.*  from SNS_Groups T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("?tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("?PageSize", MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SNS_Groups";
            parameters[1].Value = "GroupID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 更新小组的状态
        /// </summary>
        /// <param name="IdsStr">id的集合</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public bool UpdateStatusList(string IdsStr, YSWL.MALL.Model.SNS.EnumHelper.GroupStatus status)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_Groups set Status="+(int)status+" ");
            strSql.Append(" where GroupID in (" + IdsStr + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        
        } 
        /// <summary>
        /// 删除小组和小组下面的话题以及怀特的回复
        /// </summary>
        public  bool DeleteListEx(string GroupIDlist)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();

            StringBuilder strSql0 = new StringBuilder();
            strSql0.Append("delete from SNS_GroupTopicFav ");
            strSql0.Append(" where TopicID in (select TopicID from SNS_GroupTopics where GroupID in (" + GroupIDlist + "))  ");
            CommandInfo cmd0 = new CommandInfo(strSql0.ToString(), null);
            sqllist.Add(cmd0);

 
            StringBuilder strSql2 = new StringBuilder();
           strSql2.Append("delete from SNS_GroupTopicReply ");
            strSql2.Append(" where GroupID in (" + GroupIDlist + ")  ");
            CommandInfo cmd2 = new CommandInfo(strSql2.ToString(), null);
            sqllist.Add(cmd2);
            #region 删除相应的话题和话题的回复
            StringBuilder strSql1 = new StringBuilder();
           strSql1.Append("delete from SNS_GroupTopics ");
            strSql1.Append(" where GroupID in (" + GroupIDlist + ")  ");
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), null);
            sqllist.Add(cmd1);


            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("delete from SNS_GroupUsers ");
            strSql4.Append(" where GroupID in (" + GroupIDlist + ")  ");
            CommandInfo cmd4 = new CommandInfo(strSql4.ToString(), null);
            sqllist.Add(cmd4);



         
            #endregion
            #region 删除小组
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SNS_Groups ");
            strSql.Append(" where GroupID in (" + GroupIDlist + ")  ");
          
            CommandInfo cmd = new CommandInfo(strSql.ToString(), null);
            sqllist.Add(cmd);
            #endregion
            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;

        
        }

        public bool UpdateRecommand(int GroupId, int Recommand)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_Groups set ");
            strSql.Append("IsRecommand=?IsRecommand");
            strSql.Append(" where GroupID=?GroupID");
            MySqlParameter[] parameters = {
    
                    new MySqlParameter("?IsRecommand", MySqlDbType.Int32,4),
             
                    new MySqlParameter("?GroupID", MySqlDbType.Int32,4)};

            parameters[0].Value = Recommand;
            parameters[1].Value = GroupId;
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
        #endregion  ExtensionMethod
    }
}

