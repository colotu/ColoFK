using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Products
{
	/// <summary>
	/// 数据访问类:ProductQA
	/// </summary>
	public partial class ProductQA:IProductQA
	{
		public ProductQA()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("QAId", "Shop_ProductQA"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int QAId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Shop_ProductQA");
			strSql.Append(" where QAId=?QAId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?QAId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = QAId;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Shop.Products.ProductQA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Shop_ProductQA(");
			strSql.Append("ParentId,ProductId,UserId,UserName,Question,State,CreatedDate,ReplyContent,ReplyDate,ReplyUserId,ReplyUserName)");
			strSql.Append(" values (");
			strSql.Append("?ParentId,?ProductId,?UserId,?UserName,?Question,?State,?CreatedDate,?ReplyContent,?ReplyDate,?ReplyUserId,?ReplyUserName)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Question", MySqlDbType.VarChar),
					new MySqlParameter("?State", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyContent", MySqlDbType.VarChar),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyUserName", MySqlDbType.VarChar,50)};
			parameters[0].Value = model.ParentId;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Question;
			parameters[5].Value = model.State;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.ReplyContent;
			parameters[8].Value = model.ReplyDate;
			parameters[9].Value = model.ReplyUserId;
			parameters[10].Value = model.ReplyUserName;

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
		public bool Update(YSWL.MALL.Model.Shop.Products.ProductQA model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Shop_ProductQA set ");
			strSql.Append("ParentId=?ParentId,");
			strSql.Append("ProductId=?ProductId,");
			strSql.Append("UserId=?UserId,");
			strSql.Append("UserName=?UserName,");
			strSql.Append("Question=?Question,");
			strSql.Append("State=?State,");
			strSql.Append("CreatedDate=?CreatedDate,");
			strSql.Append("ReplyContent=?ReplyContent,");
			strSql.Append("ReplyDate=?ReplyDate,");
			strSql.Append("ReplyUserId=?ReplyUserId,");
			strSql.Append("ReplyUserName=?ReplyUserName");
			strSql.Append(" where QAId=?QAId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Question", MySqlDbType.VarChar),
					new MySqlParameter("?State", MySqlDbType.Int32,4),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyContent", MySqlDbType.VarChar),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyUserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?QAId", MySqlDbType.Int32,4)};
			parameters[0].Value = model.ParentId;
			parameters[1].Value = model.ProductId;
			parameters[2].Value = model.UserId;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.Question;
			parameters[5].Value = model.State;
			parameters[6].Value = model.CreatedDate;
			parameters[7].Value = model.ReplyContent;
			parameters[8].Value = model.ReplyDate;
			parameters[9].Value = model.ReplyUserId;
			parameters[10].Value = model.ReplyUserName;
			parameters[11].Value = model.QAId;

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
		public bool Delete(int QAId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ProductQA ");
			strSql.Append(" where QAId=?QAId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?QAId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = QAId;

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
		public bool DeleteList(string QAIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Shop_ProductQA ");
			strSql.Append(" where QAId in ("+QAIdlist + ")  ");
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
		public YSWL.MALL.Model.Shop.Products.ProductQA GetModel(int QAId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QAId,ParentId,ProductId,UserId,UserName,Question,State,CreatedDate,ReplyContent,ReplyDate,ReplyUserId,ReplyUserName from Shop_ProductQA ");
			strSql.Append(" where QAId=?QAId");
			MySqlParameter[] parameters = {
					new MySqlParameter("?QAId", MySqlDbType.Int32,4)
			};
			parameters[0].Value = QAId;
            strSql.Append(" LIMIT 1 ");
			YSWL.MALL.Model.Shop.Products.ProductQA model=new YSWL.MALL.Model.Shop.Products.ProductQA();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["QAId"]!=null && ds.Tables[0].Rows[0]["QAId"].ToString()!="")
				{
					model.QAId=int.Parse(ds.Tables[0].Rows[0]["QAId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ParentId"]!=null && ds.Tables[0].Rows[0]["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductId"]!=null && ds.Tables[0].Rows[0]["ProductId"].ToString()!="")
				{
					model.ProductId=int.Parse(ds.Tables[0].Rows[0]["ProductId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserId"]!=null && ds.Tables[0].Rows[0]["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(ds.Tables[0].Rows[0]["UserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserName"]!=null && ds.Tables[0].Rows[0]["UserName"].ToString()!="")
				{
					model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Question"]!=null && ds.Tables[0].Rows[0]["Question"].ToString()!="")
				{
					model.Question=ds.Tables[0].Rows[0]["Question"].ToString();
				}
				if(ds.Tables[0].Rows[0]["State"]!=null && ds.Tables[0].Rows[0]["State"].ToString()!="")
				{
					model.State=int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreatedDate"]!=null && ds.Tables[0].Rows[0]["CreatedDate"].ToString()!="")
				{
					model.CreatedDate=DateTime.Parse(ds.Tables[0].Rows[0]["CreatedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplyContent"]!=null && ds.Tables[0].Rows[0]["ReplyContent"].ToString()!="")
				{
					model.ReplyContent=ds.Tables[0].Rows[0]["ReplyContent"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ReplyDate"]!=null && ds.Tables[0].Rows[0]["ReplyDate"].ToString()!="")
				{
					model.ReplyDate=DateTime.Parse(ds.Tables[0].Rows[0]["ReplyDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplyUserId"]!=null && ds.Tables[0].Rows[0]["ReplyUserId"].ToString()!="")
				{
					model.ReplyUserId=int.Parse(ds.Tables[0].Rows[0]["ReplyUserId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReplyUserName"]!=null && ds.Tables[0].Rows[0]["ReplyUserName"].ToString()!="")
				{
					model.ReplyUserName=ds.Tables[0].Rows[0]["ReplyUserName"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select QAId,ParentId,ProductId,UserId,UserName,Question,State,CreatedDate,ReplyContent,ReplyDate,ReplyUserId,ReplyUserName ");
			strSql.Append(" FROM Shop_ProductQA ");
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
			
			strSql.Append(" QAId,ParentId,ProductId,UserId,UserName,Question,State,CreatedDate,ReplyContent,ReplyDate,ReplyUserId,ReplyUserName ");
			strSql.Append(" FROM Shop_ProductQA ");
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
			strSql.Append("select count(1) FROM Shop_ProductQA ");
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
            strSql.Append("SELECT T.* from Shop_ProductQA T ");
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
                strSql.Append(" order by T.QAId desc");
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
			parameters[0].Value = "Shop_ProductQA";
			parameters[1].Value = "QAId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
        #region 扩展方法
        public bool SetStatus(string ids, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ProductQA set ");
            strSql.Append("State=?State");
            strSql.Append(" where QAId in (" + ids + ")");
            MySqlParameter[] parameters = {
					new MySqlParameter("?State", MySqlDbType.Int32,4)};
            parameters[0].Value = status;

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
        #endregion
    }
}

