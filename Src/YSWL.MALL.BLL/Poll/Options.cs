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
	/// ҵ���߼���Options ��ժҪ˵����
	/// </summary>
	public class Options
	{
        private readonly IOptions dal = DAPoll.CreateOptions();
		#region  ��Ա����

		

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(int TopicID, string Name)
		{
            return dal.Exists(TopicID, Name);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(YSWL.MALL.Model.Poll.Options model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(YSWL.MALL.Model.Poll.Options model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ID)
		{
			
			dal.Delete(ID);
		}


        /// <summary>
        /// ����ɾ��
        /// </summary>
        /// <param name="ClassIDlist"></param>
        /// <returns></returns>
        public bool DeleteList(string ClassIDlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(ClassIDlist,0) );
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public YSWL.MALL.Model.Poll.Options GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public YSWL.MALL.Model.Poll.Options GetModelByCache(int ID)
		{
			
			string CacheKey = "OptionsModel-" + ID;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
                        int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YSWL.MALL.Model.Poll.Options)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<YSWL.MALL.Model.Poll.Options> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<YSWL.MALL.Model.Poll.Options> modelList = new List<YSWL.MALL.Model.Poll.Options>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				YSWL.MALL.Model.Poll.Options model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new YSWL.MALL.Model.Poll.Options();
					if(ds.Tables[0].Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
					}
					model.Name=ds.Tables[0].Rows[n]["Name"].ToString();
					if(ds.Tables[0].Rows[n]["TopicID"].ToString()!="")
					{
						model.TopicID=int.Parse(ds.Tables[0].Rows[n]["TopicID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["isChecked"].ToString()!="")
					{
						model.isChecked=int.Parse(ds.Tables[0].Rows[n]["isChecked"].ToString());
					}
					if(ds.Tables[0].Rows[n]["SubmitNum"].ToString()!="")
					{
						model.SubmitNum=int.Parse(ds.Tables[0].Rows[n]["SubmitNum"].ToString());
					}
					modelList.Add(model);
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

        public DataSet GetListByTopic(int TopicID)
        {
            return GetList(" TopicID=" + TopicID);
        }

        
        /// <summary>
        /// �õ��ʾ�ͶƱͳ��
        /// </summary>
        /// <param name="FormID">�ʾ���</param>
        /// <returns></returns>
        public DataSet GetCountList(int FormID)
        {
            return dal.GetCountList(FormID);
        }

	    /// <summary>
	    /// �õ��ʾ�ͶƱͳ��
	    /// </summary>
	    /// <param name="strwhere"></param>
	    /// <returns></returns>
	    public List<Model.Poll.Options> GetCountList(string strwhere)
	    {
	        DataSet ds= dal.GetCountList(strwhere);
            List<YSWL.MALL.Model.Poll.Options> modelList = new List<YSWL.MALL.Model.Poll.Options>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Poll.Options model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new YSWL.MALL.Model.Poll.Options();
                    model.Name = ds.Tables[0].Rows[n]["Name"].ToString();
                    if (ds.Tables[0].Rows[n]["TopicID"].ToString() != "")
                    {
                        model.TopicID = int.Parse(ds.Tables[0].Rows[n]["TopicID"].ToString());
                    }  
                    if (ds.Tables[0].Rows[n]["SubmitNum"].ToString() != "")
                    {
                        model.SubmitNum = int.Parse(ds.Tables[0].Rows[n]["SubmitNum"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList; 
	    }

	    #endregion  ��Ա����
	}
}

