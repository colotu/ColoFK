/*----------------------------------------------------------------
// Copyright (C) 2012 云商未来 版权所有。
//
// 文件名：Attributes.cs
// 文件功能描述：
// 
// 创建标识： [Ben]  2012/06/11 20:36:22
// 修改标识： [Rock]  2012年6月14日 17:08:19
// 修改描述： 新增  AttributeManage 放法
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Shop.Products;
using YSWL.DBUtility;
using YSWL.MALL.Model.Shop.Products;
using MySql.Data.MySqlClient;


namespace YSWL.MALL.MySqlDAL.Shop.Products
{
    /// <summary>
    /// 数据访问类:AttributeInfo
    /// </summary>
    public partial class AttributeInfo : IAttributeInfo
    {
        public AttributeInfo()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long AttributeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_Attributes");
            strSql.Append(" WHERE AttributeId=?AttributeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64)
            };
            parameters[0].Value = AttributeId;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(YSWL.MALL.Model.Shop.Products.AttributeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Shop_Attributes(");
            strSql.Append("AttributeName,DisplaySequence,TypeId,UsageMode,UseAttributeImage)");
            strSql.Append(" VALUES (");
            strSql.Append("?AttributeName,?DisplaySequence,?TypeId,?UsageMode,?UseAttributeImage)");
            strSql.Append(";SELECT last_insert_id()");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AttributeName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UsageMode", MySqlDbType.Int32,4),
                    new MySqlParameter("?UseAttributeImage", MySqlDbType.Bit,1)};
            parameters[0].Value = model.AttributeName;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.TypeId;
            parameters[3].Value = model.UsageMode;
            parameters[4].Value = model.UseAttributeImage;

            object obj = DbHelperMySQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Shop.Products.AttributeInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_Attributes SET ");
            strSql.Append("AttributeName=?AttributeName,");
            strSql.Append("DisplaySequence=?DisplaySequence,");
            strSql.Append("TypeId=?TypeId,");
            strSql.Append("UsageMode=?UsageMode,");
            strSql.Append("UseAttributeImage=?UseAttributeImage");
            strSql.Append(" WHERE AttributeId=?AttributeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AttributeName", MySqlDbType.VarChar,50),
                    new MySqlParameter("?DisplaySequence", MySqlDbType.Int32,4),
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                    new MySqlParameter("?UsageMode", MySqlDbType.Int32,4),
                    new MySqlParameter("?UseAttributeImage", MySqlDbType.Bit,1),
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64,8)};
            parameters[0].Value = model.AttributeName;
            parameters[1].Value = model.DisplaySequence;
            parameters[2].Value = model.TypeId;
            parameters[3].Value = model.UsageMode;
            parameters[4].Value = model.UseAttributeImage;
            parameters[5].Value = model.AttributeId;

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
        public bool Delete(long AttributeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_Attributes ");
            strSql.Append(" WHERE AttributeId=?AttributeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64)
            };
            parameters[0].Value = AttributeId;

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
        public bool DeleteList(string AttributeIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM Shop_Attributes ");
            strSql.Append(" WHERE AttributeId in (" + AttributeIdlist + ")  ");
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
        public YSWL.MALL.Model.Shop.Products.AttributeInfo GetModel(long AttributeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT AttributeId,AttributeName,DisplaySequence,TypeId,UsageMode,UseAttributeImage FROM Shop_Attributes ");
            strSql.Append(" WHERE AttributeId=?AttributeId");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?AttributeId", MySqlDbType.Int64)
            };
            parameters[0].Value = AttributeId;
            strSql.Append(" LIMIT 1 ");
            YSWL.MALL.Model.Shop.Products.AttributeInfo model = new YSWL.MALL.Model.Shop.Products.AttributeInfo();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["AttributeId"] != null && ds.Tables[0].Rows[0]["AttributeId"].ToString() != "")
                {
                    model.AttributeId = long.Parse(ds.Tables[0].Rows[0]["AttributeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AttributeName"] != null && ds.Tables[0].Rows[0]["AttributeName"].ToString() != "")
                {
                    model.AttributeName = ds.Tables[0].Rows[0]["AttributeName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DisplaySequence"] != null && ds.Tables[0].Rows[0]["DisplaySequence"].ToString() != "")
                {
                    model.DisplaySequence = int.Parse(ds.Tables[0].Rows[0]["DisplaySequence"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeId"] != null && ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UsageMode"] != null && ds.Tables[0].Rows[0]["UsageMode"].ToString() != "")
                {
                    model.UsageMode = int.Parse(ds.Tables[0].Rows[0]["UsageMode"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UseAttributeImage"] != null && ds.Tables[0].Rows[0]["UseAttributeImage"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["UseAttributeImage"].ToString() == "1") || (ds.Tables[0].Rows[0]["UseAttributeImage"].ToString().ToLower() == "true"))
                    {
                        model.UseAttributeImage = true;
                    }
                    else
                    {
                        model.UseAttributeImage = false;
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
            strSql.Append("SELECT AttributeId,AttributeName,DisplaySequence,TypeId,UsageMode,UseAttributeImage ");
            strSql.Append(" FROM Shop_Attributes ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ");
            
            strSql.Append(" AttributeId,AttributeName,DisplaySequence,TypeId,UsageMode,UseAttributeImage ");
            strSql.Append(" FROM Shop_Attributes ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ORDER BY " + filedOrder);
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
            strSql.Append("SELECT COUNT(1) FROM Shop_Attributes ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
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
            strSql.Append("SELECT T.* from Shop_Attributes T ");
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
                strSql.Append(" order by T.AttributeId desc");
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
            parameters[0].Value = "Shop_Attributes";
            parameters[1].Value = "AttributeId";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method

        public bool AttributeManage(Model.Shop.Products.AttributeInfo model, Model.Shop.Products.DataProviderAction Action)
        {
            int rows = 0;
            MySqlParameter[] param = { 
                                   new MySqlParameter("_Action",MySqlDbType.Int32),
                                   new MySqlParameter("_AttributeId",MySqlDbType.Int64),
                                   new MySqlParameter("_AttributeName",MySqlDbType.VarChar),
                                   new MySqlParameter("_TypeId",MySqlDbType.Int32),
                                   new MySqlParameter("_UsageMode",MySqlDbType.Int32),
                                   new MySqlParameter("_UseAttributeImage",MySqlDbType.Bit),
                                   new MySqlParameter("_UserDefinedPic",MySqlDbType.Bit),
                                   new MySqlParameter("_AttributeIdOutPut",MySqlDbType.Int64)
                                   };
            param[0].Value = (int)Action;
            param[1].Value = model.AttributeId;
            param[2].Value = model.AttributeName;
            param[3].Value = model.TypeId;
            param[4].Value = model.UsageMode;
            param[5].Value = model.UseAttributeImage;
            param[6].Value = model.UserDefinedPic;
            param[7].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("sp_Shop_AttributesCreateEditDelete", param, out rows);
            long attId = 0;
            if (Action == Model.Shop.Products.DataProviderAction.Create)
            {
                attId = Convert.ToInt64(param[7].Value);
            }
            else
            {
                attId = model.AttributeId;
            }
            if (rows > 0)
            {
                AttributeValue attInfo = new AttributeValue();
                if (Action == Model.Shop.Products.DataProviderAction.Update)
                {
                    //attInfo.Delete(attId, null);
                }
                foreach (string varStr in model.ValueStr)
                {
                    Model.Shop.Products.AttributeValue attModel = new Model.Shop.Products.AttributeValue();
                    attModel.AttributeId = attId;
                    attModel.ValueStr = varStr;
                    attInfo.AttributeValueManage(attModel, Model.Shop.Products.DataProviderAction.Create);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(long? Typeid, Model.Shop.Products.SearchType searchType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT AttributeId,AttributeName,DisplaySequence,TypeId,UsageMode,UseAttributeImage ");
            strSql.Append(" FROM Shop_Attributes ");
            StringBuilder strWhere = new StringBuilder();

            if (searchType == Model.Shop.Products.SearchType.ExtAttribute)
            {
                if (!String.IsNullOrWhiteSpace(strWhere.ToString()))
                {
                    strWhere.Append(" AND ");
                }
                strWhere.Append("   UsageMode  <>3 ");
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(strWhere.ToString()))
                {
                    strWhere.Append(" AND ");
                }
                strWhere.Append("   UsageMode =3 ");
            }

            if (Typeid.HasValue)
            {
                if (!String.IsNullOrWhiteSpace(strWhere.ToString()))
                {
                    strWhere.Append(" AND ");
                }
                strWhere.Append("  TypeId=?TypeId");
                strSql.Append(" WHERE  " + strWhere.ToString());
                strSql.Append(" ORDER BY DisplaySequence ");
                MySqlParameter[] param = { 
                                       new MySqlParameter("?TypeId",MySqlDbType.Int64)
                                       };
                param[0].Value = Typeid.Value;
                return DbHelperMySQL.Query(strSql.ToString(), param);
            }
            else
            {
                strSql.Append(" WHERE  " + strWhere.ToString());
                strSql.Append(" ORDER BY DisplaySequence ");
                return DbHelperMySQL.Query(strSql.ToString());
            }
        }

        public bool ChangeImageStatue(long AttributeId, Model.Shop.Products.ProductAttributeModel status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Shop_Attributes ");
            strSql.Append("SET UsageMode=?Status ");
            strSql.Append("WHERE AttributeId=?AttributeId ");
            MySqlParameter[] parameter = { 
                                       new MySqlParameter("?AttributeId",MySqlDbType.Int64),
                                       new MySqlParameter("?Status",MySqlDbType.Int32)
                                       };
            parameter[0].Value = AttributeId;
            parameter[1].Value = (int)status;
            int resultRows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameter);
            return resultRows > 0;
        }

        public List<Model.Shop.Products.AttributeInfo> GetAttributeInfoList(int? typeId, Model.Shop.Products.SearchType searchType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT  A.AttributeId ,
                                A.AttributeName ,
                                A.DisplaySequence AS AttributeDisplaySequence ,
                                A.TypeId ,
                                A.UsageMode ,
                                A.UseAttributeImage ,
                                A.UserDefinedPic ,
                                V.ValueId,
                                V.DisplaySequence AS ValueDisplaySequence ,
                                V.ValueStr ,
                                V.ImageUrl
                            FROM Shop_Attributes A
                                LEFT JOIN Shop_AttributeValues V ON A.AttributeId = V.AttributeId
                            WHERE ");
            //Tip: 此处不排除自定义属性的值, 正常解析, 添加商品处已在json解析处过滤 避免添加商品时出现其他商品填写的自定义属性 BEN ADD 2012-07-01
            //LEFT JOIN ... AND ((A.UsageMode<>2) OR (A.UsageMode=2 AND V.DisplaySequence IS NULL)) //排除自定义属性值条件
            List<MySqlParameter> param = new List<MySqlParameter>();
            if (typeId.HasValue)
            {
                strSql.Append(" A.TypeId = ?TypeId");
                param.Add(new MySqlParameter("?TypeId", MySqlDbType.Int32));
                param[0].Value = typeId;
            }
            switch (searchType)
            {
                case SearchType.ExtAttribute:
                    if (typeId.HasValue)
                    {
                        strSql.Append(" AND ");
                    }
                    strSql.Append(" A.UsageMode <>3");
                    break;
                case SearchType.Specification:
                    if (typeId.HasValue)
                    {
                        strSql.Append(" AND ");
                    }
                    strSql.Append(" A.UsageMode = 3");
                    break;
                default:
                    break;
            }
            strSql.Append(" ORDER BY A.DisplaySequence,V.AttributeId,V.DisplaySequence");

            DataSet ds = param.Count > 0 ?
                DbHelperMySQL.Query(strSql.ToString(), param.ToArray()) :
                DbHelperMySQL.Query(strSql.ToString());
            if (ds == null || ds.Tables[0].Rows.Count < 0) return null;

            //Fill And Return List
            return FillAttributeInfos(ds);
        }

        private List<Model.Shop.Products.AttributeInfo> FillAttributeInfos(DataSet ds)
        {
            List<Model.Shop.Products.AttributeInfo> list = new List<Model.Shop.Products.AttributeInfo>();
            Model.Shop.Products.AttributeInfo attributeInfo;
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                //判断是否存在
                attributeInfo = list.Find(info =>
                                          info.AttributeId.ToString(CultureInfo.InvariantCulture) ==
                                          dataRow["AttributeId"].ToString()
                    );
                // 第一次
                if (attributeInfo == null)
                {
                    int usageMode = (int)dataRow["UsageMode"];

                    //非自填写属性 无AttributeValue情况 (*)保护 忽略此数据
                    if (usageMode != 2)
                    {
                        if (dataRow["ValueId"] == DBNull.Value) continue;
                    }

                    attributeInfo = new Model.Shop.Products.AttributeInfo();
                    attributeInfo.AttributeId = (long)dataRow["AttributeId"];
                    attributeInfo.AttributeName = dataRow["AttributeName"].ToString();

                    attributeInfo.DisplaySequence = (int)dataRow["AttributeDisplaySequence"];
                    attributeInfo.TypeId = (int)dataRow["TypeId"];
                    attributeInfo.UsageMode = usageMode;
                    attributeInfo.UseAttributeImage = (bool)dataRow["UseAttributeImage"];
                    attributeInfo.UserDefinedPic = (bool)dataRow["UserDefinedPic"];
                    //Add to List
                    list.Add(attributeInfo);
                }

                if (dataRow["ValueId"] == DBNull.Value) continue;
                // 追加/填充 AttributeValue
                attributeInfo.AttributeValues.Add(new Model.Shop.Products.AttributeValue
                {
                    ValueId = (long)dataRow["ValueId"],
                    AttributeId = (long)dataRow["AttributeId"],
                    DisplaySequence = (int)dataRow["ValueDisplaySequence"],
                    ValueStr =
                        dataRow["ValueStr"] != DBNull.Value
                            ? dataRow["ValueStr"].ToString()
                            : string.Empty,
                    ImageUrl =
                        dataRow["ImageUrl"] != DBNull.Value
                            ? dataRow["ImageUrl"].ToString()
                            : string.Empty
                });
                attributeInfo.ValueStr.Add(dataRow.Field<string>("ValueStr"));
            }
            return list;
        }


        public List<Model.Shop.Products.AttributeInfo> GetAttributeInfoListByProductId(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"
SELECT  A.AttributeId
      , A.AttributeName
      , A.DisplaySequence AS AttributeDisplaySequence
      , A.TypeId
      , A.UsageMode
      , A.UseAttributeImage
      , A.UserDefinedPic
      , V.ValueId
      , V.DisplaySequence AS ValueDisplaySequence
      , V.ValueStr
      , V.ImageUrl
FROM  Shop_ProductAttributes PA LEFT JOIN  Shop_Attributes A ON PA.AttributeId = A.AttributeId
        LEFT JOIN Shop_AttributeValues V ON PA.ValueId = V.ValueId
WHERE PA.ProductId = ?ProductId");
            List<MySqlParameter> param = new List<MySqlParameter>();
            param.Add(new MySqlParameter("?ProductId", MySqlDbType.Int32));
            param[0].Value = productId;
            strSql.Append(" ORDER BY A.DisplaySequence,V.AttributeId,V.DisplaySequence");

            DataSet ds = param.Count > 0 ?
                DbHelperMySQL.Query(strSql.ToString(), param.ToArray()) :
                DbHelperMySQL.Query(strSql.ToString());
            if (ds == null || ds.Tables[0].Rows.Count < 0) return null;

            //Fill And Return List
            return FillAttributeInfos(ds);
        }

        public DataSet GetAttribute(int? cateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *  ");
            strSql.Append("FROM Shop_Attributes ");
            strSql.Append("WHERE AttributeId IN(SELECT DISTINCT AttributeId FROM Shop_ProductAttributes ");
            strSql.Append("WHERE ProductId IN(SELECT ProductId FROM Shop_Products ");
            if (cateID.HasValue)
            {
                strSql.AppendFormat("WHERE CategoryId ={0} ", cateID.Value);
            }
            strSql.Append(")) ");
            strSql.Append("ORDER BY Shop_Attributes.DisplaySequence ASC ");
            strSql.Append(" LIMIT 6 ");
            return DbHelperMySQL.Query(strSql.ToString());
        }

        public bool IsExistDefinedAttribute(int typeId, long? attId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_Attributes ");
            strSql.AppendFormat("WHERE UsageMode=3 AND TypeId={0} AND UserDefinedPic=1 ", typeId);
            if (attId.HasValue)
            {
                strSql.AppendFormat("  AND AttributeId={0} ", attId.Value);
            }
            object obj = DbHelperMySQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return false;
            }
            else
            {
                return Convert.ToInt32(obj) > 0;
            }
        }

        public DataSet GetProductAttributes(long productId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT A.ValueId,C.ValueStr,B.* FROM  ");
            strSql.Append("Shop_ProductAttributes A ");
            strSql.Append("LEFT JOIN Shop_Attributes B ON A.AttributeId = B.AttributeId ");
            strSql.Append("LEFT JOIN Shop_AttributeValues C ON C.ValueId= A.ValueId AND A.AttributeId = B.AttributeId ");
            strSql.Append("WHERE ProductId=?ProductId ");
            MySqlParameter[] parameters ={
                                          new MySqlParameter("?ProductId",MySqlDbType.Int64,8)
                                      };
            parameters[0].Value = productId;
            return DbHelperMySQL.Query(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据分类获取属性  
        /// </summary>
        /// <param name="cateID"></param>
        /// <param name="IsChild"></param>
        /// <returns></returns>
        public DataSet GetAttributesByCate(int cateID, bool IsChild)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT  * FROM    Shop_Attributes  where  UsageMode <2 ");
            if (cateID > 0)
            {
                strSql.Append("  and    EXISTS ( SELECT * FROM   Shop_Products ");
                strSql.Append("  WHERE  SaleStatus=1 and  TypeId = Shop_Attributes.TypeId ");
                strSql.Append(" AND EXISTS ( SELECT * FROM   Shop_ProductCategories  ");
                strSql.Append(" WHERE  ProductId = Shop_Products.ProductId  ");
                if (IsChild)
                {
                    strSql.AppendFormat(
                        "   AND ( CategoryPath LIKE CONCAT(( SELECT Path FROM Shop_Categories WHERE CategoryId = {0}  ) , '|%') ",
                        cateID);
                    strSql.AppendFormat(" OR Shop_ProductCategories.CategoryId = {0})", cateID);
                }
                else
                {
                    strSql.AppendFormat("   AND   Shop_ProductCategories.CategoryId = {0}", cateID);
                }
                strSql.Append(")) ");
            }
            strSql.Append("ORDER BY Shop_Attributes.DisplaySequence ASC ");
            return DbHelperMySQL.Query(strSql.ToString());
        }


        public bool IsExistName(int typeId, string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) FROM Shop_Attributes");
            strSql.Append(" WHERE TypeId=?TypeId and AttributeName=?AttributeName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("?TypeId", MySqlDbType.Int32,4),
                       new MySqlParameter("?AttributeName", MySqlDbType.VarChar,200)
            };
            parameters[0].Value = typeId;
            parameters[1].Value = name;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

      public string GetAttrValue(string keyName,long productId)
      {
          StringBuilder stringBuilder=new StringBuilder();
          stringBuilder.Append("select ValueStr from Shop_AttributeValues where ValueId in(");
          stringBuilder.Append(
              "select ValueId from Shop_ProductAttributes where ProductId=?productId and AttributeId in  (");
          stringBuilder.Append("select AttributeId from Shop_Attributes where AttributeName=?AttributeName))");
          MySqlParameter[] parameters = {
                    new MySqlParameter("?productId", MySqlDbType.Int64),
                       new MySqlParameter("?AttributeName", MySqlDbType.VarChar,200)
            };
          parameters[0].Value = productId;
          parameters[1].Value = keyName;
          object obj = DbHelperMySQL.GetSingle(stringBuilder.ToString(),parameters);

          if (obj != null)
          {
              return obj.ToString();
          }
          else
          {
              return null;
          }
      }


        public bool AttributePMSManage(Model.Shop.Products.AttributeInfo model, Model.Shop.Products.DataProviderAction Action)
        {
            int rows = 0;
            MySqlParameter[] param = {
                                   new MySqlParameter("_Action",MySqlDbType.Int32),
                                   new MySqlParameter("_AttributeId",MySqlDbType.Int64),
                                   new MySqlParameter("_AttributeName",MySqlDbType.VarChar),
                                   new MySqlParameter("_TypeId",MySqlDbType.Int32),
                                   new MySqlParameter("_UsageMode",MySqlDbType.Int32),
                                   new MySqlParameter("_UseAttributeImage",MySqlDbType.Bit),
                                   new MySqlParameter("_UserDefinedPic",MySqlDbType.Bit),
                                   new MySqlParameter("_AttributeIdOutPut",MySqlDbType.Int64)
                                   };
            param[0].Value = (int)Action;
            param[1].Value = model.AttributeId;
            param[2].Value = model.AttributeName;
            param[3].Value = model.TypeId;
            param[4].Value = model.UsageMode;
            param[5].Value = model.UseAttributeImage;
            param[6].Value = model.UserDefinedPic;
            param[7].Direction = ParameterDirection.Output;
            DbHelperMySQL.RunProcedure("sp_Shop_AttributesCreateEditDelete", param, out rows);
            long attId = 0;
            if (Action == Model.Shop.Products.DataProviderAction.Create)
            {
                attId = Convert.ToInt64(param[7].Value);
            }
            else
            {
                attId = model.AttributeId;
            }
            if (rows > 0)
            {
                AttributeValue attInfo = new AttributeValue();
                if (Action == Model.Shop.Products.DataProviderAction.Update)
                {
                    attInfo.Delete(attId);
                }
                if (model.AttributeValues != null)
                {
                    foreach (var item in model.AttributeValues)
                    {
                        item.AttributeId = attId;
                        attInfo.AttributeValueManage(item, Model.Shop.Products.DataProviderAction.Create);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ResetTable()
        {
            throw new NotImplementedException();
        }

        public bool AttributeManage(Model.Shop.Products.AttributeInfo model)
        {
            throw new NotImplementedException();
        }
    }
}

