using System;
using NUnit.Framework;
using UnitTester.BusinessObjects;

namespace UnitTester.BusinessObjects.Test
{
	/// <summary>
	/// The [TestFixture] attribute tells NUnit that 
	/// this class holds a bunch of tests.
	/// </summary>
	[TestFixture]
	public class SimpleAccountTest
	{

		#region setup

		SimpleAccount source;
		SimpleAccount destination;

		/// <summary>
		/// Runs at the start of every test.
		/// </summary>
		[SetUp]
		public void Init() 
		{
			// create two accounts in a known start state
			source = new SimpleAccount();
			source.Deposit(200);

			destination = new SimpleAccount();
			destination.Deposit(150);
		}
		#endregion


		/// <summary>
		/// Attempt to transfer funds from one account to another.
		/// </summary>
		[Test]
		public void TransferFunds() 
		{
			// attempt to transfer funds.
			source.TransferFunds(destination, 100);
			
			#region Assert Methods
			// the Assert object has a bunch of interesting
			// methods for running an assert:
			//Assert.AreSame();
			//Assert.IsFalse(); 
			//Assert.IsTrue;
			//Assert.IsNotNull(); 
			//Assert.IsNull();
			#endregion

			// in this case, just make sure that the 
			// balances are what we expected them to be. 
			Assert.AreEqual(100, source.Balance);
			Assert.AreEqual(250, destination.Balance);
			
		}




		#region Transfer w/ Exception

		[Test]
		[ExpectedException(typeof(InsufficientFundsException))]
		public void TransferWithInsufficientFunds() 
		{
			// expected to fail with an InsufficientFundsException
			source.TransferFunds(destination, 300);
		}

		#endregion

		#region Transfer / ignored
		[Test]
		[Ignore("Needs Transaction Support")]
		public void TransferWithInsufficientFundsTransaction() 
		{
			bool threwException = false;
			try 
			{
				source.TransferFunds(destination, 300);
			} 
			catch (InsufficientFundsException) 
			{
				// OK
				threwException = true;
			}
			Assert.IsTrue(threwException);

			// expected failure, balances should not have changed
			Assert.AreEqual(200, source.Balance);
			Assert.AreEqual(150, destination.Balance);

		}
		#endregion

	}
}
