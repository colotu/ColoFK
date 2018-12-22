using System;
using System.Data;
using System.Text;
using YSWL.DBUtility;
using YSWL.MALL.IDAL.Shop.Gift;
using MySql.Data.MySqlClient;

namespace YSWL.MALL.MySqlDAL.Shop.Gift
{
    /// <summary>
    /// 数据访问类:Gifts
    /// </summary>
    public partial class Gifts : IGifts
    {
        public Gifts()
        { }

        #region Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("GiftId", "Shop_Gifts");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GiftId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_Gifts");
            strSql.Append(" where GiftId=?GiftId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?GiftId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = GiftId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.Gift.Gifts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_Gifts(");
            strSql.Append("CategoryID,Name,ShortDescription,Unit,Weight,LongDescription,Title,Meta_Description,Meta_Keywords,ThumbnailsUrl,InFocusImageUrl,CostPrice,MarketPrice,SalePrice,Stock,NeedPoint,NeedGrade,SaleCounts,CreateDate,Enabled)");
            strSql.Append(" values (");
            strSql.Append("?CategoryID,?Name,?ShortDescription,?Unit,?Weight,?LongDescription,?Title,?Meta_Description,?Meta_Keywords,?ThumbnailsUrl,?InFocusImageUrl,?CostPrice,?MarketPrice,?SalePrice,?Stock,?NeedPoint,?NeedGrade,?SaleCounts,?CreateDate,?Enabled)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarString,2000),
					new MySqlParameter("?Unit", MySqlDbType.VarString,50),
					new MySqlParameter("?Weight",  MySqlDbType.Int32,4),
					new MySqlParameter("?LongDescription", MySqlDbType.LongText),
					new MySqlParameter("?Title", MySqlDbType.VarString,100),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarString,1000),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarString,255),
					new MySqlParameter("?InFocusImageUrl", MySqlDbType.VarString,255),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Stock",  MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint",  MySqlDbType.Int32,4),
					new MySqlParameter("?NeedGrade",  MySqlDbType.Int32,4),
					new MySqlParameter("?SaleCounts",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?Enabled", MySqlDbType.Bit,1)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.Weight;
            parameters[5].Value = model.LongDescription;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Meta_Description;
            parameters[8].Value = model.Meta_Keywords;
            parameters[9].Value = model.ThumbnailsUrl;
            parameters[10].Value = model.InFocusImageUrl;
            parameters[11].Value = model.CostPrice;
            parameters[12].Value = model.MarketPrice;
            parameters[13].Value = model.SalePrice;
            parameters[14].Value = model.Stock;
            parameters[15].Value = model.NeedPoint;
            parameters[16].Value = model.NeedGrade;
            parameters[17].Value = model.SaleCounts;
            parameters[18].Value = model.CreateDate;
            parameters[19].Value = model.Enabled;

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
        public bool Update(YSWL.MALL.Model.Shop.Gift.Gifts model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Gifts set ");
            strSql.Append("CategoryID=?CategoryID,");
            strSql.Append("Name=?Name,");
            strSql.Append("ShortDescription=?ShortDescription,");
            strSql.Append("Unit=?Unit,");
            strSql.Append("Weight=?Weight,");
            strSql.Append("LongDescription=?LongDescription,");
            strSql.Append("Title=?Title,");
            strSql.Append("Meta_Description=?Meta_Description,");
            strSql.Append("Meta_Keywords=?Meta_Keywords,");
            strSql.Append("ThumbnailsUrl=?ThumbnailsUrl,");
            strSql.Append("InFocusImageUrl=?InFocusImageUrl,");
            strSql.Append("CostPrice=?CostPrice,");
            strSql.Append("MarketPrice=?MarketPrice,");
            strSql.Append("SalePrice=?SalePrice,");
            strSql.Append("Stock=?Stock,");
            strSql.Append("NeedPoint=?NeedPoint,");
            strSql.Append("NeedGrade=?NeedGrade,");
            strSql.Append("SaleCounts=?SaleCounts,");
            strSql.Append("CreateDate=?CreateDate,");
            strSql.Append("Enabled=?Enabled");
            strSql.Append(" where GiftId=?GiftId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?CategoryID",  MySqlDbType.Int32,4),
					new MySqlParameter("?Name", MySqlDbType.VarString,100),
					new MySqlParameter("?ShortDescription", MySqlDbType.VarString,2000),
					new MySqlParameter("?Unit", MySqlDbType.VarString,50),
					new MySqlParameter("?Weight",  MySqlDbType.Int32,4),
					new MySqlParameter("?LongDescription", MySqlDbType.LongText),
					new MySqlParameter("?Title", MySqlDbType.VarString,100),
					new MySqlParameter("?Meta_Description", MySqlDbType.VarString,1000),
					new MySqlParameter("?Meta_Keywords", MySqlDbType.VarString,1000),
					new MySqlParameter("?ThumbnailsUrl", MySqlDbType.VarString,255),
					new MySqlParameter("?InFocusImageUrl", MySqlDbType.VarString,255),
					new MySqlParameter("?CostPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?MarketPrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?SalePrice", MySqlDbType.Decimal,8),
					new MySqlParameter("?Stock",  MySqlDbType.Int32,4),
					new MySqlParameter("?NeedPoint",  MySqlDbType.Int32,4),
					new MySqlParameter("?NeedGrade",  MySqlDbType.Int32,4),
					new MySqlParameter("?SaleCounts",  MySqlDbType.Int32,4),
					new MySqlParameter("?CreateDate", MySqlDbType.DateTime),
					new MySqlParameter("?Enabled", MySqlDbType.Bit,1),
					new MySqlParameter("?GiftId",  MySqlDbType.Int32,4)};
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.ShortDescription;
            parameters[3].Value = model.Unit;
            parameters[4].Value = model.Weight;
            parameters[5].Value = model.LongDescription;
            parameters[6].Value = model.Title;
            parameters[7].Value = model.Meta_Description;
            parameters[8].Value = model.Meta_Keywords;
            parameters[9].Value = model.ThumbnailsUrl;
            parameters[10].Value = model.InFocusImageUrl;
            parameters[11].Value = model.CostPrice;
            parameters[12].Value = model.MarketPrice;
            parameters[13].Value = model.SalePrice;
            parameters[14].Value = model.Stock;
            parameters[15].Value = model.NeedPoint;
            parameters[16].Value = model.NeedGrade;
            parameters[17].Value = model.SaleCounts;
            parameters[18].Value = model.CreateDate;
            parameters[19].Value = model.Enabled;
            parameters[20].Value = model.GiftId;

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
        public bool Delete(int GiftId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Gifts ");
            strSql.Append(" where GiftId=?GiftId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?GiftId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = GiftId;

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
        public bool DeleteList(string GiftIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_Gifts ");
            strSql.Append(" where GiftId in (" + GiftIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Gift.Gifts GetModel(int GiftId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  GiftId,CategoryID,Name,ShortDescription,Unit,Weight,LongDescription,Title,Meta_Description,Meta_Keywords,ThumbnailsUrl,InFocusImageUrl,CostPrice,MarketPrice,SalePrice,Stock,NeedPoint,NeedGrade,SaleCounts,CreateDate,Enabled from Shop_Gifts ");
            strSql.Append(" where GiftId=?GiftId  LIMIT 1 ");
            MySqlParameter[] parameters = {
					new MySqlParameter("?GiftId",  MySqlDbType.Int32,4)
			};
            parameters[0].Value = GiftId;

            YSWL.MALL.Model.Shop.Gift.Gifts model = new YSWL.MALL.Model.Shop.Gift.Gifts();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["GiftId"] != null && ds.Tables[0].Rows[0]["GiftId"].ToString() != "")
                {
                    model.GiftId = int.Parse(ds.Tables[0].Rows[0]["GiftId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CategoryID"] != null && ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ShortDescription"] != null && ds.Tables[0].Rows[0]["ShortDescription"].ToString() != "")
                {
                    model.ShortDescription = ds.Tables[0].Rows[0]["ShortDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Unit"] != null && ds.Tables[0].Rows[0]["Unit"].ToString() != "")
                {
                    model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Weight"] != null && ds.Tables[0].Rows[0]["Weight"].ToString() != "")
                {
                    model.Weight = int.Parse(ds.Tables[0].Rows[0]["Weight"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LongDescription"] != null && ds.Tables[0].Rows[0]["LongDescription"].ToString() != "")
                {
                    model.LongDescription = ds.Tables[0].Rows[0]["LongDescription"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null && ds.Tables[0].Rows[0]["Title"].ToString() != "")
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Description"] != null && ds.Tables[0].Rows[0]["Meta_Description"].ToString() != "")
                {
                    model.Meta_Description = ds.Tables[0].Rows[0]["Meta_Description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Meta_Keywords"] != null && ds.Tables[0].Rows[0]["Meta_Keywords"].ToString() != "")
                {
                    model.Meta_Keywords = ds.Tables[0].Rows[0]["Meta_Keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ThumbnailsUrl"] != null && ds.Tables[0].Rows[0]["ThumbnailsUrl"].ToString() != "")
                {
                    model.ThumbnailsUrl = ds.Tables[0].Rows[0]["ThumbnailsUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["InFocusImageUrl"] != null && ds.Tables[0].Rows[0]["InFocusImageUrl"].ToString() != "")
                {
                    model.InFocusImageUrl = ds.Tables[0].Rows[0]["InFocusImageUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CostPrice"] != null && ds.Tables[0].Rows[0]["CostPrice"].ToString() != "")
                {
                    model.CostPrice = decimal.Parse(ds.Tables[0].Rows[0]["CostPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MarketPrice"] != null && ds.Tables[0].Rows[0]["MarketPrice"].ToString() != "")
                {
                    model.MarketPrice = decimal.Parse(ds.Tables[0].Rows[0]["MarketPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SalePrice"] != null && ds.Tables[0].Rows[0]["SalePrice"].ToString() != "")
                {
                    model.SalePrice = decimal.Parse(ds.Tables[0].Rows[0]["SalePrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Stock"] != null && ds.Tables[0].Rows[0]["Stock"].ToString() != "")
                {
                    model.Stock = int.Parse(ds.Tables[0].Rows[0]["Stock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NeedPoint"] != null && ds.Tables[0].Rows[0]["NeedPoint"].ToString() != "")
                {
                    model.NeedPoint = int.Parse(ds.Tables[0].Rows[0]["NeedPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NeedGrade"] != null && ds.Tables[0].Rows[0]["NeedGrade"].ToString() != "")
                {
                    model.NeedGrade = int.Parse(ds.Tables[0].Rows[0]["NeedGrade"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SaleCounts"] != null && ds.Tables[0].Rows[0]["SaleCounts"].ToString() != "")
                {
                    model.SaleCounts = int.Parse(ds.Tables[0].Rows[0]["SaleCounts"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"] != null && ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Enabled"] != null && ds.Tables[0].Rows[0]["Enabled"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Enabled"].ToString() == "1") || (ds.Tables[0].Rows[0]["Enabled"].ToString().ToLower() == "true"))
                    {
                        model.Enabled = true;
                    }
                    else
                    {
                        model.Enabled = false;
                    }
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
            strSql.Append("select GiftId,CategoryID,Name,ShortDescription,Unit,Weight,LongDescription,Title,Meta_Description,Meta_Keywords,ThumbnailsUrl,InFocusImageUrl,CostPrice,MarketPrice,SalePrice,Stock,NeedPoint,NeedGrade,SaleCounts,CreateDate,Enabled ");
            strSql.Append(" FROM Shop_Gifts ");
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
            strSql.Append(" GiftId,CategoryID,Name,ShortDescription,Unit,Weight,LongDescription,Title,Meta_Description,Meta_Keywords,ThumbnailsUrl,InFocusImageUrl,CostPrice,MarketPrice,SalePrice,Stock,NeedPoint,NeedGrade,SaleCounts,CreateDate,Enabled ");
            strSql.Append(" FROM Shop_Gifts ");
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
            strSql.Append("select count(1) FROM Shop_Gifts ");
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
            strSql.Append("SELECT  T.*  from Shop_Gifts T ");
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
                strSql.Append(" order by T.GiftId desc");
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
            parameters[0].Value = "Shop_Gifts";
            parameters[1].Value = "GiftId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion Method

        #region 扩展方法

        public bool UpdateStock(int giftid, int stock)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_Gifts set ");
            strSql.Append("Stock=?Stock");
            strSql.Append(" where GiftId=?GiftId");
            MySqlParameter[] parameters = {
					new MySqlParameter("?Stock",  MySqlDbType.Int32,4),
					new MySqlParameter("?GiftId",  MySqlDbType.Int32,4)};
            parameters[0].Value = stock;
            parameters[1].Value = giftid;

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

        #endregion 扩展方法
    }
}