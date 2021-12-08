using Login.Pages;
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

namespace Login
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		private void Submit_Click(object sender, RoutedEventArgs e)
		{
			Submit();
		}

		private void NewAccount_Click(object sender, RoutedEventArgs e)
		{
			ViewManager.SetPage(ViewManager.NewAccountPage);
		}

		private void Key_Down(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter) Submit();
		}

		private void Submit()
		{
			if (LoggingIn.CheckPass(txtUsername.Text, pwPassword.Password))
			{
				pwPassword.Password = "";
				ViewManager.SetPage(new InsidePage(txtUsername.Text));
			}
			else
			{
				MessageBox.Show("Sorry, that login info is incorrect.");
			}
		}
	}
}
