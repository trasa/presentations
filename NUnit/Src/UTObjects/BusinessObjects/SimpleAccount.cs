using System;

namespace UnitTester.BusinessObjects
{
	/// <summary>
	/// The canonical Unit Test Example.
	/// See http://www.nunit.org/files/QuickStart.doc
	/// </summary>
	public class SimpleAccount
	{
		
		decimal balance;

		#region Methods and Properties


		/// <summary>
		/// Get the Balance
		/// </summary>
		public decimal Balance 
		{
			get { return balance; }
		}

		/// <summary>
		/// Add some value
		/// </summary>
		/// <param name="value"></param>
		public void Deposit(decimal value) 
		{
			balance += value;
		}


		/// <summary>
		/// Subtract some value
		/// </summary>
		/// <param name="value"></param>
		public void Withdraw(decimal value) 
		{
			balance -= value;
		}

		#endregion


		public void TransferFunds(SimpleAccount destination, decimal amount) 
		{
			// TODO - Implement Me.



			#region Implementation

			//destination.Deposit(amount);
			//Withdraw(amount);
			
			#endregion


			#region Implemented with Exception

			destination.Deposit(amount);
			
			if (balance - amount < 0) 
				throw new InsufficientFundsException();

			Withdraw(amount);
			
			#endregion
		}		

	}
}
