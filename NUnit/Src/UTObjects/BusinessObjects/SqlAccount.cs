using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Blackfin.Util;

namespace UnitTester.BusinessObjects
{

	/// <summary>
	/// This object represents the properties and methods for the 
	/// Account table.
	/// </summary>
	public class Account 
	{
	
		#region Vars 
		private int id;
		private string name;
		private decimal balance;
		#endregion
	
		#region Constructors
		/// <summary>
		/// Create a new, empty, object.
		/// </summary>
		public Account() 
		{
		}
		
		/// <summary>
		/// Create a new object based off of the current 
		/// position of this DataReader.
		/// </summary>
		/// <param name="dr">the object to read from</param>
		public Account(SqlDataReader dr) 
		{
			id = dr.GetInt32(FLD_ID);
			name = dr.GetString(FLD_NAME);
			balance = dr.GetDecimal(FLD_BALANCE);
		}

		#endregion
		
		#region Public Properties
		public int ID 
		{
			get { return id; }
		}
		
		public string Name 
		{
			get { return name; }
			set { name = value; }
		}

		public decimal Balance 
		{
			get { return balance; }
			set { balance = value; }
		}
		#endregion
	
		#region Save Record
		
		public virtual void Save() 
		{
			if (id == 0) 
			{
				AddNew();
			} 
			else 
			{
				Update();
			}
		}

		protected virtual void AddNew() 
		{
			string sql = InsertSql;
			Executor exec = new Executor(ConnectionFactory.GetInstance());
			SqlCommand cmd = new SqlCommand(sql, exec.Connection);
			SetParameters(cmd);
			id = Executor.RunSQLReturnID(cmd);
		}

		protected virtual void Update() 
		{
			string sql = UpdateSql;
			Executor exec = new Executor(ConnectionFactory.GetInstance());
			SqlCommand cmd = new SqlCommand(sql, exec.Connection);
			SetParameters(cmd);
			cmd.Parameters.Add("@ID", id);

			Executor.RunCommand(cmd);
		}


		/// <summary>
		/// Returns the SQL Insert string for this class.
		/// </summary>
		protected virtual string InsertSql 
		{
			get 
			{
				return @"INSERT INTO dbo.Account (
				Name, 
				Balance
				) VALUES (
				@Name, 
				@Balance
				)";
			}
		}
	
		protected virtual string UpdateSql 
		{
			get 
			{ 
				return @"UPDATE dbo.Account SET
				Name = @Name, 
				Balance = @Balance 
				WHERE ID = @ID ";
			}
		}
		
		protected virtual void SetParameters(SqlCommand cmd) 
		{
			cmd.Parameters.Add("@Name", name);
			cmd.Parameters.Add("@Balance", balance);

		}

		#endregion
		
		#region GetSelect
		internal static string GetSelect() 
		{
			return @"SELECT 
				Account.ID,
				Account.Name,
			Account.Balance
			FROM dbo.Account
			";
		}
		internal const int FLD_ID = 0;
		internal const int FLD_NAME = 1;
		internal const int FLD_BALANCE = 2;
		#endregion
		
	}
}
