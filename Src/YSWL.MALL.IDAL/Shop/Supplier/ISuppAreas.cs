/**  版本信息模板在安装目录下，可自行修改。
* SuppAreas.cs
*
* 功 能： N/A
* 类 名： SuppAreas
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2017/2/28 10:06:27   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace YSWL.MALL.IDAL.Shop.Supplier
{
	/// <summary>
	/// 接口层SuppAreas
	/// </summary>
	public interface ISuppAreas
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int AreaId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(YSWL.MALL.Model.Shop.Supplier.SuppAreas model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.Shop.Supplier.SuppAreas model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int AreaId);
		bool DeleteList(string AreaIdlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.Shop.Supplier.SuppAreas GetModel(int AreaId);
		YSWL.MALL.Model.Shop.Supplier.SuppAreas DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx
        bool IsExisted(int parentId, string name, int areaId = 0);
        int GetMaxSeqByCid(int parentId);
        bool UpdateHasChild(int cid, int hasChild = 1);
        bool UpdatePath(Model.Shop.Supplier.SuppAreas model);
        bool UpdateSeqByCid(int Seq, int Cid);
        bool UpdateStatus(bool Status, int Cid);
        DataSet DeleteArea(int areaId, out int Result);
        /// <summary>
	    /// 更新一条数据
	    /// </summary>
	    bool UpdateEx(YSWL.MALL.Model.Shop.Supplier.SuppAreas model);
        bool UpdateDepthAndPath(int areaId, int Depth, string Path);
        #endregion  MethodEx
    } 
}
