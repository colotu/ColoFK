﻿/**
* Add.cs
*
* 功 能： [N/A]
* 类 名： Add.cs
*
* Ver        变更日期                           负责人          变更内容
* ───────────────────────────────────
* V0.01   2012年6月13日 20:46:27    Rock            创建
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using YSWL.Common;
using System.Collections.Generic;
using System.Web.UI.WebControls;
namespace YSWL.MALL.Web.Admin.Shop.ProductType
{
    public partial class Step2_1 : PageBaseAdmin
    {
        protected override int Act_PageLoad { get { return 498; } } //Shop_扩展属性_新增页
        YSWL.MALL.BLL.Shop.Products.AttributeInfo bll = new YSWL.MALL.BLL.Shop.Products.AttributeInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ProductTypeId == 0)
                {
                    YSWL.Common.MessageBox.ShowFailTip(this, "参数错误，正在返回商品类型列表页...", "list.aspx");
                    return;
                }
            }
        }

        private int ProductTypeId
        {
            get
            {
                int producrTypeId = 0;
                if (!string.IsNullOrWhiteSpace(Request.Params["tid"]))
                {
                    producrTypeId = Globals.SafeInt(Request.Params["tid"], 0);
                }
                return producrTypeId;
            }
        }

        private long Action
        {
            get
            {
                long action = 0;
                if (!string.IsNullOrWhiteSpace(Request.Params["ed"]))
                {
                    action = Globals.SafeInt(Request.Params["ed"], 0);
                }
                return action;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtAttributeName.Text.Trim()))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, "扩展属性名称不能为空，长度限制在1-15个字符之间！");
                return;
            }
            if (bll.IsExistName(ProductTypeId, this.txtAttributeName.Text.Trim()))
            {
                YSWL.Common.MessageBox.ShowFailTip(this, "该类型下的扩展属性名称已存在，请换一个属性名称！");
                return;
            }
            if (!rbInput.Checked)
            {
                if (string.IsNullOrWhiteSpace(this.txtAttributeValue.Text.Trim()))
                {
                    YSWL.Common.MessageBox.ShowFailTip(this, "扩展属性的值，多个属性值可用“，”号隔开，每个值最多15个字符！");
                    return;
                }
            }
            string AttributeName = this.txtAttributeName.Text;
            string AttributeValue = this.txtAttributeValue.Text.Trim();

            YSWL.MALL.Model.Shop.Products.AttributeInfo model = new Model.Shop.Products.AttributeInfo();
            if (this.rbOne.Checked)
            {
                model.UsageMode = (int)YSWL.MALL.Model.Shop.Products.ProductAttributeModel.One;
            }
            else if (this.rbAny.Checked)
            {
                model.UsageMode = (int)YSWL.MALL.Model.Shop.Products.ProductAttributeModel.Any;
            }
            else
            {
                model.UsageMode = (int)YSWL.MALL.Model.Shop.Products.ProductAttributeModel.Input;
            }
            //ToDO: 获取属性值
            List<string> list = new List<string>();
            if (!this.rbInput.Checked)
            {
                string[] strArray = AttributeValue.Replace("\r\n", "\n").Replace("\n", ",").Replace("，", ",").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].Length <= 100)
                    {
                        string str2 = strArray[i].Replace("+", "");
                        if (!string.IsNullOrWhiteSpace(str2))
                        {
                            list.Add(str2);
                        }
                    }
                }
            }
            model.ValueStr = list;

            model.AttributeName = AttributeName;
            model.TypeId = ProductTypeId;

            if (bll.AttributeManage(model, Model.Shop.Products.DataProviderAction.Create))
            {
                if (Action == 0)
                {
                    YSWL.Common.MessageBox.ResponseScript(this, "parent.location.href='Step2.aspx?tid=" + ProductTypeId + "&ed=" + Action + "'");
                }
                else
                {
                    YSWL.Common.MessageBox.ResponseScript(this, "parent.location.href='Modify2.aspx?tid=" + ProductTypeId + "&ed=" + Action + "'");
                }
            }
            else
            {
                this.btnSave.Enabled = false;
                YSWL.Common.MessageBox.ShowFailTip(this, "保存失败！", "Step2.aspx");
            }
        }
    }
}
