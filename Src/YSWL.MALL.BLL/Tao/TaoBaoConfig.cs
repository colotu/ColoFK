using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YSWL.TaoBao;
using YSWL.MALL.Model.SysManage;
using YSWL.MALL.DALFactory;
using YSWL.MALL.BLL.SysManage;
namespace YSWL.MALL.BLL.Tao
{
    public class TaoBaoConfig
    {

        public static ITopClient GetTopClient()
        {
            string taoBaoAppkey = SysManage.ConfigSystem.GetValue("OpenAPI_TaoBaoAppkey");
            string taobaoAppsecret = SysManage.ConfigSystem.GetValue("OpenAPI_TaobaoAppsecret");
            string taobaoApiUrl = SysManage.ConfigSystem.GetValue("OpenAPI_TaobaoApiUrl");
            ITopClient client = new DefaultTopClient(taobaoApiUrl, taoBaoAppkey, taobaoAppsecret);
            return client;
        }

        /// <summary>
        /// /需要修改这部分
        /// </summary>
        //SysManage.ConfigSystem config = new ConfigSystem();
        //public static ITopClient GetTopClient()
        //{
        //    string TaoBaoAppkey = config.GetValue("OpenAPI_TaoBaoAppkey");
        //    string TaobaoAppsecret = config.GetValue("OpenAPI_TaobaoAppsecret");
        //    string TaobaoApiUrl = config.GetValue("OpenAPI_TaobaoApiUrl");
        //    ITopClient client = new DefaultTopClient(TaobaoApiUrl, TaoBaoAppkey, TaobaoAppsecret);
        //    return client;
        //}

        private ApplicationKeyType applicationKeyType = ApplicationKeyType.OpenAPI;

        public TaoBaoConfig(ApplicationKeyType keyType)
        {
            applicationKeyType = keyType;
        }

        public const string TAOBAO_APPKEY = "OpenAPI_TaoBaoAppkey";

        public string TaoBaoAppkey
        {
            get { return ConfigSystem.GetValueByCache(TAOBAO_APPKEY, applicationKeyType); }
            set { ConfigSystem.Update(TAOBAO_APPKEY, value, applicationKeyType); }
        }

        public const string TAOBAO_APPSECRET = "OpenAPI_TaobaoAppsecret";

        public string TaobaoAppsecret
        {
            get { return ConfigSystem.GetValueByCache(TAOBAO_APPSECRET, applicationKeyType); }
            set { ConfigSystem.Update(TAOBAO_APPSECRET, value, applicationKeyType); }
        }

        public const string TAOBAO_APIURL = "OpenAPI_TaobaoApiUrl";

        public string TaobaoApiUrl
        {
            get { return ConfigSystem.GetValueByCache(TAOBAO_APIURL, applicationKeyType); }
            set { ConfigSystem.Update(TAOBAO_APIURL, value, applicationKeyType); }
        }
    }
}