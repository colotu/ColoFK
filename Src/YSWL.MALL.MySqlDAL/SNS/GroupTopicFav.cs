/**
* GroupTopicFav.cs
*
* 功 能： N/A
* 类 名： GroupTopicFav
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
	/// 数据访问类:GroupTopicFav
	/// </summary>
	public partial class GroupTopicFav:IGroupTopicFav
	{
		public GroupTopicFav()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否已经存在
		/// </summary>
        public bool Exists(int TopicID,int CreatedUserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_GroupTopicFav");
            strSql.Append(" where CreatedUserID=?CreatedUserID and TopicID=?TopicID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),					
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4)
			};
            parameters[0].Value = CreatedUserID;
            parameters[1].Value = TopicID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.SNS.GroupTopicFav model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_GroupTopicFav(");
			strSql.Append("CreatedUserID,CreatedDate,TopicID,Tags,Remark)");
			strSql.Append(" values (");
			strSql.Append("?CreatedUserID,?CreatedDate,?TopicID,?Tags,?Remark)");
			strSql.Append(";select @@IDENTITY");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.CreatedUserID;
			parameters[1].Value = model.CreatedDate;
			parameters[2].Value = model.TopicID;
			parameters[3].Value = model.Tags;
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
		public bool Update(YSWL.MALL.Model.SNS.GroupTopicFav model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_GroupTopicFav set ");
			strSql.Append("CreatedUserID=?CreatedUserID,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("TopicID=?TopicID,");
			strSql.Append("Tags=?Tags,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100),
					new MySqlParameter("?ID", MySqlDbType.Int32,4)};
			parameters[0].Value = model.CreatedUserID;
			parameters[1].Value = model.CreatedDate;
			parameters[2].Value = model.TopicID;
			parameters[3].Value = model.Tags;
			parameters[4].Value = model.Remark;
			parameters[5].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_GroupTopicFav ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_GroupTopicFav ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public YSWL.MALL.Model.SNS.GroupTopicFav GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,CreatedUserID,CreatedDate,TopicID,Tags,Remark from SNS_GroupTopicFav ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int32,4)
			};
			parameters[0].Value = ID;

			YSWL.MALL.Model.SNS.GroupTopicFav model=new YSWL.MALL.Model.SNS.GroupTopicFav();
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
		public YSWL.MALL.Model.SNS.GroupTopicFav DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.SNS.GroupTopicFav model=new YSWL.MALL.Model.SNS.GroupTopicFav();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["CreatedUserID"]!=null && row["CreatedUserID"].ToString()!="")
				{
					model.CreatedUserID=int.Parse(row["CreatedUserID"].ToString());
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["TopicID"]!=null && row["TopicID"].ToString()!="")
				{
					model.TopicID=int.Parse(row["TopicID"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
				}
				if(row["Remark"]!=null)
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
			strSql.Append("select ID,CreatedUserID,CreatedDate,TopicID,Tags,Remark ");
			strSql.Append(" FROM SNS_GroupTopicFav ");
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
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,CreatedUserID,CreatedDate,TopicID,Tags,Remark ");
			strSql.Append(" FROM SNS_GroupTopicFav ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SNS_GroupTopicFav ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_GroupTopicFav T ");
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
			parameters[0].Value = "SNS_GroupTopicFav";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public bool AddEx(YSWL.MALL.Model.SNS.GroupTopicFav model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            #region 加入收藏表
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SNS_GroupTopicFav(");
            strSql.Append("CreatedUserID,CreatedDate,TopicID,Tags,Remark)");
            strSql.Append(" values (");
            strSql.Append("?CreatedUserID,?CreatedDate,?TopicID,?Tags,?Remark)");
            strSql.Append(";select @@IDENTITY");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CreatedUserID", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?TopicID", MySqlDbType.Int32,4),
					new MySqlParameter("?Tags", MySqlDbType.VarChar,100),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,100)};
            parameters[0].Value = model.CreatedUserID;
            parameters[1].Value = model.CreatedDate;
            parameters[2].Value = model.TopicID;
            parameters[3].Value = model.Tags;
            parameters[4].Value = model.Remark;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);
            #endregion


            #region    用户收藏数量+1
            StringBuilder strSql1 = new StringBuilder();
            strSql1.Append("update Accounts_UsersExp set FavTopicCount=FavTopicCount-1");
            strSql1.Append(" where UserID=?UserID  ");

            MySqlParameter[] parameters1 = {
					new MySqlParameter("?UserID", MySqlDbType.Int32,4)};
            parameters1[0].Value = model.CreatedUserID;
            CommandInfo cmd1 = new CommandInfo(strSql1.ToString(), parameters1);
            sqllist.Add(cmd1);
            #endregion

            

            return DbHelperMySQL.ExecuteSqlTran(sqllist) > 0 ? true : false;
        
        
        }
		#endregion  ExtensionMethod


        public int GetRecordCount(int createdUserId)
        {
            throw new NotImplementedException();
        }


        public bool CancelFav(int topicId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

