using System;
using NUnit.Framework;
using NUnit.Extensions.Asp;
using NUnit.Extensions.Asp.AspTester;
using NUnit.Extensions.Asp.HtmlTester;

namespace UnitTester.BusinessObjects.Test
{
	/// <summary>
	/// Extend all other Web Tests from this class.
	/// </summary>
	public class WebTest : WebFormTestCase
	{
		/// <summary>
		/// Load the given page into the CurrentWebForm
		/// </summary>
		/// <param name="name"></param>
		protected void LoadPage(string name) 
		{
			string fullName = TestConfiguration.CompleteApplicationName + name;
			Console.WriteLine("LoadPage: Attempting to Load " + fullName);
			Browser.GetPage(fullName);
			AssertCurrentPage(name);
		}


		/// <summary>
		/// Are where where we think we are?
		/// </summary>
		/// <param name="name">page name to check</param>
		protected void AssertCurrentPage(string name) 
		{
			string requested = TestConfiguration.VirtualDirectory + name;
			// prefix with / if needed
			if (!requested.StartsWith("/")) 
				requested = "/" + requested;
		
			// remove querystring
			requested = requested.Split(new char[] { '?' })[0];

			string actual = Browser.CurrentUrl.LocalPath;
			if (String.Compare(actual, requested, true) != 0)
				WebFormTestCase.Fail("Not at the requested page: " + name);
		}



		[Test]
		public void TestDummy() 
		{
			// thrown here to get rid of annoying warning.
		}
	}
}
