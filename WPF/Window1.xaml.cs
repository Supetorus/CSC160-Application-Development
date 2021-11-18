using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            //to access project resources use Properties.Resources.String1
            //to access project settings use Properties.Settings.String1

            Resources["AppString"] = "App string in code";
            btnResourceStatic.Content = FindResource("CompanyName");

            //dynamic resource can be created on the fly.
            Resources["Boogers"] = "Boogers";
            
        }

        private void btnChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Resources["CompanyColor"] = new SolidColorBrush(Colors.Blue);
            // only dynamic will change when the resource is changed.

            //static will change only if you explicitly update the .Content of the button.
            Resources["CompanyName"] = "New Company";
            btnResourceStatic.Content = FindResource("CompanyName");
        }
    }
}
