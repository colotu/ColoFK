﻿using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.Email.Model;
using YSWL.MALL.Model.Ms;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.Ms;
using YSWL.MALL.BLL.SysManage;
using System.Text;
using YSWL.MALL.Model.Shop.Order;
using YSWL.MALL.Model.SysManage;

namespace YSWL.MALL.BLL.Ms
{
    /// <summary>
    /// EmailTemplet
    /// </summary>
    public partial class EmailTemplet
    {
        private readonly IEmailTemplet dal = DAMs.CreateEmailTemplet();
        YSWL.MALL.BLL.MailConfig config = new MailConfig();
        public EmailTemplet()
        { }
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
        public bool Exists(int TempletId)
        {
            return dal.Exists(TempletId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(YSWL.MALL.Model.Ms.EmailTemplet model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(YSWL.MALL.Model.Ms.EmailTemplet model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TempletId)
        {

            return dal.Delete(TempletId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TempletIdlist)
        {
            return dal.DeleteList(Common.Globals.SafeLongFilter(TempletIdlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Ms.EmailTemplet GetModel(int TempletId)
        {

            return dal.GetModel(TempletId);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public YSWL.MALL.Model.Ms.EmailTemplet GetModelByCache(int TempletId)
        {

            string CacheKey = "EmailTempletModel-" + TempletId;
            object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(TempletId);
                    if (objModel != null)
                    {
                        int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
                        YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (YSWL.MALL.Model.Ms.EmailTemplet)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Ms.EmailTemplet> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<YSWL.MALL.Model.Ms.EmailTemplet> DataTableToList(DataTable dt)
        {
            List<YSWL.MALL.Model.Ms.EmailTemplet> modelList = new List<YSWL.MALL.Model.Ms.EmailTemplet>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                YSWL.MALL.Model.Ms.EmailTemplet model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        /// 标签替换
        /// </summary>
        /// <param name="body"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public string ReplaceTag(string body, params string[][] values)
        {
            if (values == null || values.Length < 1) return body;
            foreach (string[] keyValue in values)
            {
                if (keyValue.Length != 2) continue;
                body = body.Replace(
                    keyValue[0], //Key
                        YSWL.Common.Globals.HtmlEncode(
                            keyValue[1]) //Value
                    );
            }
            return body;
        }
        /// <summary>
        /// 发送注册认证邮件
        /// </summary>
        /// <param name="EmailUrl"></param>
        /// <param name="Desc"></param>
        /// <returns></returns>
        public bool SendRegisterEmail(string username, string EmailUrl)
        {
            string SecretKey = Guid.NewGuid().ToString().Replace("-", "");
            YSWL.MALL.BLL.SysManage.VerifyMail bll = new YSWL.MALL.BLL.SysManage.VerifyMail();
            YSWL.MALL.Model.SysManage.VerifyMail model = new YSWL.MALL.Model.SysManage.VerifyMail();
            model.UserName = username;
            model.KeyValue = SecretKey;
            model.CreatedDate = DateTime.Now;
            model.Status = 0;// 0:邮箱验证未通过1：邮箱验证通过2：已过期
            model.ValidityType = 0;//0：邮箱验证 1：密码找回  
            bll.Add(model);

            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_Register"), 0);
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            if (emailModel != null)
            {
                string emailBody = ReplaceTag(emailModel.EmailBody,
                    new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
                    new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
                    new[] { "{SecretKey}", SecretKey },
                    new[] { "{UserName}", username }
                    );
                try
                {
                    YSWL.MALL.Model.MailConfig mailModel = config.GetModel();
                    if (mailModel != null && !String.IsNullOrWhiteSpace(mailModel.Mailaddress))
                    {
                        YSWL.Common.MailSender.Send(mailModel.SMTPServer, mailModel.Username, YSWL.Common.DEncrypt.DESEncrypt.Decrypt(mailModel.Password), mailModel.Mailaddress, EmailUrl, "", "", emailModel.EmailSubject, emailBody, true, Encoding.UTF8, true, mailModel.SMTPSSL, null);
                        return true;
                    }
                    // MailSender.Send(EmailUrl, emailModel.EmailSubject, emailBody);
                    return true;
                }
                catch (Exception e)
                {
                    LogHelp.AddErrorLog("发送邮件失败，【" + e.Message + "】", e.StackTrace);
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 发送找回密码邮件
        /// </summary>
        /// <param name="EmailUrl"></param>
        /// <param name="Desc"></param>
        /// <returns></returns>
        public bool SendFindPwdEmail(string username, string EmailUrl)
        {
            string SecretKey = Guid.NewGuid().ToString().Replace("-", "");
            YSWL.MALL.BLL.SysManage.VerifyMail bll = new YSWL.MALL.BLL.SysManage.VerifyMail();
            YSWL.MALL.Model.SysManage.VerifyMail model = new YSWL.MALL.Model.SysManage.VerifyMail();
            model.UserName = username;
            model.KeyValue = SecretKey;
            model.CreatedDate = DateTime.Now;
            model.Status = 0;// 0:邮箱验证未通过1：邮箱验证通过2：已过期
            model.ValidityType = 1;//0：邮箱验证 1：密码找回  
            bll.Add(model);
            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_FindPwd"), 1);
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            if (emailModel != null)
            {
                string emailBody = ReplaceTag(emailModel.EmailBody,
                    new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
                    new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
                    new[] { "{SecretKey}", SecretKey },
                    new[] { "{UserName}", username }
                    );
                try
                {
                    YSWL.MALL.Model.MailConfig mailModel = config.GetModel();
                    if (mailModel != null && !String.IsNullOrWhiteSpace(mailModel.Mailaddress))
                    {
                        YSWL.Common.MailSender.Send(mailModel.SMTPServer, mailModel.Username, YSWL.Common.DEncrypt.DESEncrypt.Decrypt(mailModel.Password), mailModel.Mailaddress, EmailUrl, "", "", emailModel.EmailSubject, emailBody, true, Encoding.UTF8, true, mailModel.SMTPSSL, null);
                        return true;
                    }
                    return false;
                }
                catch (Exception e)
                {
                    LogHelp.AddErrorLog("发送邮件失败，【" + e.Message + "】", e.StackTrace);
                    return false;
                }
            }
            return false;
        }


        /// <summary>
        /// 发送意见与反馈邮件
        /// </summary>
        /// <param name="EmailUrl"></param>
        /// <param name="Desc"></param>
        /// <returns></returns>
        public bool SendFeedbackEmail(YSWL.MALL.Model.Members.Feedback FeedBackModel)
        {
            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_Feedback"), 0);
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            if (emailModel != null && FeedBackModel != null)
            {
                string emailBody = ReplaceTag(emailModel.EmailBody,
                    new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
                    new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
                    new[] { "{Question}", FeedBackModel.Description },
                    new[] { "{UserName}", FeedBackModel.UserName },
                    new[] { "{ReplyResult}", FeedBackModel.Result },
                    new[] { "{QuestionDate}", FeedBackModel.CreatedDate.ToString("yyyy-MM-dd") }
                    );
                try
                {
                    MailSender.Send(FeedBackModel.UserEmail, emailModel.EmailSubject, emailBody);
                    return true;
                }
                catch (Exception e)
                {
                    LogHelp.AddErrorLog("发送邮件失败，【" + e.Message + "】", e.StackTrace);
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// 发送留言回复邮件
        /// </summary>
        /// <param name="guestBookId"></param>
        /// <param name="EmailUrl"></param>
        /// <returns></returns>
        public bool SendGuestBookEmail(YSWL.MALL.Model.Members.Guestbook GuestBookModel)
        {
            YSWL.MALL.BLL.Members.Guestbook guestBookBll = new Members.Guestbook();
            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_GuestBook"), 0);
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            if (emailModel != null && GuestBookModel != null && GuestBookModel.ParentID.HasValue && GuestBookModel.ParentID.Value > 0)
            {
                YSWL.MALL.Model.Members.Guestbook parentModel = guestBookBll.GetModel(GuestBookModel.ParentID.Value);
                if (parentModel != null)
                {
                    string emailBody = ReplaceTag(emailModel.EmailBody,
                        new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
                        new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
                        new[] { "{Description}", parentModel.Description },
                        new[] { "{UserName}", parentModel.CreateNickName },
                        new[] { "{ReplyResult}", GuestBookModel.Description },
                        new[] { "{QuestionDate}", parentModel.CreatedDate.ToString("yyyy-MM-dd") }
                        );
                    try
                    {
                             YSWL.MALL.Model.MailConfig mailModel = config.GetModel();
                             if (mailModel != null && !String.IsNullOrWhiteSpace(mailModel.Mailaddress))
                        {
                            YSWL.Common.MailSender.Send(mailModel.SMTPServer, mailModel.Username,
                                                             YSWL.Common.DEncrypt.DESEncrypt.Decrypt(
                                                                 mailModel.Password), mailModel.Mailaddress, GuestBookModel.CreatorEmail,
                                                             "", "", emailModel.EmailSubject, emailBody, true,
                                                             Encoding.UTF8, true, mailModel.SMTPSSL, null);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {

                        LogHelp.AddErrorLog("发送邮件失败，【" + e.Message + "】", e.StackTrace);
                        return false;
                    }
                }
            }
            return false;
        }

        public bool SendInqueryEmail(int id, string EmailUrl)
        {
            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_Inquery"), 0);
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            //if (emailModel != null && GuestBookModel != null && GuestBookModel.ParentID.HasValue && GuestBookModel.ParentID.Value > 0)
            //{
            //    YSWL.MALL.Model.Members.Guestbook parentModel = guestBookBll.GetModel(GuestBookModel.ParentID.Value);
            //    if (parentModel != null)
            //    {
            //        string emailBody = ReplaceTag(emailModel.EmailBody,
            //            new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
            //            new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
            //            new[] { "{Description}", parentModel.Description },
            //            new[] { "{UserName}", parentModel.CreateNickName },
            //              new[] { "{ReplyResult}", GuestBookModel.Description },
            //                 new[] { "{QuestionDate}", parentModel.CreatedDate.ToString("yyyy-MM-dd") }
            //            );
            //        try
            //        {
            //            MailSender.Send(EmailUrl, emailModel.EmailSubject, emailBody);
            //            return true;
            //        }
            //        catch (Exception e)
            //        {
            //            return false;
            //            throw (e);
            //        }
            //    }
            //}
            return false;
        }

        public  bool SendOrderEmail(YSWL.MALL.Model.Shop.Order.OrderInfo orderInfo,string email)
        {

            int TempletId = Common.Globals.SafeInt(ConfigSystem.GetValueByCache("EmailTemplet_Order"), 0);
            if (TempletId == 0)
                return false;
            YSWL.MALL.Model.Ms.EmailTemplet emailModel = GetModelByCache(TempletId);
            if (emailModel != null && orderInfo != null)
            {
                string emailBody = ReplaceTag(emailModel.EmailBody,
                    new[] { "{Domain}", System.Web.HttpContext.Current.Request.Url.Authority },
                    new[] { "{CreatedDate}", DateTime.Now.ToString("yyyy-MM-dd") },
                    new[] { "{UserName}", orderInfo.BuyerName },
                    new[] { "{OrderCode}", orderInfo.OrderCode },
                    new[] { "{PaymentType}", orderInfo.PaymentTypeName },
                    new[] { "{OrderAmount}", orderInfo.Amount.ToString("F") },
                    new[] { "{OrderDate}", orderInfo.CreatedDate.ToString("yyyy-MM-dd") }
                    );
                try
                {
                        YSWL.MALL.Model.MailConfig mailModel = config.GetModel();
                        if (mailModel != null && !String.IsNullOrWhiteSpace(mailModel.Mailaddress))
                    {
                        YSWL.Common.MailSender.Send(mailModel.SMTPServer, mailModel.Username,
                                                         YSWL.Common.DEncrypt.DESEncrypt.Decrypt(mailModel.Password),
                                                         mailModel.Mailaddress, email, "", "",
                                                         emailModel.EmailSubject, emailBody, true, Encoding.UTF8, true,
                                                         mailModel.SMTPSSL, null);
                        return true;
                    }
                }
                catch (Exception e)
                {
                    LogHelp.AddErrorLog("发送邮件失败，【" + e.Message + "】", e.StackTrace);
                    return false;
                }
            }
            return false;
        }



        #endregion  ExtensionMethod
    }
}

