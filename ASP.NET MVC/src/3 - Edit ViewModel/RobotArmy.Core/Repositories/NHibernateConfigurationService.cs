using System;
using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using RobotArmy.Core.Model;

namespace RobotArmy.Core.Repositories
{
    public interface INHibernateConfigurationService
    {
        ISessionFactory CreateSessionFactory();
        void CreateSchema(bool outputToConsole, IDbConnection connection);
    }

    public class NHibernateConfigurationService : INHibernateConfigurationService
    {
        private Configuration config;

        public ISessionFactory CreateSessionFactory()
        {
            
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c.FromConnectionStringWithKey("RobotArmyConnectionString")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Robot>())
                .ExposeConfiguration(GetSchemaConfiguration)
                .BuildSessionFactory();
        }


        private void GetSchemaConfiguration(Configuration configuration)
        {
            config = configuration;
        }

        public void CreateSchema(bool outputToConsole)
        {
            if (config == null)
                throw new Exception("You must CreateSessionFactory before attempting to CreateSchema.");
            var export = new SchemaExport(config);
            export.Drop(outputToConsole, true);
            export.Create(outputToConsole, true);
        }

        public void CreateSchema(bool outputToConsole, IDbConnection connection)
        {
            if (config == null)
                throw new Exception("You must CreateSessionFactory before attempting to CreateSchema.");
            new SchemaExport(config).Execute(outputToConsole, true, false, true, connection, null);
        }
    }
}
