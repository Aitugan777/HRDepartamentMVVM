using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HRDepartamentMVVM.Data;

namespace HRDepartamentMVVM.Models
{
    public class Departament : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private ObservableCollection<int> cabinets;
        public ObservableCollection<int> Cabinets
        {
            get { return cabinets; }
            set
            {
                cabinets = value;
                OnPropertyChanged("Cabinets");
            }
        }


        public ObservableCollection<Employee> Employees { get => GetEmployees(); }

        private ObservableCollection<Employee> GetEmployees()
        {
            ObservableCollection<Employee> list = new ObservableCollection<Employee>();
            foreach (Employee employee in Data.Data.DataBase.Employees)
            {
                if (employee.Departament == this.Name)
                    list.Add(employee);
            }
            return list;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
