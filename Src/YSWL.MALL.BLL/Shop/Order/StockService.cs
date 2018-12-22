using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using YSWL.Common;
using YSWL.MALL.BLL.Shop.Service;
using YSWL.MALL.BLL.SysManage;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Shop.Order;
using YSWL.SAAS.BLL;

namespace YSWL.MALL.BLL.Shop.Order
{
    public class StockService
    {
        private readonly static IStock service = DAShopOrder.CreateStock();
        private static DataCacheCore dataCache = new DataCacheCore(new CacheOption
        {
            CacheType = SAASInfo.GetSystemBoolValue("RedisCacheUse") ? CacheType.Redis : CacheType.IIS,
            ReadWriteHosts = SAASInfo.GetSystemValue("RedisCacheReadWriteHosts"),
            ReadOnlyHosts = SAASInfo.GetSystemValue("RedisCacheReadOnlyHosts"),
            CancelProductKey = true,
            DefaultDb = 2
        });

      /// <summary>
      ///  检测SKU库存
      /// </summary>
      /// <param name="SKU"></param>
      /// <param name="count"></param>
      /// <param name="depotId"></param>
      /// <returns></returns>
      public static bool CheckStock(string SKU, int count, int depotId,int supplierId)
      {
        YSWL.MALL.Model.Shop.Order.Stock stockModel = GetStock(SKU, depotId, supplierId);
        return stockModel != null && stockModel.UsedStock + stockModel.SaleStock - count >= 0; 
      }

      /// <summary>
        /// 获得SKU 库存
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="depotId"></param>
        /// <returns></returns>
        public static YSWL.MALL.Model.Shop.Order.Stock GetStock(string sku, int depotId,int supplierId)
        {
            string CacheKey = "OMS-GetStock-" + sku + "-" + depotId+"-"+ supplierId;
            YSWL.MALL.Model.Shop.Order.Stock objModel = dataCache.GetCache<YSWL.MALL.Model.Shop.Order.Stock>(CacheKey);
           if (objModel == null)
            {
                try
                {
                  if (CommonHelper.ConnectionWMS())
                  {
                    //获取WMS 的可销库存
                    objModel = GetWMSSalesStock(sku, depotId, supplierId);
                  }
                  if (CommonHelper.ConnectionERP())
                    {
                        //获取ERP 的可销库存
                        objModel = GetERPSalesStock(sku, depotId);
                    }

                    if (objModel != null)
                    {
                        int ModelCache = YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("OMS_SalesStock_CacheTime");
                        dataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache),
                            TimeSpan.Zero);
                    }
                    else
                    {
                        objModel = new YSWL.MALL.Model.Shop.Order.Stock();
                    }
                }
                catch (Exception ex)
                {
                    Log.LogHelper.AddTextLog("获取库存失败："+ex.Message,ex.StackTrace);
                }
            }

      //#region   处理可销库存

      //if (objModel != null)
      //{
      //  //objModel.SaleStock = objModel.SaleStock <= 0 ? 0 : objModel.SaleStock;
      //}

      //#endregion 

      return objModel;
        }
        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="stockModel"></param>
        public static void UpdateStock(YSWL.MALL.Model.Shop.Order.Stock stockModel)
        {
            string CacheKey = "OMS-GetStock-" + stockModel.SKU + "-" + stockModel.DepotId+"-"+ stockModel.OwnerId;
            int ModelCache = YSWL.MALL.BLL.SysManage.ConfigSystem.GetIntValueByCache("OMS_SalesStock_CacheTime");
            //然后添加缓存
            dataCache.SetCache(CacheKey, stockModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
            //更新数据库
            // CacheKey
        }
        /// <summary>
        /// 更新同步订单时商品SKU 库存
        /// </summary>
        /// <param name="itemList"></param>
        /// <param name="depotId"></param>
        public static void UpdateCreatedStock(List<YSWL.MALL.Model.Shop.Order.OrderItems> itemList, int depotId,int supplierId)
        {
            //先获得商品库存
            foreach (var item in itemList)
            {
                YSWL.MALL.Model.Shop.Order.Stock stockModel = GetStock(item.SKU, depotId, supplierId);
                if (stockModel != null)
                {
                    stockModel.UsedStock = stockModel.UsedStock + item.Quantity;
                    stockModel.SaleStock = stockModel.SaleStock - item.Quantity;
                    UpdateStock(stockModel);
                }
            }
          
        }
        /// <summary>
        /// 更新审核订单时商品SKU 库存
        /// </summary>
        /// <param name="itemList"></param>
        /// <param name="depotId"></param>
        public static void UpdateCheckStock(List<YSWL.MALL.Model.Shop.Order.OrderItems> itemList, int depotId,bool isCheck=false) 
        {
            //先获得商品库存
            foreach (var item in itemList)
            {
                YSWL.MALL.Model.Shop.Order.Stock stockModel = YSWL.MALL.BLL.Shop.Order.StockService.GetStock(item.SKU, depotId,(item.SupplierId.HasValue&& item.SupplierId.Value> 0? item.SupplierId.Value: 0));
                if (!isCheck)//表示直接提交并审核订单下来
                {
                    stockModel.UsedStock = stockModel.UsedStock - item.Quantity;
                }
                UpdateStock(stockModel);
            }
        }


        #region WMS库存
        public static YSWL.MALL.Model.Shop.Order.Stock GetWMSSalesStock(string sku, int depotId, int ownerId)
        {
            YSWL.MALL.Model.Shop.Order.Stock stockModel = new YSWL.MALL.Model.Shop.Order.Stock
            {
                SKU = sku,
                SaleStock = 0,
                UsedStock = YSWL.MALL.BLL.Shop.Order.OrderManage.GetUsedStock(sku, depotId, ownerId),
                DepotId = depotId
            };
            try
            {
                stockModel.SaleStock = service.GetWMSSalesStock(sku, depotId, ownerId) - stockModel.UsedStock;
            }
            catch (Exception ex)
            {
                LogHelp.AddErrorLog("获取SKU 的可销库存失败: " + ex.Message, ex.StackTrace);
                throw;
            }
            return stockModel;
        }
        #endregion
        #region  ERP 库存
        public static YSWL.MALL.Model.Shop.Order.Stock GetERPSalesStock(string sku, int depotId)
        {

            YSWL.MALL.Model.Shop.Order.Stock stockModel = new YSWL.MALL.Model.Shop.Order.Stock
            {
                SKU = sku,
                SaleStock = 0,
                UsedStock = YSWL.MALL.BLL.Shop.Order.OrderManage.GetUsedStock(sku, depotId, 0),
                DepotId = depotId
            };
            try
            {
                int usedStock = service.GetERPSalesStock(sku, depotId);
                stockModel.SaleStock = usedStock - stockModel.UsedStock;

            }
            catch (Exception ex)
            {
                LogHelp.AddErrorLog("获取SKU 的可销库存失败: " + ex.Message, ex.StackTrace);
                throw;
            }
            return stockModel;
        }
     #endregion
    }
}
