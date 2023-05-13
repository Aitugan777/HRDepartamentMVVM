using HRDepartamentMVVM.Data;
using HRDepartamentMVVM.Views;
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

namespace HRDepartamentMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            f_Content.Content = departamentsPage;
        }

        public DepartamentsPage departamentsPage = new DepartamentsPage();

        EmployeesPage employeesPage = new EmployeesPage();

        private void OnBtnClick_Employees(object sender, RoutedEventArgs e)
        {
            f_Content.Content = employeesPage;
        }

        private void OnBtnClick_Departaments(object sender, RoutedEventArgs e)
        {
            f_Content.Content = departamentsPage;
        }

        private void OnBtnClick_Import(object sender, RoutedEventArgs e)
        {
            DBManager.Import();
        }

        private void OnBtnClick_Export(object sender, RoutedEventArgs e)
        {
            DBManager.Export();
        }
    }
}
