using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRDepartamentMVVM.Models;

namespace HRDepartamentMVVM.Data
{
    public class DateBase
    {
        public static ObservableCollection<Departament> Departaments { get; set; }

        public static ObservableCollection<Employee> Employees { get; set; }
    }
}
