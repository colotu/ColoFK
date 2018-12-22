using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.Tao;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Tao;
namespace YSWL.MALL.BLL.Tao
{
	/// <summary>
	/// Report
	/// </summary>
	public partial class Report
	{
        private readonly IReport dal = DATao.CreateReport();
		public Report()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ReportId)
		{
			return dal.Exists(ReportId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(YSWL.MALL.Model.Tao.Report model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.Tao.Report model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ReportId)
		{
			
			return dal.Delete(ReportId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ReportIdlist )
		{
			return dal.DeleteList(Common.Globals.SafeLongFilter(ReportIdlist ,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.Tao.Report GetModel(int ReportId)
		{
			return dal.GetModel(ReportId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public YSWL.MALL.Model.Tao.Report GetModelByCache(int ReportId)
		{
			
			string CacheKey = "ReportModel-" + ReportId;
			object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ReportId);
					if (objModel != null)
					{
						 int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
						YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YSWL.MALL.Model.Tao.Report)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.Tao.Report> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.Tao.Report> DataTableToList(DataTable dt)
		{
			List<YSWL.MALL.Model.Tao.Report> modelList = new List<YSWL.MALL.Model.Tao.Report>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				YSWL.MALL.Model.Tao.Report model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
				}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Report> GetListByUserId(int userId)
        {
            return GetModelList(" userId=" + userId);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Tao.Report> GetNewList(int top )
        {
            DataSet ds = dal.GetList(top, "", "PayTime");
           List<YSWL.MALL.Model.Tao.Report> list= DataTableToList(ds.Tables[0]);
           List<YSWL.MALL.Model.Tao.Report> ReportList = new List<YSWL.MALL.Model.Tao.Report>();
           YSWL.MALL.BLL.Members.Users userBll = new Members.Users();
           foreach (var item in list)
           {
              item.UserName=userBll.GetUserName(item.UserId);
              ReportList.Add(item);
           }
           return ReportList;
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public List<YSWL.MALL.Model.Tao.Report> GetListByPageEX(string strWhere, string orderby, int startIndex, int endIndex)
        {
            DataSet ds = GetListByPage(strWhere, orderby, startIndex, endIndex);
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                List<YSWL.MALL.Model.Tao.Report> list = DataTableToList(ds.Tables[0]);
                List<YSWL.MALL.Model.Tao.Report> ReportList = new List<YSWL.MALL.Model.Tao.Report>();
                YSWL.MALL.BLL.Members.Users userBll = new Members.Users();
                foreach (var item in list)
                {
                    //获取图片路径（需要根据接口查询）
                    item.UserName = userBll.GetUserName(item.UserId);
                    ReportList.Add(item);
                }
                return ReportList;
            }
            return null;
        }

        public List<YSWL.MALL.ViewModel.Tao.UserRank> GetUserRankMonth()
        {
            DataSet ds = dal.GetUserRankMonth();
            List<YSWL.MALL.ViewModel.Tao.UserRank> List = new List<ViewModel.Tao.UserRank>();
            if (ds.Tables != null && ds.Tables.Count > 0)
            {
                int rowsCount = ds.Tables[0].Rows.Count;
                if (rowsCount > 0)
                {
                    YSWL.MALL.ViewModel.Tao.UserRank model = null; ;
                    for (int n = 0; n < rowsCount; n++)
                    {
                        model = new ViewModel.Tao.UserRank();
                        DataRow row = ds.Tables[0].Rows[n];
                        if (row != null)
                        {
                            if (row["UserName"] != null && row["UserName"].ToString() != "")
                            {
                                model.UserName = row["UserName"].ToString();
                            }
                            if (row["SumRebate"] != null && row["SumRebate"].ToString() != "")
                            {
                                model.SumRebate = decimal.Parse(row["SumRebate"].ToString());
                            }
                            List.Add(model);
                        }
                    }
                }
            }
            return List;
        }

		#endregion  ExtensionMethod
	}
}

