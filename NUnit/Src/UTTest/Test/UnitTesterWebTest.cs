using System;
using NUnit.Framework;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Extensions.Asp.HtmlTester;

namespace UnitTester.BusinessObjects.Test
{
	/// <summary>
	/// Example Tests using NUnitASP
	/// </summary>
	[TestFixture]
	public class UnitTesterWebTest : WebTest
	{
		[Test]
		public void GetAllPages() 
		{
			/// load the view accounts page - does the page compile 
			/// and display properly?
			/// This is a good and simple test.  
			/// 
			/// An easy bug to miss is to move a UserControl or Page
			/// and forget to change all the references to it.
			/// or, to change a data-bound field name and 
			/// forget a references...
			LoadPage("ViewAccounts.aspx");
		}





		[Test]
		public void CreateAccountWithBadInput() 
		{
			// an example of a better test -- 
			// Users report that if you press the Create button without
			// entering appropriate values, the page gives an error instead
			// of dealing with things gracefully.
			//
			// we fix the problem using validators and need to make sure the
			// problem doesn't occur in the future.


			Browser.GetPage("http://localhost/UnitTester/ViewAccounts.aspx");
			
			// no input given -- should be dealt with gracefully. 
			// (not with an error)
			ButtonTester btnCreate = new ButtonTester("btnCreate", 
														CurrentWebForm);
			btnCreate.Click(); 
		}






		[Test]
		public void CreateAccount() 
		{
			// use the ViewAccounts page to create a new account.
			// This shows how to interact with the asp form, but also
			// that testing the ASPX page doesn't have as much value
			// as you might think.


			#region some constants
			const string newName = "Testing Account";
			const string newBalance = "1234";
			#endregion



			#region set up the page

			LoadPage("viewaccounts.aspx");

			TextBoxTester txtName = new TextBoxTester("txtName", 
														CurrentWebForm);
			TextBoxTester txtBalance = new TextBoxTester("txtBalance", 
														CurrentWebForm);
			ButtonTester btnCreate = new ButtonTester("btnCreate", 
														CurrentWebForm);
			#endregion




			#region fill in some data & submit form

			txtName.Text = newName;
			txtBalance.Text = newBalance;

			btnCreate.Click();
			
			#endregion



			#region Datagrid - did it work?

			// the page has refreshed -- 
			// see if our new account is in the grid.
			DataGridTester grdAccounts = new DataGridTester(
													"grdAccounts", 
													CurrentWebForm);
			// the last row is the newest one:
			DataGridTester.Row newRow = grdAccounts.GetRow(grdAccounts.RowCount - 1);
			// first cell is account id, 2nd is account name
			// name should be the same as the value we just saved...
			Assert("New account wasn't last in the grid", 
				newRow.TrimmedCells[1] == newName);

			#endregion



			#region teardown
			// delete the account we just created.
			AccountFactory.DeleteAccount(int.Parse(newRow.TrimmedCells[0]));		
			#endregion

		}
	}
}
