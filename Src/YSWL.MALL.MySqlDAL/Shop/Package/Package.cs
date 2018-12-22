using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Package;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.Package
{
	/// <summary>
	/// 数据访问类:Package
	/// </summary>
	public partial class Package:IPackage
	{
		public Package()
		{}
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("PackageId", "Shop_Package");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PackageId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Package");
            strSql.Append(" where PackageId=?PackageId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PackageId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PackageId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Package.Package model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_Package(");
            strSql.Append("CategoryId,Name,Description,PhotoUrl,NormalPhotoUrl,ThumbPhotoUrl,CreatedDate,Status,Remark)");
            strSql.Append(" values (");
            strSql.Append("?CategoryId,?Name,?Description,?PhotoUrl,?NormalPhotoUrl,?ThumbPhotoUrl,?CreatedDate,?Status,?Remark)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?PhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?NormalPhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?ThumbPhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.PhotoUrl;
            parameters[4].Value = model.NormalPhotoUrl;
            parameters[5].Value = model.ThumbPhotoUrl;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Remark;

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
        public bool Update(YSWL.MALL.Model.Shop.Package.Package model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Package set ");
            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("Name=?Name,");
            strSql.Append("Description=?Description,");
            strSql.Append("PhotoUrl=?PhotoUrl,");
            strSql.Append("NormalPhotoUrl=?NormalPhotoUrl,");
            strSql.Append("ThumbPhotoUrl=?ThumbPhotoUrl,");
            strSql.Append("CreatedDate=?CreatedDate,");
            strSql.Append("Status=?Status,");
            strSql.Append("Remark=?Remark");
            strSql.Append(" where PackageId=?PackageId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryId", MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarChar,100),
					new MySqlParameter("?Description", MySqlDbType.Text),
					new MySqlParameter("?PhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?NormalPhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?ThumbPhotoUrl", MySqlDbType.VarChar,300),
					new MySqlParameter("?CreatedDate", MySqlDbType.DateTime),
					new MySqlParameter("?Status", MySqlDbType.Int16,2),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,1000),
					new MySqlParameter("?PackageId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.CategoryId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.PhotoUrl;
            parameters[4].Value = model.NormalPhotoUrl;
            parameters[5].Value = model.ThumbPhotoUrl;
            parameters[6].Value = model.CreatedDate;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Remark;
            parameters[9].Value = model.PackageId;

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
        public bool Delete(int PackageId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Package ");
            strSql.Append(" where PackageId=?PackageId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PackageId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PackageId;

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
        public bool DeleteList(string PackageIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Package ");
            strSql.Append(" where PackageId in (" + PackageIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Package.Package GetModel(int PackageId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PackageId,CategoryId,Name,Description,PhotoUrl,NormalPhotoUrl,ThumbPhotoUrl,CreatedDate,Status,Remark from Shop_Package ");
            strSql.Append(" where PackageId=?PackageId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?PackageId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = PackageId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Package.Package model = new YSWL.MALL.Model.Shop.Package.Package();
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
        public YSWL.MALL.Model.Shop.Package.Package DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.Package.Package model = new YSWL.MALL.Model.Shop.Package.Package();
            if (row != null)
            {
                if (row["PackageId"] != null && row["PackageId"].ToString() != "")
                {
                    model.PackageId = int.Parse(row["PackageId"].ToString());
                }
                if (row["CategoryId"] != null && row["CategoryId"].ToString() != "")
                {
                    model.CategoryId = int.Parse(row["CategoryId"].ToString());
                }
                if (row["Name"] != null && row["Name"].ToString() != "")
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null && row["Description"].ToString() != "")
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["PhotoUrl"] != null && row["PhotoUrl"].ToString() != "")
                {
                    model.PhotoUrl = row["PhotoUrl"].ToString();
                }
                if (row["NormalPhotoUrl"] != null && row["NormalPhotoUrl"].ToString() != "")
                {
                    model.NormalPhotoUrl = row["NormalPhotoUrl"].ToString();
                }
                if (row["ThumbPhotoUrl"] != null && row["ThumbPhotoUrl"].ToString() != "")
                {
                    model.ThumbPhotoUrl = row["ThumbPhotoUrl"].ToString();
                }
                if (row["CreatedDate"] != null && row["CreatedDate"].ToString() != "")
                {
                    model.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Remark"] != null && row["Remark"].ToString() != "")
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
            strSql.Append("select PackageId,CategoryId,Name,Description,PhotoUrl,NormalPhotoUrl,ThumbPhotoUrl,CreatedDate,Status,Remark ");
            strSql.Append(" FROM Shop_Package ");
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
            
            strSql.Append(" PackageId,CategoryId,Name,Description,PhotoUrl,NormalPhotoUrl,ThumbPhotoUrl,CreatedDate,Status,Remark ");
            strSql.Append(" FROM Shop_Package ");
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
            strSql.Append("select count(1) FROM Shop_Package ");
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
            strSql.Append("SELECT T.* from Shop_Package T ");
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
                strSql.Append(" order by T.PackageId desc");
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
            parameters[0].Value = "Shop_Package";
            parameters[1].Value = "PackageId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        #region ExMethod

        public DataSet GetListEx(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p1.PackageId,p2.NAME CategoryName,p1.NAME PackageName,p1.description as description,p1.PhotoUrl,p1.CreatedDate,p1.Remark from Shop_Package p1 left join Shop_PackageCategory p2 on p1.CategoryId=p2.CategoryId ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());

        } 
        #endregion
	}
}

