/**  版本信息模板在安装目录下，可自行修改。
* SuppAreas.cs
*
* 功 能： N/A
* 类 名： SuppAreas
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/28 10:06:27   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Shop.Supplier;
using System.Collections.Generic;

namespace YSWL.MALL.SQLServerDAL.Shop.Supplier
{
	/// <summary>
	/// 数据访问类:SuppAreas
	/// </summary>
	public partial class SuppAreas:ISuppAreas
	{
		public SuppAreas()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelper.DefaultDBHelper.GetMaxID("AreaId", "Shop_SuppAreas"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int AreaId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_SuppAreas");
			strSql.Append(" where AreaId=@AreaId");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4)
			};
			parameters[0].Value = AreaId;

			return DBHelper.DefaultDBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_SuppAreas(");
			strSql.Append("DisplaySequence,Name,Meta_Title,Meta_Description,Meta_Keywords,Description,ParentAreaId,Depth,Path,RewriteName,SKUPrefix,AssociatedProductType,ImageUrl,Notes1,Notes2,Notes3,Notes4,Notes5,Theme,HasChildren,SeoUrl,SeoImageAlt,SeoImageTitle,Status)");
			strSql.Append(" values (");
			strSql.Append("@DisplaySequence,@Name,@Meta_Title,@Meta_Description,@Meta_Keywords,@Description,@ParentAreaId,@Depth,@Path,@RewriteName,@SKUPrefix,@AssociatedProductType,@ImageUrl,@Notes1,@Notes2,@Notes3,@Notes4,@Notes5,@Theme,@HasChildren,@SeoUrl,@SeoImageAlt,@SeoImageTitle,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Meta_Title", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Keywords", SqlDbType.NVarChar,1000),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@ParentAreaId", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,4000),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
					new SqlParameter("@SKUPrefix", SqlDbType.NVarChar,10),
					new SqlParameter("@AssociatedProductType", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@Notes1", SqlDbType.NText),
					new SqlParameter("@Notes2", SqlDbType.NText),
					new SqlParameter("@Notes3", SqlDbType.NText),
					new SqlParameter("@Notes4", SqlDbType.NText),
					new SqlParameter("@Notes5", SqlDbType.NText),
					new SqlParameter("@Theme", SqlDbType.VarChar,100),
					new SqlParameter("@HasChildren", SqlDbType.Bit,1),
					new SqlParameter("@SeoUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageAlt", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@Status", SqlDbType.Bit,1)};
			parameters[0].Value = model.DisplaySequence;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Meta_Title;
			parameters[3].Value = model.Meta_Description;
			parameters[4].Value = model.Meta_Keywords;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.ParentAreaId;
			parameters[7].Value = model.Depth;
			parameters[8].Value = model.Path;
			parameters[9].Value = model.RewriteName;
			parameters[10].Value = model.SKUPrefix;
			parameters[11].Value = model.AssociatedProductType;
			parameters[12].Value = model.ImageUrl;
			parameters[13].Value = model.Notes1;
			parameters[14].Value = model.Notes2;
			parameters[15].Value = model.Notes3;
			parameters[16].Value = model.Notes4;
			parameters[17].Value = model.Notes5;
			parameters[18].Value = model.Theme;
			parameters[19].Value = model.HasChildren;
			parameters[20].Value = model.SeoUrl;
			parameters[21].Value = model.SeoImageAlt;
			parameters[22].Value = model.SeoImageTitle;
			parameters[23].Value = model.Status;

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
		public bool Update(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_SuppAreas set ");
			strSql.Append("DisplaySequence=@DisplaySequence,");
			strSql.Append("Name=@Name,");
			strSql.Append("Meta_Title=@Meta_Title,");
			strSql.Append("Meta_Description=@Meta_Description,");
			strSql.Append("Meta_Keywords=@Meta_Keywords,");
			strSql.Append("Description=@Description,");
			strSql.Append("ParentAreaId=@ParentAreaId,");
			strSql.Append("Depth=@Depth,");
			strSql.Append("Path=@Path,");
			strSql.Append("RewriteName=@RewriteName,");
			strSql.Append("SKUPrefix=@SKUPrefix,");
			strSql.Append("AssociatedProductType=@AssociatedProductType,");
			strSql.Append("ImageUrl=@ImageUrl,");
			strSql.Append("Notes1=@Notes1,");
			strSql.Append("Notes2=@Notes2,");
			strSql.Append("Notes3=@Notes3,");
			strSql.Append("Notes4=@Notes4,");
			strSql.Append("Notes5=@Notes5,");
			strSql.Append("Theme=@Theme,");
			strSql.Append("HasChildren=@HasChildren,");
			strSql.Append("SeoUrl=@SeoUrl,");
			strSql.Append("SeoImageAlt=@SeoImageAlt,");
			strSql.Append("SeoImageTitle=@SeoImageTitle,");
			strSql.Append("Status=@Status");
			strSql.Append(" where AreaId=@AreaId");
			SqlParameter[] parameters = {
					new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Meta_Title", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@Meta_Keywords", SqlDbType.NVarChar,1000),
					new SqlParameter("@Description", SqlDbType.NVarChar,1000),
					new SqlParameter("@ParentAreaId", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.VarChar,4000),
					new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
					new SqlParameter("@SKUPrefix", SqlDbType.NVarChar,10),
					new SqlParameter("@AssociatedProductType", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@Notes1", SqlDbType.NText),
					new SqlParameter("@Notes2", SqlDbType.NText),
					new SqlParameter("@Notes3", SqlDbType.NText),
					new SqlParameter("@Notes4", SqlDbType.NText),
					new SqlParameter("@Notes5", SqlDbType.NText),
					new SqlParameter("@Theme", SqlDbType.VarChar,100),
					new SqlParameter("@HasChildren", SqlDbType.Bit,1),
					new SqlParameter("@SeoUrl", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageAlt", SqlDbType.NVarChar,300),
					new SqlParameter("@SeoImageTitle", SqlDbType.NVarChar,300),
					new SqlParameter("@Status", SqlDbType.Bit,1),
					new SqlParameter("@AreaId", SqlDbType.Int,4)};
			parameters[0].Value = model.DisplaySequence;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Meta_Title;
			parameters[3].Value = model.Meta_Description;
			parameters[4].Value = model.Meta_Keywords;
			parameters[5].Value = model.Description;
			parameters[6].Value = model.ParentAreaId;
			parameters[7].Value = model.Depth;
			parameters[8].Value = model.Path;
			parameters[9].Value = model.RewriteName;
			parameters[10].Value = model.SKUPrefix;
			parameters[11].Value = model.AssociatedProductType;
			parameters[12].Value = model.ImageUrl;
			parameters[13].Value = model.Notes1;
			parameters[14].Value = model.Notes2;
			parameters[15].Value = model.Notes3;
			parameters[16].Value = model.Notes4;
			parameters[17].Value = model.Notes5;
			parameters[18].Value = model.Theme;
			parameters[19].Value = model.HasChildren;
			parameters[20].Value = model.SeoUrl;
			parameters[21].Value = model.SeoImageAlt;
			parameters[22].Value = model.SeoImageTitle;
			parameters[23].Value = model.Status;
			parameters[24].Value = model.AreaId;

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
		public bool Delete(int AreaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SuppAreas ");
			strSql.Append(" where AreaId=@AreaId");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4)
			};
			parameters[0].Value = AreaId;

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
		public bool DeleteList(string AreaIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_SuppAreas ");
			strSql.Append(" where AreaId in ("+AreaIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Supplier.SuppAreas GetModel(int AreaId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 AreaId,DisplaySequence,Name,Meta_Title,Meta_Description,Meta_Keywords,Description,ParentAreaId,Depth,Path,RewriteName,SKUPrefix,AssociatedProductType,ImageUrl,Notes1,Notes2,Notes3,Notes4,Notes5,Theme,HasChildren,SeoUrl,SeoImageAlt,SeoImageTitle,Status from Shop_SuppAreas ");
			strSql.Append(" where AreaId=@AreaId");
			SqlParameter[] parameters = {
					new SqlParameter("@AreaId", SqlDbType.Int,4)
			};
			parameters[0].Value = AreaId;

			YSWL.MALL.Model.Shop.Supplier.SuppAreas model=new YSWL.MALL.Model.Shop.Supplier.SuppAreas();
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
		public YSWL.MALL.Model.Shop.Supplier.SuppAreas DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Supplier.SuppAreas model=new YSWL.MALL.Model.Shop.Supplier.SuppAreas();
			if (row != null)
			{
				if(row["AreaId"]!=null && row["AreaId"].ToString()!="")
				{
					model.AreaId=int.Parse(row["AreaId"].ToString());
				}
				if(row["DisplaySequence"]!=null && row["DisplaySequence"].ToString()!="")
				{
					model.DisplaySequence=int.Parse(row["DisplaySequence"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Meta_Title"]!=null)
				{
					model.Meta_Title=row["Meta_Title"].ToString();
				}
				if(row["Meta_Description"]!=null)
				{
					model.Meta_Description=row["Meta_Description"].ToString();
				}
				if(row["Meta_Keywords"]!=null)
				{
					model.Meta_Keywords=row["Meta_Keywords"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["ParentAreaId"]!=null && row["ParentAreaId"].ToString()!="")
				{
					model.ParentAreaId=int.Parse(row["ParentAreaId"].ToString());
				}
				if(row["Depth"]!=null && row["Depth"].ToString()!="")
				{
					model.Depth=int.Parse(row["Depth"].ToString());
				}
				if(row["Path"]!=null)
				{
					model.Path=row["Path"].ToString();
				}
				if(row["RewriteName"]!=null)
				{
					model.RewriteName=row["RewriteName"].ToString();
				}
				if(row["SKUPrefix"]!=null)
				{
					model.SKUPrefix=row["SKUPrefix"].ToString();
				}
				if(row["AssociatedProductType"]!=null && row["AssociatedProductType"].ToString()!="")
				{
					model.AssociatedProductType=int.Parse(row["AssociatedProductType"].ToString());
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["Notes1"]!=null)
				{
					model.Notes1=row["Notes1"].ToString();
				}
				if(row["Notes2"]!=null)
				{
					model.Notes2=row["Notes2"].ToString();
				}
				if(row["Notes3"]!=null)
				{
					model.Notes3=row["Notes3"].ToString();
				}
				if(row["Notes4"]!=null)
				{
					model.Notes4=row["Notes4"].ToString();
				}
				if(row["Notes5"]!=null)
				{
					model.Notes5=row["Notes5"].ToString();
				}
				if(row["Theme"]!=null)
				{
					model.Theme=row["Theme"].ToString();
				}
				if(row["HasChildren"]!=null && row["HasChildren"].ToString()!="")
				{
					if((row["HasChildren"].ToString()=="1")||(row["HasChildren"].ToString().ToLower()=="true"))
					{
						model.HasChildren=true;
					}
					else
					{
						model.HasChildren=false;
					}
				}
				if(row["SeoUrl"]!=null)
				{
					model.SeoUrl=row["SeoUrl"].ToString();
				}
				if(row["SeoImageAlt"]!=null)
				{
					model.SeoImageAlt=row["SeoImageAlt"].ToString();
				}
				if(row["SeoImageTitle"]!=null)
				{
					model.SeoImageTitle=row["SeoImageTitle"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					if((row["Status"].ToString()=="1")||(row["Status"].ToString().ToLower()=="true"))
					{
						model.Status=true;
					}
					else
					{
						model.Status=false;
					}
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
			strSql.Append("select AreaId,DisplaySequence,Name,Meta_Title,Meta_Description,Meta_Keywords,Description,ParentAreaId,Depth,Path,RewriteName,SKUPrefix,AssociatedProductType,ImageUrl,Notes1,Notes2,Notes3,Notes4,Notes5,Theme,HasChildren,SeoUrl,SeoImageAlt,SeoImageTitle,Status ");
			strSql.Append(" FROM Shop_SuppAreas ");
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
			strSql.Append(" AreaId,DisplaySequence,Name,Meta_Title,Meta_Description,Meta_Keywords,Description,ParentAreaId,Depth,Path,RewriteName,SKUPrefix,AssociatedProductType,ImageUrl,Notes1,Notes2,Notes3,Notes4,Notes5,Theme,HasChildren,SeoUrl,SeoImageAlt,SeoImageTitle,Status ");
			strSql.Append(" FROM Shop_SuppAreas ");
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
			strSql.Append("select count(1) FROM Shop_SuppAreas ");
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
				strSql.Append("order by T.AreaId desc");
			}
			strSql.Append(")AS Row, T.*  from Shop_SuppAreas T ");
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
			parameters[0].Value = "Shop_SuppAreas";
			parameters[1].Value = "AreaId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool IsExisted(int parentId, string name, int areaId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_SuppAreas");
            strSql.Append(" where ParentAreaId=@ParentAreaId and Name=@Name");
            if (areaId > 0)
            {
                strSql.Append("  and AreaId<>@AreaId");
            }
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentAreaId", SqlDbType.Int,4),
                    new SqlParameter("@AreaId", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = parentId;
            parameters[1].Value = areaId;
            parameters[2].Value = name;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }
        public int GetMaxSeqByCid(int parentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT MAX(DisplaySequence) FROM Shop_SuppAreas WHERE ParentAreaId=@ParentAreaId");
            SqlParameter[] parameter = {
                                       new SqlParameter("@ParentAreaId",SqlDbType.Int,4)
                                       };
            parameter[0].Value = parentId;
            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameter);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public bool UpdateHasChild(int cid, int hasChild = 1)
        {
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("update Shop_SuppAreas set HasChildren=" + hasChild + " WHERE AreaId=@AreaId ");
            SqlParameter[] parameters4 =
                {
                     new SqlParameter("@AreaId", SqlDbType.Int, 4)
                };
            parameters4[0].Value = cid;
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql4.ToString(), parameters4);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdatePath(Model.Shop.Supplier.SuppAreas model)
        {
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("update Shop_SuppAreas set Path=@Path WHERE AreaId=@AreaId ");
            SqlParameter[] parameters4 =
                {
                    new SqlParameter("@Path", SqlDbType.NVarChar,200),
                    new SqlParameter("@AreaId", SqlDbType.Int, 4)
                };
            parameters4[0].Value = model.Path;
            parameters4[1].Value = model.AreaId;
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql4.ToString(), parameters4);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateSeqByCid(int Seq, int Cid)
        {
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("update Shop_SuppAreas set DisplaySequence=@DisplaySequence WHERE AreaId=@AreaId ");
            SqlParameter[] parameters4 =
                {
                    new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
                    new SqlParameter("@AreaId", SqlDbType.Int, 4)
                };
            parameters4[0].Value = Seq;
            parameters4[1].Value = Cid;
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql4.ToString(), parameters4);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateStatus(bool Status, int Cid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update Shop_SuppAreas set Status=@Status  WHERE AreaId=@AreaId ");
            if (!Status)
            {
                strSql.AppendFormat("  OR Path like    ( select Path from Shop_SuppAreas where  AreaId={0} )+'|%' ", Cid);
            }
            SqlParameter[] parameters =
                {
                     new SqlParameter("@AreaId", SqlDbType.Int, 4),
                     new SqlParameter("@Status", SqlDbType.Bit,1)
                };
            parameters[0].Value = Cid;
            parameters[1].Value = Status;
            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        /// 删除
        /// </summary>
        public DataSet DeleteArea(int areaId, out int Result)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@AreaId", SqlDbType.Int,4),
                    DBHelper.DefaultDBHelper.CreateReturnParam("ReturnValue", SqlDbType.Int, 4)};
            parameters[0].Value = areaId;
            DataSet ds = DBHelper.DefaultDBHelper.RunProcedure("sp_Shop_SuppArea_Delete", parameters, "tb", out Result); 
            if (Result == 1)
            {
                return ds;
            }
            return null;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateEx(YSWL.MALL.Model.Shop.Supplier.SuppAreas model)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_SuppAreas set ");
            strSql.Append("DisplaySequence=@DisplaySequence,");
            strSql.Append("Name=@Name,");
            strSql.Append("Meta_Title=@Meta_Title,");
            strSql.Append("Meta_Description=@Meta_Description,");
            strSql.Append("Meta_Keywords=@Meta_Keywords,");
            strSql.Append("Description=@Description,");
            strSql.Append("ParentAreaId=@ParentAreaId,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("Path=@Path,");
            strSql.Append("RewriteName=@RewriteName,");
            strSql.Append("SKUPrefix=@SKUPrefix,");
            strSql.Append("AssociatedProductType=@AssociatedProductType,");
            strSql.Append("ImageUrl=@ImageUrl,");
            strSql.Append("Notes1=@Notes1,");
            strSql.Append("Notes2=@Notes2,");
            strSql.Append("Notes3=@Notes3,");
            strSql.Append("Notes4=@Notes4,");
            strSql.Append("Notes5=@Notes5,");
            strSql.Append("Theme=@Theme,");
            strSql.Append("HasChildren=@HasChildren,");
            strSql.Append("SeoUrl=@SeoUrl,");
            strSql.Append("SeoImageAlt=@SeoImageAlt,");
            strSql.Append("SeoImageTitle=@SeoImageTitle,");
            strSql.Append("Status=@Status");
            strSql.Append(" where AreaId=@AreaId");
            SqlParameter[] parameters = {
                    new SqlParameter("@DisplaySequence", SqlDbType.Int,4),
                    new SqlParameter("@Name", SqlDbType.NVarChar,100),
                    new SqlParameter("@Meta_Title", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Meta_Description", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Meta_Keywords", SqlDbType.NVarChar,1000),
                    new SqlParameter("@Description", SqlDbType.NVarChar,1000),
                    new SqlParameter("@ParentAreaId", SqlDbType.Int,4),
                    new SqlParameter("@Depth", SqlDbType.Int,4),
                    new SqlParameter("@Path", SqlDbType.VarChar,4000),
                    new SqlParameter("@RewriteName", SqlDbType.NVarChar,50),
                    new SqlParameter("@SKUPrefix", SqlDbType.NVarChar,10),
                    new SqlParameter("@AssociatedProductType", SqlDbType.Int,4),
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar,300),
                    new SqlParameter("@Notes1", SqlDbType.NText),
                    new SqlParameter("@Notes2", SqlDbType.NText),
                    new SqlParameter("@Notes3", SqlDbType.NText),
                    new SqlParameter("@Notes4", SqlDbType.NText),
                    new SqlParameter("@Notes5", SqlDbType.NText),
                    new SqlParameter("@Theme", SqlDbType.VarChar,100),
                    new SqlParameter("@HasChildren", SqlDbType.Bit,1),
                    new SqlParameter("@SeoUrl", SqlDbType.NVarChar,300),
                    new SqlParameter("@SeoImageAlt", SqlDbType.NVarChar,300),
                    new SqlParameter("@SeoImageTitle", SqlDbType.NVarChar,300),
                    new SqlParameter("@Status", SqlDbType.Bit,1),
                    new SqlParameter("@AreaId", SqlDbType.Int,4)};
            parameters[0].Value = model.DisplaySequence;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Meta_Title;
            parameters[3].Value = model.Meta_Description;
            parameters[4].Value = model.Meta_Keywords;
            parameters[5].Value = model.Description;
            parameters[6].Value = model.ParentAreaId;
            parameters[7].Value = model.Depth;
            parameters[8].Value = model.Path;
            parameters[9].Value = model.RewriteName;
            parameters[10].Value = model.SKUPrefix;
            parameters[11].Value = model.AssociatedProductType;
            parameters[12].Value = model.ImageUrl;
            parameters[13].Value = model.Notes1;
            parameters[14].Value = model.Notes2;
            parameters[15].Value = model.Notes3;
            parameters[16].Value = model.Notes4;
            parameters[17].Value = model.Notes5;
            parameters[18].Value = model.Theme;
            parameters[19].Value = model.HasChildren;
            parameters[20].Value = model.SeoUrl;
            parameters[21].Value = model.SeoImageAlt;
            parameters[22].Value = model.SeoImageTitle;
            parameters[23].Value = model.Status;
            parameters[24].Value = model.AreaId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Shop_SuppAreaRelation set AreaPath=@AreaPath  WHERE AreaId=@AreaId ");
            SqlParameter[] parameters2 =
                {
                    new SqlParameter("@AreaPath", SqlDbType.NVarChar,200),
                     new SqlParameter("@AreaId", SqlDbType.Int, 4)
                };
            parameters2[0].Value = model.Path;
            parameters2[1].Value = model.AreaId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rows = DBHelper.DefaultDBHelper.ExecuteSqlTran(sqllist);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateDepthAndPath(int areaId, int Depth, string Path)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql4 = new StringBuilder();
            strSql4.Append("update Shop_SuppAreas set Path=@Path, Depth=@Depth WHERE areaId=@areaId ");
            SqlParameter[] parameters4 =
                {
                    new SqlParameter("@Path", SqlDbType.NVarChar,200),
                    new SqlParameter("@Depth", SqlDbType.Int, 4),
                     new SqlParameter("@areaId", SqlDbType.Int, 4)
                };
            parameters4[0].Value = Path;
            parameters4[1].Value = Depth;
            parameters4[2].Value = areaId;
            CommandInfo cmd = new CommandInfo(strSql4.ToString(), parameters4);
            sqllist.Add(cmd);


            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("update Shop_SuppAreaRelation set AreaPath=@AreaPath  WHERE areaId=@areaId ");
            SqlParameter[] parameters5 =
                {
                    new SqlParameter("@AreaPath", SqlDbType.NVarChar,200),
                     new SqlParameter("@areaId", SqlDbType.Int, 4)
                };
            parameters5[0].Value = Path;
            parameters5[1].Value = areaId;
            cmd = new CommandInfo(strSql5.ToString(), parameters5);
            sqllist.Add(cmd);

            int rows = DBHelper.DefaultDBHelper.ExecuteSqlTran(sqllist);
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

