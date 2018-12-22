/**
* EntryForm.cs
*
* 功 能：
* 类 名： EntryForm
*
* Ver    变更日期             负责人：  变更内容
* ───────────────────────────────────
* V0.01  2012/5/23 16:06:13  蒋海滨    初版
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
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Ms;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms
{
    /// <summary>
    /// 数据访问类:EntryForm
    /// </summary>
    public partial class EntryForm : IEntryForm
    {
        public EntryForm()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("Id", "Ms_EntryForm");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_EntryForm");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Id",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = Id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.EntryForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_EntryForm(");
            strSql.Append("UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,remark,State)");
            strSql.Append(" values (");
            strSql.Append("?UserName,?Age,?Email,?TelPhone,?Phone,?QQ,?MSN,?HouseAddress,?CompanyAddress,?RegionId,?Sex,?Description,?remark,?State)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Age",  MySqlDbType.Int32,4),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,100),
					new MySqlParameter("?HouseAddress", MySqlDbType.VarChar,200),
					new MySqlParameter("?CompanyAddress", MySqlDbType.VarChar,200),
					new MySqlParameter("?RegionId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,10),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?remark", MySqlDbType.VarChar,300),
					new MySqlParameter("?State", MySqlDbType.Int16,2)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.MSN;
            parameters[7].Value = model.HouseAddress;
            parameters[8].Value = model.CompanyAddress;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.State;

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
        public bool Update(YSWL.MALL.Model.Ms.EntryForm model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_EntryForm set ");
            strSql.Append("UserName=?UserName,");
            strSql.Append("Age=?Age,");
            strSql.Append("Email=?Email,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("Phone=?Phone,");
            strSql.Append("QQ=?QQ,");
            strSql.Append("MSN=?MSN,");
            strSql.Append("HouseAddress=?HouseAddress,");
            strSql.Append("CompanyAddress=?CompanyAddress,");
            strSql.Append("RegionId=?RegionId,");
            strSql.Append("Sex=?Sex,");
            strSql.Append("Description=?Description,");
            strSql.Append("remark=?remark,");
            strSql.Append("State=?State");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,50),
					new MySqlParameter("?Age",  MySqlDbType.Int32,4),
					new MySqlParameter("?Email", MySqlDbType.VarChar,100),
					new MySqlParameter("?TelPhone", MySqlDbType.VarChar,50),
					new MySqlParameter("?Phone", MySqlDbType.VarChar,20),
					new MySqlParameter("?QQ", MySqlDbType.VarChar,50),
					new MySqlParameter("?MSN", MySqlDbType.VarChar,100),
					new MySqlParameter("?HouseAddress", MySqlDbType.VarChar,200),
					new MySqlParameter("?CompanyAddress", MySqlDbType.VarChar,200),
					new MySqlParameter("?RegionId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sex", MySqlDbType.VarChar,10),
					new MySqlParameter("?Description",  MySqlDbType.Text),
					new MySqlParameter("?remark", MySqlDbType.VarChar,300),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?Id",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Age;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.TelPhone;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.QQ;
            parameters[6].Value = model.MSN;
            parameters[7].Value = model.HouseAddress;
            parameters[8].Value = model.CompanyAddress;
            parameters[9].Value = model.RegionId;
            parameters[10].Value = model.Sex;
            parameters[11].Value = model.Description;
            parameters[12].Value = model.Remark;
            parameters[13].Value = model.State;
            parameters[14].Value = model.Id;

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
        public bool Delete(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_EntryForm ");
            strSql.Append(" where Id=?Id");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Id",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = Id;

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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_EntryForm ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
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
        public YSWL.MALL.Model.Ms.EntryForm GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   Id,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,remark,State from Ms_EntryForm ");
            strSql.Append(" where Id=?Id LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Id",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = Id;

            YSWL.MALL.Model.Ms.EntryForm model = new YSWL.MALL.Model.Ms.EntryForm();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null && ds.Tables[0].Rows[0]["UserName"].ToString() != "")
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    model.Age = int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Email"] != null && ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null && ds.Tables[0].Rows[0]["TelPhone"].ToString() != "")
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["MSN"] != null && ds.Tables[0].Rows[0]["MSN"].ToString() != "")
                {
                    model.MSN = ds.Tables[0].Rows[0]["MSN"].ToString();
                }
                if (ds.Tables[0].Rows[0]["HouseAddress"] != null && ds.Tables[0].Rows[0]["HouseAddress"].ToString() != "")
                {
                    model.HouseAddress = ds.Tables[0].Rows[0]["HouseAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CompanyAddress"] != null && ds.Tables[0].Rows[0]["CompanyAddress"].ToString() != "")
                {
                    model.CompanyAddress = ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["RegionId"] != null && ds.Tables[0].Rows[0]["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(ds.Tables[0].Rows[0]["RegionId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Description"] != null && ds.Tables[0].Rows[0]["Description"].ToString() != "")
                {
                    model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["remark"] != null && ds.Tables[0].Rows[0]["remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"] != null && ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,remark,State ");
            strSql.Append(" FROM Ms_EntryForm ");
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
            strSql.Append(" Id,UserName,Age,Email,TelPhone,Phone,QQ,MSN,HouseAddress,CompanyAddress,RegionId,Sex,Description,remark,State ");
            strSql.Append(" FROM Ms_EntryForm ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT  " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Ms_EntryForm ");
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
            //strSql.Append("SELECT * FROM ( ");
            //strSql.Append(" SELECT ROW_NUMBER() OVER (");
            //if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            //{
            //    strSql.Append(" order by T." + orderby);
            //}
            //else
            //{
            //    strSql.Append(" order by T.Id desc");
            //}
            //strSql.Append(")AS Row, T.*  from Ms_EntryForm T ");
            //if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            //{
            //    strSql.Append(" WHERE " + strWhere);
            //}
            //strSql.Append(" ) TT");
            //strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            strSql.Append("SELECT T.*  from Ms_EntryForm T ");
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
                strSql.Append(" order by T.Id desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex-1, endIndex-startIndex+1);
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
            parameters[0].Value = "Ms_EntryForm";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region MethodEx

        #region 批量处理

        /// <summary>
        /// 批量处理
        /// </summary>
        /// <param name="IDlist"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_EntryForm set " + strWhere);
            strSql.Append(" where Id in(" + IDlist + ")  ");
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

        #endregion 批量处理

        #endregion MethodEx
    }
}