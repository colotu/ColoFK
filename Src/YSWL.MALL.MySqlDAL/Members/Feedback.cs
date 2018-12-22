using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Members;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Members
{
    /// <summary>
    /// 数据访问类:Feedback
    /// </summary>
    public partial class Feedback : IFeedback
    {
        public Feedback()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("FeedbackId", "SA_Feedback");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int FeedbackId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SA_Feedback");
            strSql.Append(" where FeedbackId=?FeedbackId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FeedbackId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = FeedbackId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Members.Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SA_Feedback(");
            strSql.Append("TypeId,Description,UserName,UserSex,UserEmail,Phone,TelPhone,UserCompany,UserIP,IsSolved,CreatedDate,Result,Status,Remark,ExtData)");
            strSql.Append(" values (");
            strSql.Append("?TypeId,?Description,?UserName,?UserSex,?UserEmail,?Phone,?TelPhone,?UserCompany,?UserIP,?IsSolved,?CreatedDate,?Result,?Status,?Remark,?ExtData)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?UserName", MySqlDbType.VarString,200),
					new MySqlParameter("?UserSex", MySqlDbType.VarChar,10),
					new MySqlParameter("?UserEmail", MySqlDbType.VarString,100),
					new MySqlParameter("?Phone", MySqlDbType.VarString,100),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,100),
					new MySqlParameter("?UserCompany", MySqlDbType.VarString,200),
					new MySqlParameter("?UserIP", MySqlDbType.VarString,20),
					new MySqlParameter("?IsSolved", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Result",  MySqlDbType.Text),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarString,300),
					new MySqlParameter("?ExtData",  MySqlDbType.Text)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserSex;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.TelPhone;
            parameters[7].Value = model.UserCompany;
            parameters[8].Value = model.UserIP;
            parameters[9].Value = model.IsSolved;
            parameters[10].Value = model.CreatedDate;
            parameters[11].Value = model.Result;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.ExtData;

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
        public bool Update(YSWL.MALL.Model.Members.Feedback model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SA_Feedback set ");
            strSql.Append("TypeId=?TypeId,");
            strSql.Append("Description=?Description,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserSex=?UserSex,");
            strSql.Append("UserEmail=?UserEmail,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("UserCompany=?UserCompany,");
            strSql.Append("UserIP=?UserIP,");
            strSql.Append("IsSolved=?IsSolved,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Result=?Result,");
            strSql.Append("Status=?Status,");
            strSql.Append("Remark=?Remark,");
            strSql.Append("ExtData=?ExtData");
            strSql.Append(" where FeedbackId=?FeedbackId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?UserName", MySqlDbType.VarString,200),
					new MySqlParameter("?UserSex", MySqlDbType.VarChar,10),
					new MySqlParameter("?UserEmail", MySqlDbType.VarString,100),
					new MySqlParameter("?Phone", MySqlDbType.VarString,100),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,100),
					new MySqlParameter("?UserCompany", MySqlDbType.VarString,200),
					new MySqlParameter("?UserIP", MySqlDbType.VarString,20),
					new MySqlParameter("?IsSolved", MySqlDbType.Bit,1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Result",  MySqlDbType.Text),
					new MySqlParameter("?Status",  MySqlDbType.Int32,4),
					new MySqlParameter("?Remark", MySqlDbType.VarString,300),
					new MySqlParameter("?ExtData",  MySqlDbType.Text),
					new MySqlParameter("?FeedbackId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.UserSex;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.TelPhone;
            parameters[7].Value = model.UserCompany;
            parameters[8].Value = model.UserIP;
            parameters[9].Value = model.IsSolved;
            parameters[10].Value = model.CreatedDate;
            parameters[11].Value = model.Result;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.ExtData;
            parameters[15].Value = model.FeedbackId;

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
        public bool Delete(int FeedbackId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Feedback ");
            strSql.Append(" where FeedbackId=?FeedbackId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FeedbackId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = FeedbackId;

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
        public bool DeleteList(string FeedbackIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from SA_Feedback ");
            strSql.Append(" where FeedbackId in (" + FeedbackIdlist + ")  ");
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
        public YSWL.MALL.Model.Members.Feedback GetModel(int FeedbackId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   FeedbackId,TypeId,Description,UserName,UserSex,UserEmail,Phone,TelPhone,UserCompany,UserIP,IsSolved,CreatedDate,Result,Status,Remark,ExtData from SA_Feedback ");
            strSql.Append(" where FeedbackId=?FeedbackId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?FeedbackId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = FeedbackId;

            YSWL.MALL.Model.Members.Feedback model = new YSWL.MALL.Model.Members.Feedback();
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
        public YSWL.MALL.Model.Members.Feedback DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Members.Feedback model = new YSWL.MALL.Model.Members.Feedback();
            if (row != null)
            {
                if (row["FeedbackId"] != null && row["FeedbackId"].ToString() != "")
                {
                    model.FeedbackId = int.Parse(row["FeedbackId"].ToString());
                }
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserSex"] != null)
                {
                    model.UserSex = row["UserSex"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["TelPhone"] != null)
                {
                    model.TelPhone = row["TelPhone"].ToString();
                }
                if (row["UserCompany"] != null)
                {
                    model.UserCompany = row["UserCompany"].ToString();
                }
                if (row["UserIP"] != null)
                {
                    model.UserIP = row["UserIP"].ToString();
                }
                if (row["IsSolved"] != null && row["IsSolved"].ToString() != "")
                {
                    if ((row["IsSolved"].ToString() == "1") || (row["IsSolved"].ToString().ToLower() == "true"))
                    {
                        model.IsSolved = true;
                    }
                    else
                    {
                        model.IsSolved = false;
                    }
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Result"] != null)
                {
                    model.Result = row["Result"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["ExtData"] != null)
                {
                    model.ExtData = row["ExtData"].ToString();
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
            strSql.Append("select FeedbackId,TypeId,Description,UserName,UserSex,UserEmail,Phone,TelPhone,UserCompany,UserIP,IsSolved,CreatedDate,Result,Status,Remark,ExtData ");
            strSql.Append(" FROM SA_Feedback ");
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
            strSql.Append(" FeedbackId,TypeId,Description,UserName,UserSex,UserEmail,Phone,TelPhone,UserCompany,UserIP,IsSolved,CreatedDate,Result,Status,Remark,ExtData ");
            strSql.Append(" FROM SA_Feedback ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM SA_Feedback ");
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
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrEmpty(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.FeedbackId desc");
            //}
            //strSql.Append(")AS Row, T.*  from SA_Feedback T ");
            //if (!string.IsNullOrEmpty(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from SA_Feedback T  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.FeedbackId desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
                    new MySqlParameter("?PageSize",  MySqlDbType.Int32),
                    new MySqlParameter("?PageIndex",  MySqlDbType.Int32),
                    new MySqlParameter("?IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("?OrderType", MySqlDbType.Bit),
                    new MySqlParameter("?strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "SA_Feedback";
            parameters[1].Value = "FeedbackId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region ExtensionMethod

        #endregion ExtensionMethod
    }
}