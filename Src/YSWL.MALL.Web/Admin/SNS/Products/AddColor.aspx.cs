using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using YSWL.Common;

namespace YSWL.MALL.Web.Admin.SNS.Products
{
    public partial class AddColor : PageBaseAdmin
    {
         protected  string strColorValue;
         protected StringBuilder strSelectValue = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindColor();
            }
            
        }
        private void BindColor()
        {
                int id = YSWL.Common.Globals.SafeInt(Id, 0);
                YSWL.MALL.BLL.SNS.Products productBll = new BLL.SNS.Products();
                YSWL.MALL.Model.SNS.Products productModel = new Model.SNS.Products();
                productModel = productBll.GetModel(id);
                if (productModel != null)
                {
                  //  txtColorSelect.Text = productModel.Color;
                    this.hidValue.Value = productModel.Color;
                }
        }


        public string Id
        {
            get
            {
                string id = Request.QueryString["Id"];
                return id;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            int id = YSWL.Common.Globals.SafeInt(Id, 0);
            YSWL.MALL.BLL.SNS.Products productBll = new BLL.SNS.Products();
            YSWL.MALL.Model.SNS.Products productModel = new Model.SNS.Products();
            productModel = productBll.GetModel(id);
            if (productModel != null)
            {
                productModel.Color = this.hidValue.Value;
                productBll.Update(productModel);
                lblTip.Visible = true;
                LogHelp.AddUserLog(CurrentUser.UserName, CurrentUser.UserType, "更新商品（ProductId="+id+"）的颜色成功", this);
            }

            BindColor();
        }


    }
}