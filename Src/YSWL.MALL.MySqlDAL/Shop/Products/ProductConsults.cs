/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：ProductConsultations.cs
// 文件功能描述：
// 
// 创建标识： [Name]  2012/08/24 17:49:44
// 修改标识：
// 修改描述：
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
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
	/// 数据访问类:ProductConsultations
	/// </summary>
	public partial class ProductConsults:IProductConsults
	{
		public ProductConsults()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ConsultationId", "Shop_ProductConsults");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ConsultationId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_ProductConsults");
            strSql.Append(" where ConsultationId=?ConsultationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ConsultationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ConsultationId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Products.ProductConsults model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_ProductConsults(");
            strSql.Append("TypeId,UserId,ProductId,UserName,UserEmail,ConsultationText,CreatedDate,ReplyDate,IsReply,ReplyText,ReplyUserId,ReplyUserName,Status,Recomend)");
            strSql.Append(" values (");
            strSql.Append("?TypeId,?UserId,?ProductId,?UserName,?UserEmail,?ConsultationText,?CreatedDate,?ReplyDate,?IsReply,?ReplyText,?ReplyUserId,?ReplyUserName,?Status,?Recomend)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?ConsultationText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsReply", MySqlDbType.Bit,1),
					new MySqlParameter("?ReplyText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?ReplyUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyUserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Recomend", MySqlDbType.Int32,4)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.ConsultationText;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.ReplyDate;
            parameters[8].Value = model.IsReply;
            parameters[9].Value = model.ReplyText;
            parameters[10].Value = model.ReplyUserId;
            parameters[11].Value = model.ReplyUserName;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Recomend;

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
        public bool Update(YSWL.MALL.Model.Shop.Products.ProductConsults model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ProductConsults set ");
            strSql.Append("TypeId=?TypeId,");
            strSql.Append("UserId=?UserId,");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("UserName=?UserName,");
            strSql.Append("UserEmail=?UserEmail,");
            strSql.Append("ConsultationText=?ConsultationText,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("ReplyDate=?ReplyDate,");
            strSql.Append("IsReply=?IsReply,");
            strSql.Append("ReplyText=?ReplyText,");
            strSql.Append("ReplyUserId=?ReplyUserId,");
            strSql.Append("ReplyUserName=?ReplyUserName,");
            strSql.Append("Status=?Status,");
            strSql.Append("Recomend=?Recomend");
            strSql.Append(" where ConsultationId=?ConsultationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
					new MySqlParameter("?UserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?UserEmail", MySqlDbType.VarChar,50),
					new MySqlParameter("?ConsultationText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?ReplyDate", MySqlDbType.DateTime),
					new MySqlParameter("?IsReply", MySqlDbType.Bit,1),
					new MySqlParameter("?ReplyText", MySqlDbType.VarChar,-1),
					new MySqlParameter("?ReplyUserId", MySqlDbType.Int32,4),
					new MySqlParameter("?ReplyUserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?Status", MySqlDbType.Int32,4),
					new MySqlParameter("?Recomend", MySqlDbType.Int32,4),
					new MySqlParameter("?ConsultationId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.ProductId;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.UserEmail;
            parameters[5].Value = model.ConsultationText;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.ReplyDate;
            parameters[8].Value = model.IsReply;
            parameters[9].Value = model.ReplyText;
            parameters[10].Value = model.ReplyUserId;
            parameters[11].Value = model.ReplyUserName;
            parameters[12].Value = model.Status;
            parameters[13].Value = model.Recomend;
            parameters[14].Value = model.ConsultationId;

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
        public bool Delete(int ConsultationId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductConsults ");
            strSql.Append(" where ConsultationId=?ConsultationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ConsultationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ConsultationId;

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
        public bool DeleteList(string ConsultationIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_ProductConsults ");
            strSql.Append(" where ConsultationId in (" + ConsultationIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.ProductConsults GetModel(int ConsultationId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ConsultationId,TypeId,UserId,ProductId,UserName,UserEmail,ConsultationText,CreatedDate,ReplyDate,IsReply,ReplyText,ReplyUserId,ReplyUserName,Status,Recomend from Shop_ProductConsults ");
            strSql.Append(" where ConsultationId=?ConsultationId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ConsultationId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = ConsultationId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.ProductConsults model = new YSWL.MALL.Model.Shop.Products.ProductConsults();
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
        public YSWL.MALL.Model.Shop.Products.ProductConsults DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Products.ProductConsults model = new YSWL.MALL.Model.Shop.Products.ProductConsults();
            if (row != null)
            {
                if (row["ConsultationId"] != null && row["ConsultationId"].ToString() != "")
                {
                    model.ConsultationId = int.Parse(row["ConsultationId"].ToString());
                }
                if (row["TypeId"] != null && row["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(row["TypeId"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserEmail"] != null)
                {
                    model.UserEmail = row["UserEmail"].ToString();
                }
                if (row["ConsultationText"] != null)
                {
                    model.ConsultationText = row["ConsultationText"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["ReplyDate"] != null && row["ReplyDate"].ToString() != "")
                {
                    model.ReplyDate = DateTime.Parse(row["ReplyDate"].ToString());
                }
                if (row["IsReply"] != null && row["IsReply"].ToString() != "")
                {
                    if ((row["IsReply"].ToString() == "1") || (row["IsReply"].ToString().ToLower() == "true"))
                    {
                        model.IsReply = true;
                    }
                    else
                    {
                        model.IsReply = false;
                    }
                }
                if (row["ReplyText"] != null)
                {
                    model.ReplyText = row["ReplyText"].ToString();
                }
                if (row["ReplyUserId"] != null && row["ReplyUserId"].ToString() != "")
                {
                    model.ReplyUserId = int.Parse(row["ReplyUserId"].ToString());
                }
                if (row["ReplyUserName"] != null)
                {
                    model.ReplyUserName = row["ReplyUserName"].ToString();
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Recomend"] != null && row["Recomend"].ToString() != "")
                {
                    model.Recomend = int.Parse(row["Recomend"].ToString());
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
            strSql.Append("select ConsultationId,TypeId,UserId,ProductId,UserName,UserEmail,ConsultationText,CreatedDate,ReplyDate,IsReply,ReplyText,ReplyUserId,ReplyUserName,Status,Recomend ");
            strSql.Append(" FROM Shop_ProductConsults ");
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
            
            strSql.Append(" ConsultationId,TypeId,UserId,ProductId,UserName,UserEmail,ConsultationText,CreatedDate,ReplyDate,IsReply,ReplyText,ReplyUserId,ReplyUserName,Status,Recomend ");
            strSql.Append(" FROM Shop_ProductConsults ");
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
            strSql.Append("select count(1) FROM Shop_ProductConsults ");
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
            strSql.Append("SELECT T.* from Shop_ProductConsults T ");
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
                strSql.Append(" order by T.ConsultationId desc");
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
            parameters[0].Value = "Shop_ProductConsults";
            parameters[1].Value = "ConsultationId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region 扩展方法

        public bool UpdateStatusList(string ids, int status)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_ProductConsults set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where ConsultationId in (" + ids + ")  ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Status", MySqlDbType.Int32,4)
                                        };
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

