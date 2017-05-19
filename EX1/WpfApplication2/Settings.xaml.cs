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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private SettingsViewModel vm;
        public Settings()
        {
            InitializeComponent();
            //vm = new SettingsViewModel();
            //this.DataContext = vm;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //vm.SaveSettings();
            new MainWindow().Show();
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void txtRows_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
