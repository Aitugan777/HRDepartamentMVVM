using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRDepartamentMVVM.Models
{
    public class DataBase
    {
        ObservableCollection<Departament> departaments;
        public ObservableCollection<Departament> Departaments
        {
            get => departaments;
            set
            {
                departaments = value;
                OnPropertyChanged("Departaments");
            }
        }

        ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
