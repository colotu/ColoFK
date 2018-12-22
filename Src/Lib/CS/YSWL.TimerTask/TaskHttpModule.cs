using System.Web;

namespace YSWL.TimerTask
{
    public class TaskHttpModule : IHttpModule
    {

        #region IHttpModule 成员

        public void Dispose()
        {
            if (!Components.MvcApplication.IsInstall) return;

            Task.Instance().Dispose();
        }

        public void Init(HttpApplication context)
        {
            if (!Components.MvcApplication.IsInstall) return;

            Task.Instance().Start();
        }

        #endregion
    }
}
