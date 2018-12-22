using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.IDAL.CMS;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:ClassType
    /// </summary>
    public partial class ClassType : IClassType
    {
        public ClassType()
        { }

        #region  Method

        #region 得到最大ID
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ClassTypeID", "CMS_ClassType");
        } 
        #endregion

        #region 是否存在该记录
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ClassTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_ClassType");
            strSql.Append(" where ClassTypeID=?ClassTypeID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassTypeID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        } 
        #endregion

        #region 增加一条数据
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(YSWL.MALL.Model.CMS.ClassType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_ClassType(");
            strSql.Append("ClassTypeName)");
            strSql.Append(" values (");
            strSql.Append("?ClassTypeName)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassTypeName", MySqlDbType.VarChar,50)};
            parameters[0].Value = model.ClassTypeName;

            if (DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters) > 0)
                return true;
            return false;
        } 
        #endregion

        #region 更新一条数据
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.CMS.ClassType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_ClassType set ");
            strSql.Append("ClassTypeName=?ClassTypeName");
            strSql.Append(" where ClassTypeID=?ClassTypeID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassTypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ClassTypeName;
            parameters[1].Value = model.ClassTypeID;

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

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ClassTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ClassType ");
            strSql.Append(" where ClassTypeID=?ClassTypeID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassTypeID;

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

        #region 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ClassTypeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_ClassType ");
            strSql.Append(" where ClassTypeID in (" + ClassTypeIDlist + ")  ");
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
        #endregion

        #region  得到一个对象实体
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.CMS.ClassType GetModel(int ClassTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  ClassTypeID,ClassTypeName from CMS_ClassType ");
            strSql.Append(" where ClassTypeID=?ClassTypeID  LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassTypeID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassTypeID;

            YSWL.MALL.Model.CMS.ClassType model = new YSWL.MALL.Model.CMS.ClassType();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (DataSetTools.DataSetIsNull(ds))
            {
                return null;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassTypeID"].ToString() != "")
                {
                    model.ClassTypeID = int.Parse(ds.Tables[0].Rows[0]["ClassTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassTypeName"] != null)
                {
                    model.ClassTypeName = ds.Tables[0].Rows[0]["ClassTypeName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        } 
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ClassTypeID,ClassTypeName ");
            strSql.Append(" FROM CMS_ClassType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        } 
        #endregion

        #region 获得数据列表
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.CMS.ClassType> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.CMS.ClassType> list = new List<YSWL.MALL.Model.CMS.ClassType>();
            if (DataTableTools.DataTableIsNull(dt))
            {
                return null;
            }
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.CMS.ClassType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.CMS.ClassType();
                    if (dt.Rows[n]["ClassTypeID"].ToString() != "")
                    {
                        model.ClassTypeID = int.Parse(dt.Rows[n]["ClassTypeID"].ToString());
                    }
                    model.ClassTypeName = dt.Rows[n]["ClassTypeName"].ToString();
                    list.Add(model);
                }
            }
            return list;
        }
        #endregion

        #region 获得前几行数据
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append(" ClassTypeID,ClassTypeName ");
            strSql.Append(" FROM CMS_ClassType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            else
            {
                strSql.Append(" order by DESC ");
            }

            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        } 
        #endregion

        #region 分页获取数据列表
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
            parameters[0].Value = "CMS_ClassType";
            parameters[1].Value = "ClassTypeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        
        #endregion

        #endregion  Method
    }
}

