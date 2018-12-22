using System;
using System.Data;

using System.Collections.Generic;

namespace YSWL.MALL.IDAL.CMS
{
	/// <summary>
	/// �ӿڲ�ClassType
	/// </summary>
	public interface IClassType
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ClassTypeID);
		/// <summary>
		/// ����һ������
		/// </summary>
        bool Add(YSWL.MALL.Model.CMS.ClassType model);
		/// <summary>
		/// ����һ������
		/// </summary>
		bool Update(YSWL.MALL.Model.CMS.ClassType model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		bool Delete(int ClassTypeID);
        /// <summary>
        /// ����ɾ������
        /// </summary>
		bool DeleteList(string ClassTypeIDlist );
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		YSWL.MALL.Model.CMS.ClassType GetModel(int ClassTypeID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
          /// <summary>
        /// ��������б�
        /// </summary>
        List<YSWL.MALL.Model.CMS.ClassType> DataTableToList(DataTable dt);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	} 
}
