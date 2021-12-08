using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Login.Pages
{
	/// <summary>
	/// Interaction logic for Inside.xaml
	/// </summary>
	public partial class InsidePage : Page
	{
		private User _user;
		public InsidePage(string username)
		{
			InitializeComponent();
			_user = LoggingIn.GetUser(username);
			txtWelcome.Text = $"Welcome {_user.Username}";
			txtInfo.Text = $"Name: {_user.Name}\n" +
				$"Email: {_user.Email}\n" +
				$"Username: {_user.Username}\n" +
				$"Password: {_user.Password}";
			txtNote.Text = _user.Note;
		}

		private void LogOut_Click(object sender, RoutedEventArgs e)
		{
			ViewManager.SetPage(ViewManager.LoginPage);
		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			LoggingIn.UpdateNote(_user.Username, txtNote.Text);
		}
	}
}
