/**
* GroupBuy.cs
*
* 功 能： N/A
* 类 名： GroupBuy
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2013/10/14 15:51:55   N/A    初版
*
* Copyright (c) 2012-2013 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.PromoteSales;
using YSWL.DBUtility;
using MySql.Data.MySqlClient;
namespace YSWL.MALL.MySqlDAL.Shop.PromoteSales
{
    /// <summary>
    /// 数据访问类:GroupBuy
    /// </summary>
    public partial class GroupBuy : IGroupBuy
    {
        public GroupBuy()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("GroupBuyId", "Shop_GroupBuy");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int GroupBuyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_GroupBuy");
            strSql.Append(" where GroupBuyId=?GroupBuyId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupBuyId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Shop.PromoteSales.GroupBuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Shop_GroupBuy(");
            strSql.Append("ProductId,Sequence,FinePrice,StartDate,EndDate,MaxCount,GroupCount,BuyCount,Price,Status,Description,RegionId,ProductName,ProductCategory,GroupBuyImage,CategoryId,CategoryPath,LimitQty)");
            strSql.Append(" values (");
            strSql.Append("?ProductId,?Sequence,?FinePrice,?StartDate,?EndDate,?MaxCount,?GroupCount,?BuyCount,?Price,?Status,?Description,?RegionId,?ProductName,?ProductCategory,?GroupBuyImage,?CategoryId,?CategoryPath,?LimitQty)");
            strSql.Append(";select last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?FinePrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                    new MySqlParameter("?EndDate", MySqlDbType.DateTime),
                    new MySqlParameter("?MaxCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?GroupCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Description", MySqlDbType.Text),
                    new MySqlParameter("?RegionId",MySqlDbType.Int32) ,
                      new MySqlParameter("?ProductName",MySqlDbType.VarChar) ,
                        new MySqlParameter("?ProductCategory",MySqlDbType.VarChar) ,
                          new MySqlParameter("?GroupBuyImage",MySqlDbType.VarChar) ,
                                        new MySqlParameter("?CategoryId",MySqlDbType.Int32) ,
                      new MySqlParameter("?CategoryPath",MySqlDbType.VarChar),
                       new MySqlParameter("?LimitQty",MySqlDbType.Int32)                  
                                        };
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.Sequence;
            parameters[2].Value = model.FinePrice;
            parameters[3].Value = model.StartDate;
            parameters[4].Value = model.EndDate;
            parameters[5].Value = model.MaxCount;
            parameters[6].Value = model.GroupCount;
            parameters[7].Value = model.BuyCount;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.RegionId;
            parameters[12].Value = model.ProductName;
            parameters[13].Value = model.ProductCategory;
            parameters[14].Value = model.GroupBuyImage;
            parameters[15].Value = model.CategoryId;
            parameters[16].Value = model.CategoryPath;
            parameters[17].Value = model.LimitQty;
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
        public bool Update(YSWL.MALL.Model.Shop.PromoteSales.GroupBuy model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_GroupBuy set ");
            strSql.Append("ProductId=?ProductId,");
            strSql.Append("Sequence=?Sequence,");
            strSql.Append("FinePrice=?FinePrice,");
            strSql.Append("StartDate=?StartDate,");
            strSql.Append("EndDate=?EndDate,");
            strSql.Append("MaxCount=?MaxCount,");
            strSql.Append("GroupCount=?GroupCount,");
            strSql.Append("BuyCount=?BuyCount,");
            strSql.Append("Price=?Price,");
            strSql.Append("Status=?Status,");
            strSql.Append("Description=?Description,");
            strSql.Append("RegionId=?RegionId,");

            strSql.Append("ProductName=?ProductName,");
            strSql.Append("ProductCategory=?ProductCategory,");
            strSql.Append("GroupBuyImage=?GroupBuyImage,");

            strSql.Append("CategoryId=?CategoryId,");
            strSql.Append("CategoryPath=?CategoryPath,");
            strSql.Append("LimitQty=?LimitQty");
            strSql.Append(" where GroupBuyId=?GroupBuyId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64,8),
                    new MySqlParameter("?Sequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?FinePrice", MySqlDbType.Decimal,8),
                    new MySqlParameter("?StartDate", MySqlDbType.DateTime),
                    new MySqlParameter("?EndDate", MySqlDbType.DateTime),
                    new MySqlParameter("?MaxCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?GroupCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                    new MySqlParameter("?Price", MySqlDbType.Decimal,8),
                    new MySqlParameter("?Status", MySqlDbType.Int32,4),
                    new MySqlParameter("?Description", MySqlDbType.Text),
                    new MySqlParameter("?RegionId",MySqlDbType.Int32), 
                    new MySqlParameter("?ProductName",MySqlDbType.VarChar) ,
                        new MySqlParameter("?ProductCategory",MySqlDbType.VarChar) ,
                          new MySqlParameter("?GroupBuyImage",MySqlDbType.VarChar),
                             new MySqlParameter("?CategoryId",MySqlDbType.Int32) ,
                      new MySqlParameter("?CategoryPath",MySqlDbType.VarChar) ,
                    new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4),
                                        new MySqlParameter("?LimitQty",MySqlDbType.Int32)
                                        };
            parameters[0].Value = model.ProductId;
            parameters[1].Value = model.Sequence;
            parameters[2].Value = model.FinePrice;
            parameters[3].Value = model.StartDate;
            parameters[4].Value = model.EndDate;
            parameters[5].Value = model.MaxCount;
            parameters[6].Value = model.GroupCount;
            parameters[7].Value = model.BuyCount;
            parameters[8].Value = model.Price;
            parameters[9].Value = model.Status;
            parameters[10].Value = model.Description;
            parameters[11].Value = model.RegionId;
            parameters[12].Value = model.ProductName;
            parameters[13].Value = model.ProductCategory;
            parameters[14].Value = model.GroupBuyImage;
            parameters[15].Value = model.CategoryId;
            parameters[16].Value = model.CategoryPath;
            parameters[17].Value = model.GroupBuyId;
            parameters[18].Value = model.LimitQty;
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
        public bool Delete(int GroupBuyId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_GroupBuy ");
            strSql.Append(" where GroupBuyId=?GroupBuyId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupBuyId;

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
        public bool DeleteList(string GroupBuyIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Shop_GroupBuy ");
            strSql.Append(" where GroupBuyId in (" + GroupBuyIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.PromoteSales.GroupBuy GetModel(int GroupBuyId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  GroupBuyId,ProductId,Sequence,FinePrice,StartDate,EndDate,MaxCount,GroupCount,BuyCount,Price,Status,Description,RegionId,ProductName,ProductCategory,GroupBuyImage,CategoryId,CategoryPath,LimitQty from Shop_GroupBuy ");
            strSql.Append(" where GroupBuyId=?GroupBuyId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4)
            };
            parameters[0].Value = GroupBuyId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.PromoteSales.GroupBuy model = new YSWL.MALL.Model.Shop.PromoteSales.GroupBuy();
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
        public YSWL.MALL.Model.Shop.PromoteSales.GroupBuy DataRowToModel(DataRow row)
        {
            YSWL.MALL.Model.Shop.PromoteSales.GroupBuy model = new YSWL.MALL.Model.Shop.PromoteSales.GroupBuy();
            if (row != null)
            {
                if (row["GroupBuyId"] != null && row["GroupBuyId"].ToString() != "")
                {
                    model.GroupBuyId = int.Parse(row["GroupBuyId"].ToString());
                }
                if (row["ProductId"] != null && row["ProductId"].ToString() != "")
                {
                    model.ProductId = long.Parse(row["ProductId"].ToString());
                }
                if (row["Sequence"] != null && row["Sequence"].ToString() != "")
                {
                    model.Sequence = int.Parse(row["Sequence"].ToString());
                }
                if (row["FinePrice"] != null && row["FinePrice"].ToString() != "")
                {
                    model.FinePrice = decimal.Parse(row["FinePrice"].ToString());
                }
                if (row["StartDate"] != null && row["StartDate"].ToString() != "")
                {
                    model.StartDate = DateTime.Parse(row["StartDate"].ToString());
                }
                if (row["EndDate"] != null && row["EndDate"].ToString() != "")
                {
                    model.EndDate = DateTime.Parse(row["EndDate"].ToString());
                }
                if (row["MaxCount"] != null && row["MaxCount"].ToString() != "")
                {
                    model.MaxCount = int.Parse(row["MaxCount"].ToString());
                }
                if (row["GroupCount"] != null && row["GroupCount"].ToString() != "")
                {
                    model.GroupCount = int.Parse(row["GroupCount"].ToString());
                }
                if (row["BuyCount"] != null && row["BuyCount"].ToString() != "")
                {
                    model.BuyCount = int.Parse(row["BuyCount"].ToString());
                }
                if (row["Price"] != null && row["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(row["Price"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["RegionId"] != null)
                {
                    model.RegionId = Common.Globals.SafeInt(row["RegionId"], -1);
                }
                //,ProductName,ProductCategory,GroupBuyImage
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["ProductCategory"] != null)
                {
                    model.ProductCategory = row["ProductCategory"].ToString();
                }
                if (row["GroupBuyImage"] != null)
                {
                    model.GroupBuyImage = row["GroupBuyImage"].ToString();
                }
                if (row["CategoryId"] != null)
                {
                    model.CategoryId = Common.Globals.SafeInt(row["CategoryId"], 0);
                }
                if (row["CategoryPath"] != null)
                {
                    model.CategoryPath = row["CategoryPath"].ToString();
                }
                if (row["LimitQty"] != null)
                {
                    model.LimitQty = int.Parse(row["LimitQty"].ToString());
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
            strSql.Append("select GroupBuyId,ProductId,Sequence,FinePrice,StartDate,EndDate,MaxCount,GroupCount,BuyCount,Price,Status,Description,RegionId,ProductName,ProductCategory,GroupBuyImage,CategoryId,CategoryPath,LimitQty ");
            strSql.Append(" FROM Shop_GroupBuy ");
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
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" GroupBuyId,ProductId,Sequence,FinePrice,StartDate,EndDate,MaxCount,GroupCount,BuyCount,Price,Status,Description,RegionId,ProductName,ProductCategory,GroupBuyImage,CategoryId,CategoryPath,LimitQty ");
            strSql.Append(" FROM Shop_GroupBuy ");
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
            strSql.Append("select count(1) FROM Shop_GroupBuy ");
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
            strSql.Append("SELECT T.* from Shop_GroupBuy T ");
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
                strSql.Append(" order by T.GroupBuyId desc");
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
            parameters[0].Value = "Shop_GroupBuy";
            parameters[1].Value = "GroupBuyId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod


        public int MaxSequence()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(Sequence) AS Sequence FROM Shop_GroupBuy");
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

        public bool IsExists(long ProductId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Shop_GroupBuy");
            strSql.Append(" where ProductId=?ProductId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?ProductId", MySqlDbType.Int64)
            };
            parameters[0].Value = ProductId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        public bool UpdateStatus(string ids, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_GroupBuy set ");
            strSql.Append("Status=?Status");
            strSql.Append(" where GroupBuyId in (" + ids + ")  ");
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
        /// <summary>
        /// 更新购买数量
        /// </summary>
        /// <param name="buyId"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool UpdateBuyCount(int buyId, int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Shop_GroupBuy set ");
            strSql.Append("BuyCount=BuyCount+?BuyCount");
            strSql.Append(" where GroupBuyId =?GroupBuyId ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?BuyCount", MySqlDbType.Int32,4),
                        new MySqlParameter("?GroupBuyId", MySqlDbType.Int32,4)
                                        };
            parameters[0].Value = count;
            parameters[1].Value = buyId;

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

        public DataSet GetListByPage(string strWhere, int cid, int regionId, string orderby, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            if (regionId > 0)//有选择地区
            {
                strSql.Append("T.*  from Shop_GroupBuy T,Ms_Regions R  ");
                strSql.AppendFormat(" where  (R.ParentId={0} or R.RegionId={0}) And R.RegionId=T.RegionId", regionId);
                strSql.Append(" And  T.Status = 1 AND T.EndDate>=now()  AND T.StartDate<=now() ");
            }
            else
            {
                strSql.Append("T.*  from Shop_GroupBuy T  ");
                strSql.Append(" where   T.Status = 1 AND T.EndDate>=now()  AND T.StartDate<=now() ");
            }

            if (cid > 0)//有cid不是默认过来的
            {
                strSql.AppendFormat(" And    (CategoryPath LIKE (SELECT Path FROM Shop_Categories WHERE CategoryId={0})+'|%' ", cid);
                strSql.AppendFormat(" OR T.CategoryId = {0})", cid);
                //strSql.AppendFormat("  And  T.ProductCategory='{0}'", cate);
            }
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append("  And  " + strWhere);
            }

            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.GroupBuyId desc");
            }
            strSql.AppendFormat(" LIMIT {0} , {1}", startIndex - 1, endIndex - startIndex + 1);

            return DbHelperMySQL.Query(strSql.ToString());
        }

        public int GetCount(string strWhere, int regionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM  Shop_GroupBuy T,Ms_Regions R  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append("And R.RegionId=T.RegionId");
            }
            else
            {
                strSql.Append("where R.RegionId=T.RegionId");
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
        public DataSet GetCategory(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   select * from Shop_GroupBuy T  ");
            sb.Append(" where GroupBuyId=(");
            sb.Append("select min(GroupBuyId) from Shop_GroupBuy");
            sb.Append("  where T.CategoryId=CategoryId)");
            //sb.Append(" And ");
            //sb.Append("   T.Status = 1 AND T.EndDate>=now()  AND T.StartDate<=now() ");
            if (!string.IsNullOrWhiteSpace(strWhere))
            {
                sb.AppendFormat(" And  {0}", strWhere);
            }
            return DbHelperMySQL.Query(sb.ToString());
        }

        #endregion  ExtensionMethod
    }
}

