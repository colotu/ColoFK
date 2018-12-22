/**
* Area.cs
*
* 功 能： N/A
* 类 名： Area
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/4/27 18:28:15   N/A    初版
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
using YSWL.MALL.IDAL.Ms;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Ms
{
	/// <summary>
	/// 数据访问类:Area
	/// </summary>
	public partial class RegionAreas:IRegionAreas
	{
		public RegionAreas()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("AreaId", "Ms_RegionAreas");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int AreaId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_RegionAreas");
            strSql.Append(" where AreaId=?AreaId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AreaId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.RegionAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_RegionAreas(");
            strSql.Append("Name)");
            strSql.Append(" values (");
            strSql.Append("?Name)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200)};
            parameters[0].Value = model.Name;

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
        public bool Update(YSWL.MALL.Model.Ms.RegionAreas model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_RegionAreas set ");
            strSql.Append("Name=?Name");
            strSql.Append(" where AreaId=?AreaId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarChar,200),
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.AreaId;

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
        public bool Delete(int AreaId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_RegionAreas ");
            strSql.Append(" where AreaId=?AreaId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AreaId;

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
        public bool DeleteList(string AreaIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_RegionAreas ");
            strSql.Append(" where AreaId in (" + AreaIdlist + ")  ");
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
        public YSWL.MALL.Model.Ms.RegionAreas GetModel(int AreaId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AreaId,Name from Ms_RegionAreas ");
            strSql.Append(" where AreaId=?AreaId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = AreaId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Ms.RegionAreas model = new YSWL.MALL.Model.Ms.RegionAreas();
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
        public YSWL.MALL.Model.Ms.RegionAreas DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.RegionAreas model = new YSWL.MALL.Model.Ms.RegionAreas();
            if (row != null)
            {
                if (row["AreaId"] != null && row["AreaId"].ToString() != "")
                {
                    model.AreaId = int.Parse(row["AreaId"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
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
            strSql.Append("select AreaId,Name ");
            strSql.Append(" FROM Ms_RegionAreas ");
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
            
            strSql.Append(" AreaId,Name ");
            strSql.Append(" FROM Ms_RegionAreas ");
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
            strSql.Append("select count(1) FROM Ms_RegionAreas ");
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
            strSql.Append("SELECT T.* from Ms_RegionAreas T ");
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
                strSql.Append("order by T.AreaId desc");
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
            parameters[0].Value = "Ms_RegionAreas";
            parameters[1].Value = "AreaId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

