using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSWL.MALL.Model.Shop.Order
{
    public class Stock
    {
        #region Model

        private int _depotId;
        private string _sku;
        private int _salestock;
        private int _usedstock;

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int DepotId
        {
            set { _depotId = value; }
            get { return _depotId; }
        }

        /// <summary>
        /// SKU值
        /// </summary>
        public string SKU
        {
            set { _sku = value; }
            get { return _sku; }
        }
        /// <summary>
        /// 可销库存
        /// </summary>
        public int SaleStock
        {
            set { _salestock = value; }
            get { return _salestock; }
        }
        /// <summary>
        /// 占用库存
        /// </summary>
        public int UsedStock
        {
            set { _usedstock = value; }
            get { return _usedstock; }
        }

        private int _ownerId = 0; //货主
        /// <summary>
        /// 货主ID
        /// </summary>
        public int OwnerId
        {
            set { _ownerId = value; }
            get { return _ownerId; }
        }
        #endregion Model
    }
}
