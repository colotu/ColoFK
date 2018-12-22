using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.Common;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Settings;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Settings
{
    /// <summary>
    /// 数据访问类:FLinks
    /// </summary>
    public partial class FriendlyLink : IFriendlyLink
    {
        public FriendlyLink()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ID", "CMS_FLinks");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_FLinks");
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
        public int Add(YSWL.MALL.Model.Settings.FriendlyLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_FLinks(");
            strSql.Append("Name,ImgUrl,LinkUrl,LinkDesc,State,OrderID,ContactPerson,Email,TelPhone,TypeID,IsDisplay,ImgWidth,ImgHeight)");
            strSql.Append(" values (");
            strSql.Append("?Name,?ImgUrl,?LinkUrl,?LinkDesc,?State,?OrderID,?ContactPerson,?Email,?TelPhone,?TypeID,?IsDisplay,?ImgWidth,?ImgHeight)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Name", MySqlDbType.VarString,50),
					new MySqlParameter("?ImgUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkDesc", MySqlDbType.VarString,300),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ContactPerson", MySqlDbType.VarString,30),
					new MySqlParameter("?Email", MySqlDbType.VarString,300),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,30),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
                    new MySqlParameter("?IsDisplay",MySqlDbType.Bit),
                    new MySqlParameter("?ImgWidth",MySqlDbType.Int32),
                    new MySqlParameter("?ImgHeight",MySqlDbType.Int32)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.LinkDesc;
            parameters[4].Value = model.State;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.ContactPerson;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.TelPhone;
            parameters[9].Value = model.TypeID;
            parameters[10].Value = model.IsDisplay;
            parameters[11].Value = model.ImgWidth;
            parameters[12].Value = model.ImgHeight;

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
        public bool Update(YSWL.MALL.Model.Settings.FriendlyLink model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_FLinks set ");
            strSql.Append("Name=?Name,");
            strSql.Append("ImgUrl=?ImgUrl,");
            strSql.Append("LinkUrl=?LinkUrl,");
            strSql.Append("LinkDesc=?LinkDesc,");
            strSql.Append("State=?State,");
            strSql.Append("OrderID=?OrderID,");
            strSql.Append("ContactPerson=?ContactPerson,");
            strSql.Append("Email=?Email,");
            strSql.Append("TelPhone=?TelPhone,");
            strSql.Append("TypeID=?TypeID,");
            strSql.Append("IsDisplay=?IsDisplay,");
            strSql.Append("ImgWidth=?ImgWidth,");
            strSql.Append("ImgHeight=?ImgHeight");

            strSql.Append(" where ID=?ID");
            MySqlParameter[] parameters = {
				new MySqlParameter("?Name", MySqlDbType.VarString,50),
					new MySqlParameter("?ImgUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkUrl", MySqlDbType.VarString,200),
					new MySqlParameter("?LinkDesc", MySqlDbType.VarString,300),
					new MySqlParameter("?State", MySqlDbType.Int16,2),
					new MySqlParameter("?OrderID",  MySqlDbType.Int32,4),
					new MySqlParameter("?ContactPerson", MySqlDbType.VarString,30),
					new MySqlParameter("?Email", MySqlDbType.VarString,300),
					new MySqlParameter("?TelPhone", MySqlDbType.VarString,30),
					new MySqlParameter("?TypeID", MySqlDbType.Int16,2),
                    new MySqlParameter("?IsDisplay",MySqlDbType.Bit),
                    new MySqlParameter("?ImgWidth",MySqlDbType.Int32),
                    new MySqlParameter("?ImgHeight",MySqlDbType.Int32),
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)};

            parameters[0].Value = model.Name;
            parameters[1].Value = model.ImgUrl;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.LinkDesc;
            parameters[4].Value = model.State;
            parameters[5].Value = model.OrderID;
            parameters[6].Value = model.ContactPerson;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.TelPhone;
            parameters[9].Value = model.TypeID;
            parameters[10].Value = model.IsDisplay;
            parameters[11].Value = model.ImgWidth;
            parameters[12].Value = model.ImgHeight;
            parameters[13].Value = model.ID;

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
            strSql.Append("delete from CMS_FLinks ");
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
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_FLinks ");
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
        public YSWL.MALL.Model.Settings.FriendlyLink GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select    ID,Name,ImgUrl,LinkUrl,LinkDesc,State,OrderID,ContactPerson,Email,TelPhone,TypeID,IsDisplay,ImgWidth,ImgHeight from CMS_FLinks ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ID",  MySqlDbType.Int32,4)
};
            parameters[0].Value = ID;

            YSWL.MALL.Model.Settings.FriendlyLink model = new YSWL.MALL.Model.Settings.FriendlyLink();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ImgUrl"] != null)
                {
                    model.ImgUrl = ds.Tables[0].Rows[0]["ImgUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkUrl"] != null)
                {
                    model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LinkDesc"] != null)
                {
                    model.LinkDesc = ds.Tables[0].Rows[0]["LinkDesc"].ToString();
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContactPerson"] != null)
                {
                    model.ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"] != null)
                {
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TelPhone"] != null)
                {
                    model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDisplay"].ToString() != "")
                {
                    model.IsDisplay = bool.Parse(ds.Tables[0].Rows[0]["IsDisplay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgWidth"].ToString() != "")
                {
                    model.ImgWidth = int.Parse(ds.Tables[0].Rows[0]["ImgWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ImgHeight"].ToString() != "")
                {
                    model.ImgHeight = int.Parse(ds.Tables[0].Rows[0]["ImgHeight"].ToString());
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
            strSql.Append("select ID,Name,ImgUrl,LinkUrl,LinkDesc,State,OrderID,ContactPerson,Email,TelPhone,TypeID,IsDisplay,ImgWidth,ImgHeight ");
            strSql.Append(" FROM CMS_FLinks ");
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
            strSql.Append(" ID,Name,ImgUrl,LinkUrl,LinkDesc,State,OrderID,ContactPerson,Email,TelPhone,TypeID,IsDisplay,ImgWidth,ImgHeight ");
            strSql.Append(" FROM CMS_FLinks ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (filedOrder.Trim() != "")
            {
                strSql.Append(" order by " + filedOrder);
            }
            if (Top > 0)
            {
                strSql.Append(" LIMIT  " + Top.ToString());
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Settings.FriendlyLink> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Settings.FriendlyLink> modelList = new List<YSWL.MALL.Model.Settings.FriendlyLink>();
            if (DataTableTools.DataTableIsNull(dt))
            {
                return null;
            }
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Settings.FriendlyLink model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.Settings.FriendlyLink();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.Name = dt.Rows[n]["Name"].ToString();
                    model.ImgUrl = dt.Rows[n]["ImgUrl"].ToString();
                    model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
                    model.LinkDesc = dt.Rows[n]["LinkDesc"].ToString();
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    model.ContactPerson = dt.Rows[n]["ContactPerson"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    model.TelPhone = dt.Rows[n]["TelPhone"].ToString();
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["IsDisplay"].ToString() != "")
                    {
                        model.IsDisplay = bool.Parse(dt.Rows[n]["IsDisplay"].ToString());
                    }
                    if (dt.Rows[n]["ImgWidth"].ToString() != "")
                    {
                        model.ImgWidth = int.Parse(dt.Rows[n]["ImgWidth"].ToString());
                    }
                    if (dt.Rows[n]["ImgHeight"].ToString() != "")
                    {
                        model.ImgHeight = int.Parse(dt.Rows[n]["ImgHeight"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
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
            parameters[0].Value = "CMS_FLinks";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        /// <summary>
        /// 批量处理审核状态
        /// </summary>
        /// <param name="IDlist"></param>
        /// <returns></returns>
        public bool UpdateList(string IDlist, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_FLinks set " + strWhere);
            strSql.Append(" where ID in(" + IDlist + ")  ");
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
        public YSWL.MALL.Model.Settings.FriendlyLink DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Settings.FriendlyLink model = new YSWL.MALL.Model.Settings.FriendlyLink();
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
                if (row["ImgUrl"] != null)
                {
                    model.ImgUrl = row["ImgUrl"].ToString();
                }
                if (row["LinkUrl"] != null)
                {
                    model.LinkUrl = row["LinkUrl"].ToString();
                }
                if (row["LinkDesc"] != null)
                {
                    model.LinkDesc = row["LinkDesc"].ToString();
                }
                if (row["State"] != null && row["State"].ToString() != "")
                {
                    model.State = int.Parse(row["State"].ToString());
                }
                if (row["OrderID"] != null && row["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(row["OrderID"].ToString());
                }
                if (row["ContactPerson"] != null)
                {
                    model.ContactPerson = row["ContactPerson"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["TelPhone"] != null)
                {
                    model.TelPhone = row["TelPhone"].ToString();
                }
                if (row["TypeID"] != null && row["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(row["TypeID"].ToString());
                }
                if (row["IsDisplay"] != null && row["IsDisplay"].ToString() != "")
                {
                    if ((row["IsDisplay"].ToString() == "1") || (row["IsDisplay"].ToString().ToLower() == "true"))
                    {
                        model.IsDisplay = true;
                    }
                    else
                    {
                        model.IsDisplay = false;
                    }
                }
                if (row["ImgWidth"] != null && row["ImgWidth"].ToString() != "")
                {
                    model.ImgWidth = int.Parse(row["ImgWidth"].ToString());
                }
                if (row["ImgHeight"] != null && row["ImgHeight"].ToString() != "")
                {
                    model.ImgHeight = int.Parse(row["ImgHeight"].ToString());
                }
            }
            return model;
        }
        #endregion Method
    }
}