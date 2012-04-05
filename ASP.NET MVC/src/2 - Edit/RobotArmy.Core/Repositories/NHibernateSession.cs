using NHibernate;

namespace RobotArmy.Core.Repositories
{
    public static class NHibernateSession
    {
        public static INHibernateConfigurationService Init(ISessionStorage storage, INHibernateConfigurationService config)
        {
            Storage = storage;
            SessionFactory = config.CreateSessionFactory();

            return config;
        }

        public static ISessionFactory SessionFactory { get; private set; }
        public static ISessionStorage Storage { get; private set; }

        public static ISession Current
        {
            get
            {
                ISession session = Storage.Session;

                if (session == null)
                {
                    session = SessionFactory.OpenSession();
                    Storage.Session = session;
                }

                return session;
            }
        }
    }
}
