using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.CMS;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.CMS
{
    /// <summary>
    /// 数据访问类:PhotoClass
    /// </summary>
    public class PhotoClass : IPhotoClass
    {
        public PhotoClass()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("ClassID", "CMS_PhotoClass");
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxSequence()
        {
            return DbHelperMySQL.GetMaxID("Sequence", "CMS_PhotoClass");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_PhotoClass");
            strSql.Append(" where ClassID=?ClassID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassID;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsByClassName(string ClassName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CMS_PhotoClass");
            strSql.Append(" where ClassName=?ClassName ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,200)};
            parameters[0].Value = ClassName;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Model.CMS.PhotoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CMS_PhotoClass(");
            strSql.Append("ClassName,ParentId,Sequence,Path,Depth)");
            strSql.Append(" values (");
            strSql.Append("?ClassName,?ParentId,?Sequence,?Path,?Depth)");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,200),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Depth;

            DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.CMS.PhotoClass model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CMS_PhotoClass set ");
            strSql.Append("ClassName=?ClassName,");
            strSql.Append("ParentId=?ParentId,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("Path=?Path,");
            strSql.Append("Depth=?Depth");
            strSql.Append(" where ClassID=?ClassID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassName", MySqlDbType.VarChar,200),
					new MySqlParameter("?ParentId",  MySqlDbType.Int32,4),
					new MySqlParameter("?Sequence",  MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,200),
					new MySqlParameter("?Depth",  MySqlDbType.Int32,4),
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.ClassName;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.ClassID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_PhotoClass ");
            strSql.Append(" where ClassID=?ClassID ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string ClassIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CMS_PhotoClass ");
            strSql.Append(" where ClassID in (" + ClassIDlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            return rows > 0;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.CMS.PhotoClass GetModel(int ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select   ClassID,ClassName,ParentId,Sequence,Path,Depth from CMS_PhotoClass ");
            strSql.Append(" where ClassID=?ClassID LIMIT 1");
            MySqlParameter[] parameters = {
					new MySqlParameter("?ClassID",  MySqlDbType.Int32,4)};
            parameters[0].Value = ClassID;

            Model.CMS.PhotoClass model = new Model.CMS.PhotoClass();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"] != null && ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassName"] != null && ds.Tables[0].Rows[0]["ClassName"].ToString() != "")
                {
                    model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ParentId"] != null && ds.Tables[0].Rows[0]["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(ds.Tables[0].Rows[0]["ParentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sequence"] != null && ds.Tables[0].Rows[0]["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(ds.Tables[0].Rows[0]["Sequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Path"] != null && ds.Tables[0].Rows[0]["Path"].ToString() != "")
                {
                    model.Path = ds.Tables[0].Rows[0]["Path"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Depth"] != null && ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                return model;
            }
            return null;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM CMS_PhotoClass ");
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
            strSql.Append(" ClassID,ClassName,ParentId,Sequence,Path,Depth ");
            strSql.Append(" FROM CMS_PhotoClass ");
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
            parameters[0].Value = "CMS_PhotoClass";
            parameters[1].Value = "ClassID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method
    }
}