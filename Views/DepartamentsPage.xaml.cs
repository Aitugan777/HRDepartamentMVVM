﻿using HRDepartamentMVVM.ViewModels;
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

namespace HRDepartamentMVVM.Views
{
    /// <summary>
    /// Логика взаимодействия для DepartamentsPage.xaml
    /// </summary>
    public partial class DepartamentsPage : Page
    {
        public DepartamentsPage()
        {
            InitializeComponent();

            DataContext = new DepartamentsViewModel();
        }
    }
}
