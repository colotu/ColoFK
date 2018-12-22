using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.ViewModel.SAAS
{
    /// <summary>
	/// 企业级全局用户表
	/// </summary>
	[Serializable]
    public partial class UserInfo
    {
        public UserInfo()
        { }
        #region Model
        private long _userid;
        private string _loginname;
        private byte[] _passworld;
        private string _realname;
        private string _moblie;
        private int _state;
        private int _usertype;
        private long _parentid;
        private string _enterprisename;
        private DateTime _createtime;
        private DateTime _modeifytime;
        private string _createby;
        private string _modifyby;
        private int? _administratorlevel;
        private string _usernumber;
        private long _enterpriseid;
        private string _email;
        private int _fromtargettype;
        /// <summary>
        /// 主键Id
        /// </summary>
        public long UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public byte[] Passworld
        {
            set { _passworld = value; }
            get { return _passworld; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Moblie
        {
            set { _moblie = value; }
            get { return _moblie; }
        }
        /// <summary>
        /// 当前用户状态 0 禁用 1 启用 2 审核 3 冻结 4 其他
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 1 普通用户  2 管理员用户
        /// </summary>
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 用户归属上级用户id，顶级用户默认为0
        /// </summary>
        public long ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModeifyTime
        {
            set { _modeifytime = value; }
            get { return _modeifytime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy
        {
            set { _createby = value; }
            get { return _createby; }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyBy
        {
            set { _modifyby = value; }
            get { return _modifyby; }
        }
        /// <summary>
        /// 0 普通用户 1  顶级管理员  2  2级管理员 依次类推
        /// </summary>
        public int? AdministratorLevel
        {
            set { _administratorlevel = value; }
            get { return _administratorlevel; }
        }
        /// <summary>
        /// 员工编号
        /// </summary>
        public string UserNumber
        {
            set { _usernumber = value; }
            get { return _usernumber; }
        }
        /// <summary>
        /// 企业Id
        /// </summary>
        public long EnterpriseId
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 1 来源注册表 2  来源映射表
        /// </summary>
        public int FromTargetType
        {
            set { _fromtargettype = value; }
            get { return _fromtargettype; }
        }
        #endregion Model

        public static string GetStateStr(int s)
        {
            switch (s)
            {

                case 1:
                    //return "/Areas/SAAS/Themes/Default/Content/imgs/tingyong.png";
                    return "/Areas/SAAS/Themes/Y1/Content/images/qy.png";
                    
                case 0:
                case 2:
                case 3:
                default:
                    //return "/Areas/SAAS/Themes/Default/Content/imgs/qiyong.png";
                    return "/Areas/SAAS/Themes/Y1/Content/images/ty.png";

            }
        }

        public static string GetUserLevel(int? uLevel)
        {
            switch (uLevel)
            {
                case 0:
                    return "普通用户";
                case 1:
                    return "管理员";
                case 2:
                    return "二级管理员";
                case 3:
                    return "三级管理员";
                default:
                    return "";
            }

        }

    }
}
