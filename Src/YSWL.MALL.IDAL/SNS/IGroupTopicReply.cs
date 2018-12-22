/**
* GroupTopicReply.cs
*
* 功 能： N/A
* 类 名： GroupTopicReply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:14:43   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace YSWL.MALL.IDAL.SNS
{
	/// <summary>
	/// 接口层主题回复表
	/// </summary>
	public interface IGroupTopicReply
	{
		#region  成员方法
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(YSWL.MALL.Model.SNS.GroupTopicReply model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.SNS.GroupTopicReply model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int ReplyID);
		bool DeleteList(string ReplyIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.SNS.GroupTopicReply GetModel(int ReplyID);
		YSWL.MALL.Model.SNS.GroupTopicReply DataRowToModel(DataRow row);
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
        int AddEx(YSWL.MALL.Model.SNS.GroupTopicReply TModel, YSWL.MALL.Model.SNS.Products PModel);


        int ForwardReply(YSWL.MALL.Model.SNS.GroupTopicReply TModel);
         /// <summary>
		/// 获得数据列表
		/// </summary>
        DataSet GetListEx(string strWhere);

        /// <summary>
        /// 删除回复的ids对应的数据
        /// </summary>
        /// <param name="TopicIDlist"></param>
        bool DeleteListEx(string TopicIDlist);
        /// <summary>
        /// 批量审核
        /// </summary>
        bool UpdateStatusList(string IdsStr, YSWL.MALL.Model.SNS.EnumHelper.TopicStatus status);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool DeleteEx(int ReplyID);

	    DataSet GetReplyList(int userId);

	    #endregion  MethodEx
	} 
}
