using System;
using System.Collections;
using System.Data.SqlClient;
using Blackfin.Util;

namespace UnitTester.BusinessObjects
{

	/// <summary>
	/// This contains methods to retrieve and create 
	/// objects based on the Account table.
	/// </summary>
	public sealed class AccountFactory 
	{
	
		///<summary>
		/// No instantiation available.
		///</summary>
		private AccountFactory() { } 
	
		/// <summary>
		/// Create a new Account.
		/// </summary>
		/// <returns>a Account that has not been created 
		/// in the database, yet.</returns>
		public static Account CreateAccount() 
		{
			return new Account();
		}
	

		/// <summary>
		/// Delete this account.
		/// </summary>
		/// <param name="id">the id to delete</param>
		public static void DeleteAccount(int id) 
		{
			string sql = "DELETE account WHERE id = " + id;
			Executor exec = new Executor(ConnectionFactory.GetInstance());
			exec.RunSQL(sql);
		}


		///<summary>
		/// Get One Instance of this class based off of primary key.
		/// </summary>
		public static Account GetAccount(int id) 
		{
			string sql = Account.GetSelect() +
				" WHERE Account.ID = " + id;
			
			return (Account)DataReaderContainer.ExecuteObject(sql, 
					ConnectionFactory.GetInstance(), 
					typeof(Account));
		}
		
		/// <summary>
		/// Return a collection of this class. 
		/// <see cref="SomeException">Some other Thing.</see>
		/// </summary>
		/// <returns>A Collection of Accounts</returns>
		public static ICollection GetAccounts() 
		{
			string sql = Account.GetSelect() + " ORDER BY Account.ID";
			return DataReaderContainer.ExecuteCollection(sql, 
				ConnectionFactory.GetInstance(), 
				typeof(Account));
		}
	}
}
