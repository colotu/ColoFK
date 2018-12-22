using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YSWL.MALL.API.Sales.v1
{
    public partial class SalesHandler : YSWL.Components.Handlers.API.HandlerBase
    {
        public SalesHandler() : base(false) { }
        public SalesHandler(bool _requestSecurity) : base(_requestSecurity) { }
    }
}
