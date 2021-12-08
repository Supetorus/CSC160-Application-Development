using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;
using System;

namespace Login
{
	public partial class LoggingIn
	{
		/*		private static UsersTableAdapters.UserInfoTableAdapter _adapter = new UsersTableAdapters.UserInfoTableAdapter();
				private static Users _users = new Users();*/

		public static bool OpenDBCommand(string strDB, ref SqlConnection dbConn, ref SqlCommand sqlcmd)
		{
			if (sqlcmd.Connection.State != ConnectionState.Open)
			{
				dbConn.ConnectionString = "data source=(local);initial catalog=" + strDB + ";Trusted_Connection=True";
				//dbConn.ConnectionString = "data source=(local);user id=admin;pwd=devapp;initial catalog=" + strDB;
				//sqlcmd.CommandTimeout = 50;
				sqlcmd.Connection.Open();
				return true;
			}
			else return false;
		}

		public static bool IsUnique(string username, string email)
		{
			DataTable dt;
			Hashtable ht = new Hashtable();
			string sql;

			ht.Add("@Username", username);
			ht.Add("@Email", email);

			sql = "select * from tblUserInfo where Username = @Username";
			dt = GetDataTable("Users", ht, sql);
			if (dt.Rows.Count > 0) return false;

			sql = "select * from tblUserInfo where Email = @Email";
			dt = GetDataTable("Users", ht, sql);
			if (dt.Rows.Count > 0) return false;

			return true;
		}

		public static DataTable GetDataTable(string strDB, Hashtable htParameters, string SQL)
		{
			SqlConnection dbConn = new SqlConnection();
			DataTable dt = new DataTable();
			SqlDataAdapter myAdap;
			SqlCommand sqlCmd;

			sqlCmd = new SqlCommand(SQL, dbConn);

			foreach (DictionaryEntry hti in htParameters)
			{
				AddParam(ref sqlCmd, hti.Key.ToString(), hti.Value);
			}

			OpenDBCommand(strDB, ref dbConn, ref sqlCmd);
			myAdap = new SqlDataAdapter(sqlCmd);

			myAdap.Fill(dt);
			sqlCmd.Connection.Close();
			dbConn.Close();

			return dt;
		}

		public static long ExecuteIt(string strdb, string strSQL, Hashtable htParameters)
		{
			SqlConnection dbconn = new SqlConnection();
			SqlCommand sqlCmd;
			long x;

			sqlCmd = new SqlCommand(strSQL, dbconn);
			OpenDBCommand(strdb, ref dbconn, ref sqlCmd);

			foreach (DictionaryEntry hti in htParameters)
				AddParam(ref sqlCmd, hti.Key.ToString(), hti.Value);

			x = sqlCmd.ExecuteNonQuery();
			sqlCmd.Connection.Close();
			dbconn.Close();

			return x;
		}

		public static void AddParam(ref SqlCommand sqlCmd, string key, object value)
		{
			//key = Strings.Replace(key, " ", "_"); // parameters can't have spaces

			if (value == null)
				sqlCmd.Parameters.AddWithValue(key, System.DBNull.Value);
			else
				sqlCmd.Parameters.AddWithValue(key, value);
		}

		public static void UpdateNote(string username, string note)
		{
			Hashtable ht = new Hashtable();
			string sql;

			ht.Add("@Username", username);
			ht.Add("@Note", note);

			sql = "Update tblUserInfo set Note = @Note where Username = @Username";

			ExecuteIt("Users", sql, ht);
		}

		public static void AddUser(User user)
		{
			//DataTable dt;
			Hashtable ht = new Hashtable();
			string sql;

			ht.Add("@Name", user.Name);
			ht.Add("@Email", user.Email);
			ht.Add("@Username", user.Username);
			ht.Add("@Password", user.Password);

			sql = "Insert into tblUserInfo (Name, Email, Username, Password) Values(@Name, @Email, @Username, @Password)";

			ExecuteIt("Users", sql, ht);
		}

		public static bool CheckPass(string username, string password)
		{
			DataTable dt;
			Hashtable ht = new Hashtable();
			string sql;
			ht.Add("@Username", username);
			sql = "select * from tblUserInfo where Username = @Username";

			dt = GetDataTable("Users", ht, sql);
			if (dt.Rows.Count <= 0) return false;
			else { return dt.Rows[0]["Password"].ToString() == password; }
		}

		public static User GetUser(string username)
		{
			DataTable dt;
			Hashtable ht = new Hashtable();
			string sql;
			ht.Add("@Username", username);
			sql = "select * from tblUserInfo where Username = @Username";

			dt = GetDataTable("Users", ht, sql);

			return new User(dt.Rows[0]["Name"].ToString(), dt.Rows[0]["Email"].ToString(), dt.Rows[0]["Username"].ToString(), dt.Rows[0]["Password"].ToString(), dt.Rows[0]["Note"].ToString());
		}

		public static void Initialize()
		{
			/*_adapter.Fill(_users.UserInfo);*/
		}
	}
}
