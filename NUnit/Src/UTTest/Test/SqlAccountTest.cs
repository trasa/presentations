using System;
using System.Collections;
using NUnit.Framework;

namespace UnitTester.BusinessObjects.Test
{
	/// <summary>
	/// Summary description for SqlAccountTest.
	/// </summary>
	[TestFixture]
	public class SqlAccountTest
	{
		[Test]
		public void GetAllAccounts() 
		{
			// test the factory method to retrieve all accounts
			ICollection col = AccountFactory.GetAccounts();
			foreach (Account acct in col) 
			{
				Assert.IsNotNull(acct);
			}
		}
	}
}
