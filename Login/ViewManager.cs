using Login.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Login
{
	public class ViewManager
	{
		public static Page LoginPage = new LoginPage();
		public static Page NewAccountPage = new NewAccountPage();

		private static MainWindow mainWindow = null;

		public static void RegisterWindow(MainWindow window)
		{
			mainWindow = window;
		}

		public static void SetPage(Page page)
		{
			mainWindow.SetPage(page);
		}
	}
}
