using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSWL.MALL.IDAL.Shop.Order
{
    public interface IStock
    {
        int GetWMSSalesStock(string sku, int depotId,int supplier);

        int GetERPSalesStock(string sku, int depotId);
    }
}
