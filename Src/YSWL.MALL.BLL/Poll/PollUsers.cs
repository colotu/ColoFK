using System;
using System.Data;
using System.Collections.Generic;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Poll;
using YSWL.MALL.Model;
using YSWL.Common;
namespace YSWL.MALL.BLL.Poll
{
	/// <summary>
	/// ҵ���߼���Users ��ժҪ˵����
	/// </summary>
	public class PollUsers
	{
        private readonly IPollUsers dal = DAPoll.CreatePollUsers();

        #region  BasicMethod

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int UserID)
        {
            return dal.Exists(UserID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(YSWL.MALL.Model.Poll.PollUsers model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(YSWL.MALL.Model.Poll.PollUsers model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int UserID)
        {

            return dal.Delete(UserID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            return dal.DeleteList(UserIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public YSWL.MALL.Model.Poll.PollUsers GetModel(int UserID)
        {

            return dal.GetModel(UserID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ�����
        /// </summary>
        public YSWL.MALL.Model.Poll.PollUsers GetModelByCache(int UserID)
        {

            string CacheKey = "UsersModel-" + UserID;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(UserID);
                    if (objModel != null)
                    {
                        int ModelCache = YSWL.Common.ConfigHelper.GetConfigInt("CacheTime");
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Poll.PollUsers)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<YSWL.MALL.Model.Poll.PollUsers> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<YSWL.MALL.Model.Poll.PollUsers> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Poll.PollUsers> modelList = new List<YSWL.MALL.Model.Poll.PollUsers>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Poll.PollUsers model;
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
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

	    /// <summary>
	    /// ��ҳ��ȡ�����б�
	    /// </summary>
	    //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
	    //{
	    //return dal.GetList(PageSize,PageIndex,strWhere);
	    //}

	    #endregion  BasicMethod


	    /// <summary>
	    /// �Ƿ���ڸü�¼��ϵͳ�е��û���
	    /// </summary>
	    /// <param name="UserId">ϵͳ�û�UserID</param>
	    /// <returns></returns>
	    public bool ExistsSysUser(int UserId)
	    {
	        return dal.ExistsSysUser(UserId);
	    }
	}
}

