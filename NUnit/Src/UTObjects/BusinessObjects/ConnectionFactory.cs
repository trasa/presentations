using System;
using System.Configuration;
using System.Data.SqlClient;
using Blackfin.Util;

namespace UnitTester.BusinessObjects
{
	/// <summary>
	/// Summary description for ConnectionFactory.
	/// </summary>
	public class ConnectionFactory : IConnectionFactory
	{

		private static ConnectionFactory instance = new ConnectionFactory();

		private ConnectionFactory() { }

		public static ConnectionFactory GetInstance()
		{
			return instance;
		}

		#region IConnectionFactory Members

		public SqlConnection CreateConnection()
		{
			return new SqlConnection(ConfigurationSettings.AppSettings["ConnString"]);
		}

		#endregion
	}
}
