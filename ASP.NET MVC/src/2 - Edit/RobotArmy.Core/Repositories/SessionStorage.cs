using System;
using System.Web;
using NHibernate;

namespace RobotArmy.Core.Repositories
{
    public interface ISessionStorage
    {
        ISession Session { get; set; }
    }

    public class SimpleSessionStorage : ISessionStorage
    {
        public ISession Session { get; set; }
    }



    public class WebSessionStorage : ISessionStorage
    {
        private const string CurrentSessionKey = "nhibernate.current_session";

        public WebSessionStorage(HttpApplication app)
        {
            app.EndRequest += Application_EndRequest;
        }

        public ISession Session
        {
            get
            {
                HttpContext context = HttpContext.Current;
                var session = context.Items[CurrentSessionKey] as ISession;
                return session;
            }
            set
            {
                HttpContext context = HttpContext.Current;
                context.Items[CurrentSessionKey] = value;
            }
        }

        void Application_EndRequest(object sender, EventArgs e)
        {
            ISession session = Session;

            if (session != null)
            {
                session.Close();
                HttpContext context = HttpContext.Current;
                context.Items.Remove(CurrentSessionKey);
            }
        }
    } 
}
