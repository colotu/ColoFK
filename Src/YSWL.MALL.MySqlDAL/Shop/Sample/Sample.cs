using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Sample;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Sample
{
	/// <summary>
	/// 数据访问类:Sample
	/// </summary>
	public partial class Sample:ISample
	{
		public Sample()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("SampleId", "Shop_Sample"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int SampleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_Sample");
			strSql.Append(" where SampleId=?SampleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SampleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = SampleId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Sample.Sample model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_Sample(");
			strSql.Append("Tiltle,ElecCoverImageUrl,NormalElecCoverImageUrl,ThumblElecCoverImageUrl,PdfCoverImageUrl,NormalPdfCoverImageUrl,ThumbPdfCoverImageUrl,Sequence,Status,CreatedDate,Remark,Meta_Title,Meta_Description,Meta_KeyWords,SeoUrl,SeoImageAlt,SeoImageTitle)");
			strSql.Append(" values (");
			strSql.Append("?Tiltle,?ElecCoverImageUrl,?NormalElecCoverImageUrl,?ThumblElecCoverImageUrl,?PdfCoverImageUrl,?NormalPdfCoverImageUrl,?ThumbPdfCoverImageUrl,?Sequence,?Status,?CreatedDate,?Remark,?Meta_Title,?Meta_Description,?Meta_KeyWords,?SeoUrl,?SeoImageAlt,?SeoImageTitle)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Tiltle", MySqlDbType.VarChar,200),
					new MySqlParameter("?ElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumblElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?PdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalPdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbPdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_KeyWords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300)};
			parameters[0].Value = model.Tiltle;
			parameters[1].Value = model.ElecCoverImageUrl;
			parameters[2].Value = model.NormalElecCoverImageUrl;
			parameters[3].Value = model.ThumblElecCoverImageUrl;
			parameters[4].Value = model.PdfCoverImageUrl;
			parameters[5].Value = model.NormalPdfCoverImageUrl;
			parameters[6].Value = model.ThumbPdfCoverImageUrl;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.Meta_Title;
			parameters[12].Value = model.Meta_Description;
			parameters[13].Value = model.Meta_KeyWords;
			parameters[14].Value = model.SeoUrl;
			parameters[15].Value = model.SeoImageAlt;
			parameters[16].Value = model.SeoImageTitle;

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
		public bool Update(YSWL.MALL.Model.Shop.Sample.Sample model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_Sample set ");
			strSql.Append("Tiltle=?Tiltle,");
			strSql.Append("ElecCoverImageUrl=?ElecCoverImageUrl,");
			strSql.Append("NormalElecCoverImageUrl=?NormalElecCoverImageUrl,");
			strSql.Append("ThumblElecCoverImageUrl=?ThumblElecCoverImageUrl,");
			strSql.Append("PdfCoverImageUrl=?PdfCoverImageUrl,");
			strSql.Append("NormalPdfCoverImageUrl=?NormalPdfCoverImageUrl,");
			strSql.Append("ThumbPdfCoverImageUrl=?ThumbPdfCoverImageUrl,");
			strSql.Append("Sequence=?Sequence,");
			strSql.Append("Status=?Status,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("Remark=?Remark,");
			strSql.Append("Meta_Title=?Meta_Title,");
			strSql.Append("Meta_Description=?Meta_Description,");
			strSql.Append("Meta_KeyWords=?Meta_KeyWords,");
			strSql.Append("SeoUrl=?SeoUrl,");
			strSql.Append("SeoImageAlt=?SeoImageAlt,");
			strSql.Append("SeoImageTitle=?SeoImageTitle");
			strSql.Append(" where SampleId=?SampleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?Tiltle", MySqlDbType.VarChar,200),
					new MySqlParameter("?ElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumblElecCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?PdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?NormalPdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?ThumbPdfCoverImageUrl", MySqlDbType.VarChar,200),
					new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,200),
					new MySqlParameter("?Meta_Title", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarChar,1000),
					new MySqlParameter("?Meta_KeyWords", MySqlDbType.VarChar,1000),
					new MySqlParameter("?SeoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageAlt", MySqlDbType.VarChar,300),
					new MySqlParameter("?SeoImageTitle", MySqlDbType.VarChar,300),
					new MySqlParameter("?SampleId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.Tiltle;
			parameters[1].Value = model.ElecCoverImageUrl;
			parameters[2].Value = model.NormalElecCoverImageUrl;
			parameters[3].Value = model.ThumblElecCoverImageUrl;
			parameters[4].Value = model.PdfCoverImageUrl;
			parameters[5].Value = model.NormalPdfCoverImageUrl;
			parameters[6].Value = model.ThumbPdfCoverImageUrl;
			parameters[7].Value = model.Sequence;
			parameters[8].Value = model.Status;
			parameters[9].Value = model.CreatedDate;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.Meta_Title;
			parameters[12].Value = model.Meta_Description;
			parameters[13].Value = model.Meta_KeyWords;
			parameters[14].Value = model.SeoUrl;
			parameters[15].Value = model.SeoImageAlt;
			parameters[16].Value = model.SeoImageTitle;
			parameters[17].Value = model.SampleId;

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
		public bool Delete(int SampleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Sample ");
			strSql.Append(" where SampleId=?SampleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SampleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = SampleId;

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
		public bool DeleteList(string SampleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_Sample ");
			strSql.Append(" where SampleId in ("+SampleIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Sample.Sample GetModel(int SampleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  SampleId,Tiltle,ElecCoverImageUrl,NormalElecCoverImageUrl,ThumblElecCoverImageUrl,PdfCoverImageUrl,NormalPdfCoverImageUrl,ThumbPdfCoverImageUrl,Sequence,Status,CreatedDate,Remark,Meta_Title,Meta_Description,Meta_KeyWords,SeoUrl,SeoImageAlt,SeoImageTitle from Shop_Sample ");
			strSql.Append(" where SampleId=?SampleId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?SampleId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = SampleId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Sample.Sample model=new YSWL.MALL.Model.Shop.Sample.Sample();
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
		public YSWL.MALL.Model.Shop.Sample.Sample DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Shop.Sample.Sample model=new YSWL.MALL.Model.Shop.Sample.Sample();
			if (row != null)
			{
				if(row["SampleId"]!=null && row["SampleId"].ToString()!="")
				{
					model.SampleId=int.Parse(row["SampleId"].ToString());
				}
				if(row["Tiltle"]!=null && row["Tiltle"].ToString()!="")
				{
					model.Tiltle=row["Tiltle"].ToString();
				}
				if(row["ElecCoverImageUrl"]!=null && row["ElecCoverImageUrl"].ToString()!="")
				{
					model.ElecCoverImageUrl=row["ElecCoverImageUrl"].ToString();
				}
				if(row["NormalElecCoverImageUrl"]!=null && row["NormalElecCoverImageUrl"].ToString()!="")
				{
					model.NormalElecCoverImageUrl=row["NormalElecCoverImageUrl"].ToString();
				}
				if(row["ThumblElecCoverImageUrl"]!=null && row["ThumblElecCoverImageUrl"].ToString()!="")
				{
					model.ThumblElecCoverImageUrl=row["ThumblElecCoverImageUrl"].ToString();
				}
				if(row["PdfCoverImageUrl"]!=null && row["PdfCoverImageUrl"].ToString()!="")
				{
					model.PdfCoverImageUrl=row["PdfCoverImageUrl"].ToString();
				}
				if(row["NormalPdfCoverImageUrl"]!=null && row["NormalPdfCoverImageUrl"].ToString()!="")
				{
					model.NormalPdfCoverImageUrl=row["NormalPdfCoverImageUrl"].ToString();
				}
				if(row["ThumbPdfCoverImageUrl"]!=null && row["ThumbPdfCoverImageUrl"].ToString()!="")
				{
					model.ThumbPdfCoverImageUrl=row["ThumbPdfCoverImageUrl"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
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
				if(row["Meta_Title"]!=null && row["Meta_Title"].ToString()!="")
				{
					model.Meta_Title=row["Meta_Title"].ToString();
				}
				if(row["Meta_Description"]!=null && row["Meta_Description"].ToString()!="")
				{
					model.Meta_Description=row["Meta_Description"].ToString();
				}
				if(row["Meta_KeyWords"]!=null && row["Meta_KeyWords"].ToString()!="")
				{
					model.Meta_KeyWords=row["Meta_KeyWords"].ToString();
				}
				if(row["SeoUrl"]!=null && row["SeoUrl"].ToString()!="")
				{
					model.SeoUrl=row["SeoUrl"].ToString();
				}
				if(row["SeoImageAlt"]!=null && row["SeoImageAlt"].ToString()!="")
				{
					model.SeoImageAlt=row["SeoImageAlt"].ToString();
				}
				if(row["SeoImageTitle"]!=null && row["SeoImageTitle"].ToString()!="")
				{
					model.SeoImageTitle=row["SeoImageTitle"].ToString();
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
			strSql.Append("select SampleId,Tiltle,ElecCoverImageUrl,NormalElecCoverImageUrl,ThumblElecCoverImageUrl,PdfCoverImageUrl,NormalPdfCoverImageUrl,ThumbPdfCoverImageUrl,Sequence,Status,CreatedDate,Remark,Meta_Title,Meta_Description,Meta_KeyWords,SeoUrl,SeoImageAlt,SeoImageTitle ");
			strSql.Append(" FROM Shop_Sample ");
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

			strSql.Append(" SampleId,Tiltle,ElecCoverImageUrl,NormalElecCoverImageUrl,ThumblElecCoverImageUrl,PdfCoverImageUrl,NormalPdfCoverImageUrl,ThumbPdfCoverImageUrl,Sequence,Status,CreatedDate,Remark,Meta_Title,Meta_Description,Meta_KeyWords,SeoUrl,SeoImageAlt,SeoImageTitle ");
			strSql.Append(" FROM Shop_Sample ");
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
			strSql.Append("select count(1) FROM Shop_Sample ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from Shop_Sample T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.SampleId desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
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
			parameters[0].Value = "Shop_Sample";
			parameters[1].Value = "SampleId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

