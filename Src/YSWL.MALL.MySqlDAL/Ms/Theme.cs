/**  版本信息模板在安装目录下，可自行修改。
* Theme.cs
*
* 功 能： N/A
* 类 名： Theme
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/12/27 15:56:15   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.DBUtility;//Please add references
using YSWL.MALL.IDAL.Ms;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms
{
    /// <summary>
    /// 数据访问类:Theme
    /// </summary>
    public partial class Theme : ITheme
    {
        public Theme()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "Ms_Theme");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Theme");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.Theme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_Theme(");
            strSql.Append("Name,Description,PreviewPhotoSrc,ZipPackageSrc,ThemeSize,Author,IsCurrent,Language,CreatedDate,Remark)");
            strSql.Append(" values (");
            strSql.Append("?Name,?Description,?PreviewPhotoSrc,?ZipPackageSrc,?ThemeSize,?Author,?IsCurrent,?Language,?CreatedDate,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?Description", MySqlDbType.VarString,200),
					new MySqlParameter("?PreviewPhotoSrc", MySqlDbType.VarString,100),
					new MySqlParameter("?ZipPackageSrc", MySqlDbType.VarString,50),
					new MySqlParameter("?ThemeSize",  MySqlDbType.Int32,4),
					new MySqlParameter("?Author", MySqlDbType.VarString,100),
					new MySqlParameter("?IsCurrent", MySqlDbType.Bit,1),
					new MySqlParameter("?Language", MySqlDbType.VarString,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarString,100)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.PreviewPhotoSrc;
            parameters[3].Value = model.ZipPackageSrc;
            parameters[4].Value = model.ThemeSize;
            parameters[5].Value = model.Author;
            parameters[6].Value = model.IsCurrent;
            parameters[7].Value = model.Language;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Ms.Theme model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Theme set ");
            strSql.Append("Name=?Name,");
            strSql.Append("Description=?Description,");
            strSql.Append("PreviewPhotoSrc=?PreviewPhotoSrc,");
            strSql.Append("ZipPackageSrc=?ZipPackageSrc,");
            strSql.Append("ThemeSize=?ThemeSize,");
            strSql.Append("Author=?Author,");
            strSql.Append("IsCurrent=?IsCurrent,");
            strSql.Append("Language=?Language,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?Description", MySqlDbType.VarString,200),
					new MySqlParameter("?PreviewPhotoSrc", MySqlDbType.VarString,100),
					new MySqlParameter("?ZipPackageSrc", MySqlDbType.VarString,50),
					new MySqlParameter("?ThemeSize",  MySqlDbType.Int32,4),
					new MySqlParameter("?Author", MySqlDbType.VarString,100),
					new MySqlParameter("?IsCurrent", MySqlDbType.Bit,1),
					new MySqlParameter("?Language", MySqlDbType.VarString,50),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarString,100),
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.PreviewPhotoSrc;
            parameters[3].Value = model.ZipPackageSrc;
            parameters[4].Value = model.ThemeSize;
            parameters[5].Value = model.Author;
            parameters[6].Value = model.IsCurrent;
            parameters[7].Value = model.Language;
            parameters[8].Value = model.CreatedDate;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.ID;

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
        public bool Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Theme ");
            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

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
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Theme ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
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
        public YSWL.MALL.Model.Ms.Theme GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ID,Name,Description,PreviewPhotoSrc,ZipPackageSrc,ThemeSize,Author,IsCurrent,Language,CreatedDate,Remark from Ms_Theme ");
            strSql.Append(" where ID=?ID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Ms.Theme model = new YSWL.MALL.Model.Ms.Theme();
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
        public YSWL.MALL.Model.Ms.Theme DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.Theme model = new YSWL.MALL.Model.Ms.Theme();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["PreviewPhotoSrc"] != null)
                {
                    model.PreviewPhotoSrc = row["PreviewPhotoSrc"].ToString();
                }
                if (row["ZipPackageSrc"] != null)
                {
                    model.ZipPackageSrc = row["ZipPackageSrc"].ToString();
                }
                if (row["ThemeSize"] != null && row["ThemeSize"].ToString() != "")
                {
                    model.ThemeSize = int.Parse(row["ThemeSize"].ToString());
                }
                if (row["Author"] != null)
                {
                    model.Author = row["Author"].ToString();
                }
                if (row["IsCurrent"] != null && row["IsCurrent"].ToString() != "")
                {
                    if ((row["IsCurrent"].ToString() == "1") || (row["IsCurrent"].ToString().ToLower() == "true"))
                    {
                        model.IsCurrent = true;
                    }
                    else
                    {
                        model.IsCurrent = false;
                    }
                }
                if (row["Language"] != null)
                {
                    model.Language = row["Language"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
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
            strSql.Append("select ID,Name,Description,PreviewPhotoSrc,ZipPackageSrc,ThemeSize,Author,IsCurrent,Language,CreatedDate,Remark ");
            strSql.Append(" FROM Ms_Theme ");
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
            strSql.Append(" ID,Name,Description,PreviewPhotoSrc,ZipPackageSrc,ThemeSize,Author,IsCurrent,Language,CreatedDate,Remark ");
            strSql.Append(" FROM Ms_Theme ");
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
            strSql.Append("select count(1) FROM Ms_Theme ");
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
            strSql.Append("SELECT  T.*  from Ms_Theme T ");
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
                strSql.Append(" order by T.ID desc");
            }
            strSql.AppendFormat("   LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
            parameters[0].Value = "Ms_Theme";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion BasicMethod

        #region ExtensionMethod

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool UpdateEx(int Id)
        {
            List<string> sqllist = new List<string>();

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("update Ms_Theme set IsCurrent=0 ");
            sqllist.Add(strSql2.ToString());

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Theme set IsCurrent=1 where  ID=" + Id + " ");
            sqllist.Add(strSql.ToString());

            int rowsAffected = DbHelperMySQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion ExtensionMethod
    }
}