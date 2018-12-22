/**  版本信息模板在安装目录下，可自行修改。
* SNS_Groups.cs
*
* 功 能： N/A
* 类 名： SNS_Groups
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/6/25 16:38:23   N/A    初版
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
using YSWL.MALL.IDAL.Groups;
using YSWL.DBUtility;//Please add references
namespace YSWL.MALL.SQLServerDAL.Groups
{
	/// <summary>
	/// 数据访问类:SNS_Groups
	/// </summary>
	public partial class SNS_Groups:ISNS_Groups
	{
		public SNS_Groups()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelper.DefaultDBHelper.GetMaxID("GroupID", "SNS_Groups"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int GroupID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from SNS_Groups");
			strSql.Append(" where GroupID=@GroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupID;

			return DBHelper.DefaultDBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Groups.SNS_Groups model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into SNS_Groups(");
			strSql.Append("GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags)");
			strSql.Append(" values (");
			strSql.Append("@GroupName,@GroupDescription,@GroupUserCount,@CreatedUserId,@CreatedNickName,@CreatedDate,@GroupLogo,@GroupLogoThumb,@GroupBackground,@ApplyGroupReason,@IsRecommand,@TopicCount,@TopicReplyCount,@Status,@Sequence,@Privacy,@Tags)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@GroupUserCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
					new SqlParameter("@CreatedNickName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@GroupLogo", SqlDbType.NVarChar,200),
					new SqlParameter("@GroupLogoThumb", SqlDbType.NVarChar,200),
					new SqlParameter("@GroupBackground", SqlDbType.NVarChar,200),
					new SqlParameter("@ApplyGroupReason", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsRecommand", SqlDbType.SmallInt,2),
					new SqlParameter("@TopicCount", SqlDbType.Int,4),
					new SqlParameter("@TopicReplyCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Privacy", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,100)};
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

			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(YSWL.MALL.Model.Groups.SNS_Groups model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update SNS_Groups set ");
			strSql.Append("GroupName=@GroupName,");
			strSql.Append("GroupDescription=@GroupDescription,");
			strSql.Append("GroupUserCount=@GroupUserCount,");
			strSql.Append("CreatedUserId=@CreatedUserId,");
			strSql.Append("CreatedNickName=@CreatedNickName,");
			strSql.Append("CreatedDate=@CreatedDate,");
			strSql.Append("GroupLogo=@GroupLogo,");
			strSql.Append("GroupLogoThumb=@GroupLogoThumb,");
			strSql.Append("GroupBackground=@GroupBackground,");
			strSql.Append("ApplyGroupReason=@ApplyGroupReason,");
			strSql.Append("IsRecommand=@IsRecommand,");
			strSql.Append("TopicCount=@TopicCount,");
			strSql.Append("TopicReplyCount=@TopicReplyCount,");
			strSql.Append("Status=@Status,");
			strSql.Append("Sequence=@Sequence,");
			strSql.Append("Privacy=@Privacy,");
			strSql.Append("Tags=@Tags");
			strSql.Append(" where GroupID=@GroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@GroupDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@GroupUserCount", SqlDbType.Int,4),
					new SqlParameter("@CreatedUserId", SqlDbType.Int,4),
					new SqlParameter("@CreatedNickName", SqlDbType.NVarChar,50),
					new SqlParameter("@CreatedDate", SqlDbType.DateTime),
					new SqlParameter("@GroupLogo", SqlDbType.NVarChar,200),
					new SqlParameter("@GroupLogoThumb", SqlDbType.NVarChar,200),
					new SqlParameter("@GroupBackground", SqlDbType.NVarChar,200),
					new SqlParameter("@ApplyGroupReason", SqlDbType.NVarChar,-1),
					new SqlParameter("@IsRecommand", SqlDbType.SmallInt,2),
					new SqlParameter("@TopicCount", SqlDbType.Int,4),
					new SqlParameter("@TopicReplyCount", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.Int,4),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@Privacy", SqlDbType.SmallInt,2),
					new SqlParameter("@Tags", SqlDbType.NVarChar,100),
					new SqlParameter("@GroupID", SqlDbType.Int,4)};
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

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_Groups ");
			strSql.Append(" where GroupID=@GroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupID;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string GroupIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from SNS_Groups ");
			strSql.Append(" where GroupID in ("+GroupIDlist + ")  ");
			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString());
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
		public YSWL.MALL.Model.Groups.SNS_Groups GetModel(int GroupID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags from SNS_Groups ");
			strSql.Append(" where GroupID=@GroupID");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupID", SqlDbType.Int,4)
			};
			parameters[0].Value = GroupID;

			YSWL.MALL.Model.Groups.SNS_Groups model=new YSWL.MALL.Model.Groups.SNS_Groups();
			DataSet ds=DBHelper.DefaultDBHelper.Query(strSql.ToString(),parameters);
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
		public YSWL.MALL.Model.Groups.SNS_Groups DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Groups.SNS_Groups model=new YSWL.MALL.Model.Groups.SNS_Groups();
			if (row != null)
			{
				if(row["GroupID"]!=null && row["GroupID"].ToString()!="")
				{
					model.GroupID=int.Parse(row["GroupID"].ToString());
				}
				if(row["GroupName"]!=null)
				{
					model.GroupName=row["GroupName"].ToString();
				}
				if(row["GroupDescription"]!=null)
				{
					model.GroupDescription=row["GroupDescription"].ToString();
				}
				if(row["GroupUserCount"]!=null && row["GroupUserCount"].ToString()!="")
				{
					model.GroupUserCount=int.Parse(row["GroupUserCount"].ToString());
				}
				if(row["CreatedUserId"]!=null && row["CreatedUserId"].ToString()!="")
				{
					model.CreatedUserId=int.Parse(row["CreatedUserId"].ToString());
				}
				if(row["CreatedNickName"]!=null)
				{
					model.CreatedNickName=row["CreatedNickName"].ToString();
				}
				if(row["CreatedDate"]!=null && row["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(row["CreatedDate"].ToString());
				}
				if(row["GroupLogo"]!=null)
				{
					model.GroupLogo=row["GroupLogo"].ToString();
				}
				if(row["GroupLogoThumb"]!=null)
				{
					model.GroupLogoThumb=row["GroupLogoThumb"].ToString();
				}
				if(row["GroupBackground"]!=null)
				{
					model.GroupBackground=row["GroupBackground"].ToString();
				}
				if(row["ApplyGroupReason"]!=null)
				{
					model.ApplyGroupReason=row["ApplyGroupReason"].ToString();
				}
				if(row["IsRecommand"]!=null && row["IsRecommand"].ToString()!="")
				{
					model.IsRecommand=int.Parse(row["IsRecommand"].ToString());
				}
				if(row["TopicCount"]!=null && row["TopicCount"].ToString()!="")
				{
					model.TopicCount=int.Parse(row["TopicCount"].ToString());
				}
				if(row["TopicReplyCount"]!=null && row["TopicReplyCount"].ToString()!="")
				{
					model.TopicReplyCount=int.Parse(row["TopicReplyCount"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["Privacy"]!=null && row["Privacy"].ToString()!="")
				{
					model.Privacy=int.Parse(row["Privacy"].ToString());
				}
				if(row["Tags"]!=null)
				{
					model.Tags=row["Tags"].ToString();
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
			strSql.Append("select GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags ");
			strSql.Append(" FROM SNS_Groups ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
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
			strSql.Append(" GroupID,GroupName,GroupDescription,GroupUserCount,CreatedUserId,CreatedNickName,CreatedDate,GroupLogo,GroupLogoThumb,GroupBackground,ApplyGroupReason,IsRecommand,TopicCount,TopicReplyCount,Status,Sequence,Privacy,Tags ");
			strSql.Append(" FROM SNS_Groups ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM SNS_Groups ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());
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
				strSql.Append("order by T.GroupID desc");
			}
			strSql.Append(")AS Row, T.*  from SNS_Groups T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "SNS_Groups";
			parameters[1].Value = "GroupID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

