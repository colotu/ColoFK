using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Webdiyer.WebControls.Mvc;

namespace YSWL.MALL.ViewModel.Shop
{
    public class SupplierModel
    {
        /// <summary>
        /// 产品信息
        /// </summary>
        public List<YSWL.MALL.Model.Shop.Supplier.SuppAreas> AreaPathList { get; set; }
        public YSWL.MALL.Model.Shop.Supplier.SuppAreas CurrentAreaModel { get; set; }
        public PagedList<YSWL.MALL.Model.Shop.Supplier.SupplierInfo> PageList  { get; set; }

}
    
}
