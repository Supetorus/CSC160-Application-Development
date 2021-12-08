using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Linq;

namespace WPF
{
	public partial class DB : Window
	{
		private NamesTableAdapters.tblNamesTableAdapter adNames = new NamesTableAdapters.tblNamesTableAdapter();
		private Names dsNames = new Names();
		public DB()
		{
			InitializeComponent();
		}

		public bool OpenDBCommand(string strDB, ref SqlConnection dbConn, ref SqlCommand sqlcmd)
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

		public DataTable GetDataTable(string strDB, Hashtable htParameters, string SQL)
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

		public long ExecuteIt(string strdb, string strSQL, Hashtable htParameters)
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

		public void AddParam(ref SqlCommand sqlCmd, string key, object value)
		{
			//key = Strings.Replace(key, " ", "_"); // parameters can't have spaces

			if (value == null)
				sqlCmd.Parameters.AddWithValue(key, System.DBNull.Value);
			else
				sqlCmd.Parameters.AddWithValue(key, value);
		}

		private void btnDoIt_Click(object sender, RoutedEventArgs e)
		{
			DataTable dt;
			Hashtable ht = new Hashtable();
			string sql;

			ht.Add("@ID", 3);

			ht.Add("@Name", "Power");
			sql = "Insert into tblNames (Name, Age) Values(@Name, 72)";
			ExecuteIt("AwesomeDB", sql, ht);
			ExecuteIt("AwesomeDB", sql, ht);
			ExecuteIt("AwesomeDB", sql, ht);
			ExecuteIt("AwesomeDB", sql, ht);
			ExecuteIt("AwesomeDB", sql, ht);
			sql = "Select * from tblNames";// where id=@ID";

			dt = GetDataTable("AwesomeDB", ht, sql);

			DataRow dr;
			dr = dt.Rows[0];
			int intID;
			intID = (int)dr["ID"];
			string s;
			s = (string)dr["Name"];
			//MessageBox.Show(intID.ToString());
			//MessageBox.Show(s);


			sql = "delete from tblNames where Name=@Name";
			ExecuteIt("AwesomeDB", sql, ht);

			sql = "select * from tblNames";

			dg.AutoGenerateColumns = true;
			dg.ItemsSource = dt.DefaultView;
			//if (dt.Rows.Count > 0) ; // query has a result.

			//set the info
			Names.tblNamesRow row = (Names.tblNamesRow)dsNames.tblNames.NewRow();
			row.Name = "Randall";
			row.Age = 75;
			//add row to the database in local memory
			dsNames.tblNames.AddtblNamesRow(row);
			//update the server database
			adNames.Update(dsNames);

			MessageBox.Show("Name " + row.Name + " was added", "added", MessageBoxButton.OK, MessageBoxImage.Information);

			/*			var s = (from NamesTable in dsNames.tblNames
								 where NamesTable.ID==4
								 select NamesTable.Name);

						MessageBox.Show(s.First());*/
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
/*			adNames.Fill(dsNames.tblNames);
			DataContext = dsNames.tblNames;*/
		}
	}
}