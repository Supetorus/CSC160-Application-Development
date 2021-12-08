using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Login
{
	/// <summary>
	/// Interaction logic for NewUser.xaml
	/// </summary>
	public partial class NewAccountPage : Page
	{
		public NewAccountPage()
		{
			InitializeComponent();
		}

		private void CreateAccount_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(txtName.Text))
			{
				MessageBox.Show("You must have a name.");
				return;
			}
			if (string.IsNullOrEmpty(txtUsername.Text))
			{
				MessageBox.Show("You must have a username.");
				return;
			}
			if (string.IsNullOrEmpty(txtEmail.Text))
			{
				MessageBox.Show("You must have an email.");
				return;
			}
			if (string.IsNullOrEmpty(pwPassword.Password))
			{
				MessageBox.Show("You must have a password.");
				return;
			}

			if (pwPassword.Password.Length < 8)
			{
				MessageBox.Show("Your password is too short.");
				return;
			}

			if (txtUsername.Text.Length < 4)
			{
				MessageBox.Show("Your username is too short.");
				return;
			}

			User user = new User(txtName.Text, txtEmail.Text, txtUsername.Text, pwPassword.Password);
			Debug.WriteLine(user.ToString());
			if (LoggingIn.IsUnique(txtUsername.Text, txtEmail.Text))
			{
				LoggingIn.AddUser(user);
				MessageBox.Show("Your account has been created.");
				ViewManager.SetPage(ViewManager.LoginPage);
			}
			else MessageBox.Show("An account already exists with that username or email.");
		}
	}
}
