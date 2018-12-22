using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.SNS;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.SNS
{
	/// <summary>
	/// 数据访问类:PhotoTags
	/// </summary>
	public partial class PhotoTags:IPhotoTags
	{
		public PhotoTags()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("TagID", "SNS_PhotoTags"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TagID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_PhotoTags");
			strSql.Append(" where TagID=?TagID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TagID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string TagName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SNS_PhotoTags");
            strSql.Append(" WHERE TagName=?TagName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = TagName;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TagID, string TagName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM SNS_PhotoTags");
            strSql.Append(" WHERE TagID<>?TagID AND TagName=?TagName");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TagID", MySqlDbType.Int32,4),
                    new MySqlParameter("?TagName", MySqlDbType.VarChar,50)
			};
            parameters[0].Value = TagID;
            parameters[1].Value = TagName;
            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.PhotoTags model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_PhotoTags(");
			strSql.Append("TagName,IsRecommand,Status,CreatedDate,Remark)");
			strSql.Append(" values (");
			strSql.Append("?TagName,?IsRecommand,?Status,?CreatedDate,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsRecommand", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.TagName;
			parameters[1].Value = model.IsRecommand;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CreatedDate;
			parameters[4].Value = model.Remark;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.SNS.PhotoTags model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_PhotoTags set ");
			strSql.Append("TagName=?TagName,");
			strSql.Append("IsRecommand=?IsRecommand,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where TagID=?TagID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagName", MySqlDbType.VarChar,100),
					new MySqlParameter("?IsRecommand", MySqlDbType.Int16,2),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?TagID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.TagName;
			parameters[1].Value = model.IsRecommand;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CreatedDate;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.TagID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int TagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_PhotoTags ");
			strSql.Append(" where TagID=?TagID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TagID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string TagIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_PhotoTags ");
			strSql.Append(" where TagID in ("+TagIDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public YSWL.MALL.Model.SNS.PhotoTags GetModel(int TagID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  TagID,TagName,IsRecommand,Status,CreatedDate,Remark from SNS_PhotoTags ");
            strSql.Append(" where TagID=?TagID LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?TagID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = TagID;

			YSWL.MALL.Model.SNS.PhotoTags model=new YSWL.MALL.Model.SNS.PhotoTags();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public YSWL.MALL.Model.SNS.PhotoTags DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.PhotoTags model=new YSWL.MALL.Model.SNS.PhotoTags();
			if (row != null)
			{
				if(row["TagID"]!=null && row["TagID"].ToString()!="")
				{
					model.TagID=int.Parse(row["TagID"].ToString());
				}
				if(row["TagName"]!=null && row["TagName"].ToString()!="")
				{
					model.TagName=row["TagName"].ToString();
				}
				if(row["IsRecommand"]!=null && row["IsRecommand"].ToString()!="")
				{
					model.IsRecommand=int.Parse(row["IsRecommand"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["Remark"]!=null && row["Remark"].ToString()!="")
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select TagID,TagName,IsRecommand,Status,CreatedDate,Remark ");
			strSql.Append(" FROM SNS_PhotoTags ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" TagID,TagName,IsRecommand,Status,CreatedDate,Remark ");
			strSql.Append(" FROM SNS_PhotoTags ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SNS_PhotoTags ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.TagID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_PhotoTags T ");
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
			parameters[0].Value = "SNS_PhotoTags";
			parameters[1].Value = "TagID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        #region MethodEx
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateStatus(int Status, string IdList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SNS_PhotoTags set ");
            strSql.AppendFormat(" Status={0} ", Status);
            strSql.AppendFormat(" where TagID IN({0})", IdList);

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

        public DataSet GetHotTags(int top)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (top > 10)
            {
                strSql.Append(" * from  SNS_PhotoTags order by RAND() LIMIT " + top);
            }
            else
            {
                strSql.Append(" * from  SNS_Tags order by RAND() LIMIT 10 ");
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
        #endregion
	}
}

