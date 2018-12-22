using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSWL.MALL.DALFactory
{

    public sealed class DAMDM: DataAccessBase
    {
        /// <summary>
        /// 创建Depot数据层接口。
        /// </summary>
        public static YSWL.MALL.IDAL.MDM.IDepot CreateDepot()
        {
            string ClassNamespace = AssemblyPath + ".MDM.Depot";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.MDM.IDepot)objType;
        }

        /// <summary>
        /// 创建Line数据层接口。
        /// </summary>
        public static YSWL.MALL.IDAL.MDM.ILine CreateLine()
        {
            string ClassNamespace = AssemblyPath + ".MDM.Line";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (YSWL.MALL.IDAL.MDM.ILine)objType;
        }
    }
}
