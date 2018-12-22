using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Ms;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Ms
{
	/// <summary>
	/// 数据访问类:Regions
	/// </summary>
	public partial class Regions:IRegions
	{
		public Regions()
		{}
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("RegionId", "Ms_Regions");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Ms_Regions");
            strSql.Append(" where RegionId=?RegionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RegionId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.Regions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Ms_Regions(");
            strSql.Append("AreaId,ParentId,RegionName,Spell,SpellShort,DisplaySequence,Path,Depth)");
            strSql.Append(" values (");
            strSql.Append("?AreaId,?ParentId,?RegionName,?Spell,?SpellShort,?DisplaySequence,?Path,?Depth)");
            strSql.Append(";select last_insert_id();");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Spell", MySqlDbType.VarChar,50),
					new MySqlParameter("?SpellShort", MySqlDbType.VarChar,50),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,4000),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4)};
            parameters[0].Value = model.AreaId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RegionName;
            parameters[3].Value = model.Spell;
            parameters[4].Value = model.SpellShort;
            parameters[5].Value = model.DisplaySequence;
            parameters[6].Value = model.Path;
            parameters[7].Value = model.Depth;

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
        public bool Update(YSWL.MALL.Model.Ms.Regions model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Ms_Regions set ");
            strSql.Append("AreaId=?AreaId,");
            strSql.Append("ParentId=?ParentId,");
            strSql.Append("RegionName=?RegionName,");
            strSql.Append("Spell=?Spell,");
            strSql.Append("SpellShort=?SpellShort,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("Path=?Path,");
            strSql.Append("Depth=?Depth");
            strSql.Append(" where RegionId=?RegionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?AreaId", MySqlDbType.Int32,4),
					new MySqlParameter("?ParentId", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionName", MySqlDbType.VarChar,100),
					new MySqlParameter("?Spell", MySqlDbType.VarChar,50),
					new MySqlParameter("?SpellShort", MySqlDbType.VarChar,50),
					new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
					new MySqlParameter("?Path", MySqlDbType.VarChar,4000),
					new MySqlParameter("?Depth", MySqlDbType.Int32,4),
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)};
            parameters[0].Value = model.AreaId;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.RegionName;
            parameters[3].Value = model.Spell;
            parameters[4].Value = model.SpellShort;
            parameters[5].Value = model.DisplaySequence;
            parameters[6].Value = model.Path;
            parameters[7].Value = model.Depth;
            parameters[8].Value = model.RegionId;

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
        public bool Delete(int RegionId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Regions ");
            strSql.Append(" where RegionId=?RegionId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RegionId", MySqlDbType.Int32,4)
			};
            parameters[0].Value = RegionId;

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
        public bool DeleteList(string RegionIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Ms_Regions ");
            strSql.Append(" where RegionId in (" + RegionIdlist + ")  ");
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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Ms_Regions ");
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
            strSql.Append("SELECT  T.*  from Ms_Regions T ");
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
                strSql.Append(" order by T.RegionId desc");
            }
            strSql.AppendFormat("  LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);
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
            parameters[0].Value = "Ms_Regions";
            parameters[1].Value = "RegionId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region NewMethod
        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetProvinces()
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT TR.RegionId,RegionName FROM Ms_Regions TR ");
            str.Append("WHERE AreaId BETWEEN 1 AND 10 ");
            return DbHelperMySQL.Query(str.ToString());
        }
        /// <summary>
        /// 根据省份获取城市
        /// </summary>
        /// <param name="parentID"></param>
        /// <returns></returns>
        public DataSet GetCitys(int parentID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT RegionId,RegionName  ");
            str.Append("FROM Ms_Regions  ");
            str.Append("WHERE ParentId= " + parentID);
            return DbHelperMySQL.Query(str.ToString());
        }

        /// <summary>
        /// 获取读取父Id
        /// </summary>
        /// <param name="regionID"></param>
        /// <returns></returns>
        public DataTable GetParentID(int regionID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT ParentId  ");
            str.Append("FROM Ms_Regions  ");
            str.Append("WHERE RegionId= " + regionID);
            return DbHelperMySQL.Query(str.ToString()).Tables[0];
        }
        public int GetCurrentParentId(int regionId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT ParentId  ");
            str.Append("FROM Ms_Regions  ");
            str.Append("WHERE RegionId= " + regionId);
            object obj = DbHelperMySQL.GetSingle(str.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Ms.Regions DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Ms.Regions model = new YSWL.MALL.Model.Ms.Regions();
            if (row != null)
            {
                if (row["AreaId"] != null && row["AreaId"].ToString() != "")
                {
                    model.AreaId = int.Parse(row["AreaId"].ToString());
                }
                if (row["RegionId"] != null && row["RegionId"].ToString() != "")
                {
                    model.RegionId = int.Parse(row["RegionId"].ToString());
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["RegionName"] != null)
                {
                    model.RegionName = row["RegionName"].ToString();
                }
                if (row["Spell"] != null)
                {
                    model.Spell = row["Spell"].ToString();
                }
                if (row["SpellShort"] != null)
                {
                    model.SpellShort = row["SpellShort"].ToString();
                }
                if (row["DisplaySequence"] != null && row["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(row["DisplaySequence"].ToString());
                }
                if (row["Path"] != null)
                {
                    model.Path = row["Path"].ToString();
                }
                if (row["Depth"] != null && row["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(row["Depth"].ToString());
                }
            }
            return model;
        }



        public Model.Ms.Regions GetModel(int RegionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  AreaId,RegionId,ParentId,RegionName,Spell,SpellShort,DisplaySequence,Path,Depth from Ms_Regions ");
            strSql.Append(" where RegionId=?RegionId LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?RegionId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = RegionId;

            YSWL.MALL.Model.Ms.Regions model = new YSWL.MALL.Model.Ms.Regions();
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

        public DataSet GetPrivoces()
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * FROM Ms_Regions  ");
            str.Append("WHERE Depth=1 ");
            return DbHelperMySQL.Query(str.ToString());
        }

        public DataSet GetPrivoceName()
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT TR.RegionId,RegionName FROM Ms_Regions TR ");
            str.Append("WHERE AreaId BETWEEN 1 AND 10 ");
            return DbHelperMySQL.Query(str.ToString());
        }

        public DataSet GetRegionName(string parentID)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT RegionId,RegionName ");
            str.Append("FROM Ms_Regions  ");
            str.Append("WHERE ParentId= " + parentID);
            return DbHelperMySQL.Query(str.ToString());
        }

        public DataSet GetDistrictByParentId(int iParentId)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT *  ");
            str.Append("FROM Ms_Regions  ");
            str.Append("WHERE ParentId= " + iParentId);
            return DbHelperMySQL.Query(str.ToString());
        }

        public DataSet GetAllCityList()
        {
            string strSql = "SELECT * FROM MS_Regions where Depth=2";
            return DbHelperMySQL.Query(strSql);
        }

        public string GetPath(int regid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Path FROM MS_Regions ");
            strSql.Append("WHERE RegionId= " + regid);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "0.";
            }
        }

        public System.Collections.Generic.List<string> GetRegionNameByRID(int RID)
        {
            string path = GetPath(RID) + RID.ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM MS_Regions ");
            strSql.Append("WHERE RegionId in (" + path + ")");
            DataSet ds = DbHelperMySQL.Query(strSql.ToString());
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            if (ds != null && ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    string RegionName = dr["RegionName"].ToString();
                    //if (!(i == 0 && (RegionName == "北京" || RegionName == "上海" || RegionName == "天津" || RegionName == "重庆")))
                    //{
                    //    strReg.Append(RegionName);
                    //}
                    list.Add(RegionName);
                }
            }
            return list;
        }

        public int GetRegPath(int? regid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Depth FROM MS_Regions ");
            strSql.Append("WHERE RegionId= " + regid.Value);
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public DataSet GetParentIDs(int regID, out int Count)
        {
            MySqlParameter[] para = { 
                                  new MySqlParameter("_Region",MySqlDbType.Int32),
                                  new MySqlParameter("_Count",MySqlDbType.Int32)
                                  };
            para[0].Value = regID;
            para[1].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperMySQL.RunProcedure("sp_Accounts_GetRegionID", para, "ds");
            Count = Convert.ToInt32(para[1].Value);
            return ds;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Ms_Regions ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

	    /// <summary>
	    /// 更新多条数据的AreaID
	    /// </summary>
	    public bool UpdateAreaID(string regionlist,int AreaId)
	    {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" UPDATE    Ms_Regions SET  AreaId= ?AreaId ");
            strSql.Append(" where RegionId in (" + regionlist + ")  ");
	        MySqlParameter[] sqlpar = {new  MySqlParameter("?AreaId",AreaId)};
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(),sqlpar);
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
        /// 根据AreaID获取到Regionids
        /// </summary>
        /// <param name="areaid"></param>
        /// <returns></returns>
	    public string   GetRegionIDsByAreaId(int areaid)
        {
            StringBuilder returnstr = new StringBuilder();
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT  RegionId ");
            strSql.Append(" FROM Ms_Regions ");
            strSql.Append(" where  AreaId=" +areaid);
            using (MySqlDataReader reader = DbHelperMySQL.ExecuteReader(strSql.ToString()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        returnstr.Append("'" +reader["RegionId"] + "',");
                    }
                }
            }
            return returnstr.ToString().TrimEnd(',');
        }

        public DataSet GetSamePathArea(int regionId)
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("select * from Ms_Regions  ");
            sb.Append("where ParentId=(");
            sb.Append("SELECT ParentId FROM Ms_Regions where regionId="+regionId);
            sb.Append(")");
            return DbHelperMySQL.Query(sb.ToString());
        }

        public bool IsParentRegion(int regionId)
        {
           StringBuilder strSql = new StringBuilder();
           strSql.AppendFormat(" select count(1) from Ms_Regions where ParentId= {0} ",regionId);
           object obj = DbHelperMySQL.GetSingle(strSql.ToString());
           if (obj ==null)
            {
                return false;
            }
               if (!(Convert.ToInt32(obj) > 0))
               {
                   return false;
               }
            else
            {
                return true;
            }
         
        }
        #endregion


        public bool Exists(string strWhere)
        {
            throw new NotImplementedException();
        }
    }
}

