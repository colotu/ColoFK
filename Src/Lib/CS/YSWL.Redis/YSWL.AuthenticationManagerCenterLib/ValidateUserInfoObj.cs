﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.AuthenticationManagerCenterLib
{
    public class ValidateUserInfoObj
    {
        #region Model
        private int _userid;
        private string _username;
        private string _nickname;
        private string _truename;
        private string _sex;
        private string _password;
        private string _phone;
        private string _email;
        private int? _employeeid;
        private string _departmentid;
        private bool? _activity;
        private string _usertype;
        private int? _style;
        private int? _user_icreator;
        private DateTime? _user_datecreate;
        private DateTime? _user_datevalid;
        private DateTime? _user_dateexpire;
        private int? _user_iapprover;
        private DateTime? _user_dateapprove;
        private int? _user_iapprovestate;
        private string _user_clang;
        private string _fromsource;
        private string _systemtag;

        /// <summary>
        /// 系统标识
        /// </summary>
        public string SystemTag
        {
            get { return _systemtag; }
            set { _systemtag = value; }
        }

        /// <summary>
        /// 登录来源
        /// </summary>
        public string FromSource
        {
            get { return _fromsource; }
            set { _fromsource = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
		/// 
		/// </summary>
		public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? EmployeeID
        {
            set { _employeeid = value; }
            get { return _employeeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool? Activity
        {
            set { _activity = value; }
            get { return _activity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Style
        {
            set { _style = value; }
            get { return _style; }
        }
        /// <summary>
        /// 创建者
        /// </summary>
        public int? User_iCreator
        {
            set { _user_icreator = value; }
            get { return _user_icreator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? User_dateCreate
        {
            set { _user_datecreate = value; }
            get { return _user_datecreate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? User_dateValid
        {
            set { _user_datevalid = value; }
            get { return _user_datevalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? User_dateExpire
        {
            set { _user_dateexpire = value; }
            get { return _user_dateexpire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? User_iApprover
        {
            set { _user_iapprover = value; }
            get { return _user_iapprover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? User_dateApprove
        {
            set { _user_dateapprove = value; }
            get { return _user_dateapprove; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? User_iApproveState
        {
            set { _user_iapprovestate = value; }
            get { return _user_iapprovestate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string User_cLang
        {
            set { _user_clang = value; }
            get { return _user_clang; }
        }
        /// <summary>
        /// 先转化为字符串，方便json 序列化
        /// </summary>
        public string Password  
        {
            set { _password = value; }
            get { return _password; }
        }
        #endregion Model
    }
}
