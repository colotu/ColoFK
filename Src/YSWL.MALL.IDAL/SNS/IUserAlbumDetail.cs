/**
* UserAlbumDetail.cs
*
* 功 能： N/A
* 类 名： UserAlbumDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/9/12 20:15:00   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
namespace YSWL.MALL.IDAL.SNS
{
    /// <summary>
    /// 接口层用户专辑详情表
    /// </summary>
    public interface IUserAlbumDetail
    {
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int AlbumID, int TargetID, int Type);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(YSWL.MALL.Model.SNS.UserAlbumDetail model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(YSWL.MALL.Model.SNS.UserAlbumDetail model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int AlbumID, int TargetID, int Type);
        bool DeleteList(string IDlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        YSWL.MALL.Model.SNS.UserAlbumDetail GetModel(int ID);
        YSWL.MALL.Model.SNS.UserAlbumDetail DataRowToModel(DataRow row);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        int GetRecordCount(string strWhere);
        DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
        #region  MethodEx

        /// <summary>
        /// 获得专辑的推荐产品照片
        /// </summary>
        List<string> GetThumbImageByAlbum(int AlbumID,int type);

        /// <summary>
        /// 获得专辑下的图片记录总数
        /// </summary>
        int GetRecordCount4AlbumImgByAlbumID(int albumID, int type);
        /// <summary>
        /// 获得专辑下的图片数据列表
        /// </summary>
        DataSet GetAlbumImgListByPage(int albumID, string orderby, int startIndex, int endIndex, int type);
        /// <summary>
        /// 增加专辑的数据，并且更新相应的图片的数量
        /// </summary>
        bool AddEx(YSWL.MALL.Model.SNS.UserAlbumDetail model);
        /// <summary>
        /// 删除专辑中的具体图片
        /// </summary>
        /// <param name="AlbumID"></param>
        /// <param name="TargetId"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        bool DeleteEx(int AlbumID, int TargetId, int Type);
        #endregion  MethodEx
    }
}
