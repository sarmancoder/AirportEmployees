using AirportEmployees.ViewModels;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
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
using System.Xml.Serialization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AirportEmployees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        App app = (App)Application.Current;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AirportEmployees.ViewModels.EmployeeViewModel(app.Connection);
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            ((EmployeeViewModel)DataContext).PreviousPage();
        }

        private void NextPage(object sender, RoutedEventArgs e)
        {
            ((EmployeeViewModel)DataContext).NextPage();
        }
    }
}