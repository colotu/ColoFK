using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.API.Sales.v1_5
{
    public partial class SalesHandler : YSWL.MALL.API.Sales.v1.SalesHandler
    {
        public SalesHandler() : base(false) { }
        public SalesHandler(bool _requestSecurity) : base(_requestSecurity) { }
    }
}
