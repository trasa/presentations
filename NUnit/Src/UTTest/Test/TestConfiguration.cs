using System;

namespace UnitTester.BusinessObjects.Test
{
	/// <summary>
	/// Parameters that might differ from user to user.
	/// Typically this would look these values up in a Config file.
	/// </summary>
	public sealed class TestConfiguration
	{
		private TestConfiguration(){}

		public static readonly string VirtualDirectory = "UnitTester/";
		public static readonly string CompleteApplicationName = "http://localhost/" + VirtualDirectory;
	}
}
