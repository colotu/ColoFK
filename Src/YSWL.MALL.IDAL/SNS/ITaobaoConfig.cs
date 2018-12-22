using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.TaoBao;

namespace YSWL.IDAL.SNS
{
  public  interface ITaoBaoConfig
    {
      ITopClient GetTopClient();
    }
}
