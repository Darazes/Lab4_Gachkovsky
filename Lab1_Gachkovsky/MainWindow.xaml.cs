using Lab1_Gachkovsky.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1_Gachkovsky
{
    public partial class MainWindow : Window
    {
        public static int IdPerson { get; set; }
        public static int IdCompany { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Company_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCompany wc = new WindowCompany();
            wc.Show();
        }
        private void Person_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPerson wp = new WindowPerson();
            wp.Show();
        }
        private void OrgRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            WindowOrgRegistration wor = new WindowOrgRegistration();
            wor.Show();
        }
        private void OrgLegForm_OnClick(object sender, RoutedEventArgs e)
        {
            WindowOrgLegForm wolf = new WindowOrgLegForm();
            wolf.Show();
        }
    }
}
