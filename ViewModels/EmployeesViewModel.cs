using HRDepartamentMVVM.Commands;
using HRDepartamentMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartamentMVVM.ViewModels
{
    internal class EmployeesViewModel : INotifyPropertyChanged
    {
        public EmployeesViewModel()
        {
            Data.Data.DataBase.Employees = new ObservableCollection<Employee>
            {
                new Employee() {FirstName = "Aitugan", LastName = "Irgalin", Position = "Middle", Salary = 90000, Departament = "Developers" },
                new Employee() {FirstName = "Andrey", LastName = "Timofeev", Position = "Middle", Salary = 80000, Departament = "Analitics" }
            };
        }

        private Employee selectedEmployee;

        public ObservableCollection<Employee> Employees { 
            get
            {
                return Data.Data.DataBase.Employees;
            }
        }

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private RelayCommand addEmployee;
        public RelayCommand AddEmployee
        {
            get
            {
                return addEmployee ??
                  (addEmployee = new RelayCommand(obj =>
                  {
                      Employee employee = new Employee();
                      Data.Data.DataBase.Employees.Add(employee);
                      SelectedEmployee = employee;
                  }));
            }
        }

        private RelayCommand removeEmployee;
        public RelayCommand RemoveEmployee
        {
            get
            {
                return removeEmployee ??
                  (removeEmployee = new RelayCommand(obj =>
                  {
                      Employee employee = obj as Employee;
                      if (employee != null)
                      {
                          Data.Data.DataBase.Employees.Remove(employee);
                      }
                  },
                 (obj) => obj != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
