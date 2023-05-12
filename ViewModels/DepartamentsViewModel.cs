using HRDepartamentMVVM.Commands;
using HRDepartamentMVVM.Models;
using HRDepartamentMVVM.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HRDepartamentMVVM.ViewModels
{
    partial class DepartamentsViewModel : INotifyPropertyChanged
    {
        public DepartamentsViewModel()
        {
            DateBase.Departaments = new ObservableCollection<Departament>
            {
                new Departament () {Name = "Developers", Cabinets = new List<int>() {13, 2 } },
                new Departament () {Name = "Analitics", Cabinets = new List<int>() {10, 3, 3 } },
            };
        }


        public ObservableCollection<Departament> Departaments
        {
            get
            {
                return DateBase.Departaments;
            }
        }


        private Departament selectedDepartament;

        public Departament SelectedDepartament
        {
            get { return selectedDepartament; }
            set
            {
                selectedDepartament = value;
                OnPropertyChanged("SelectedDepartament");
                OnPropertyChanged("Cabinets");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddDepartament
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Departament departament = new Departament() { Name = "Новый отдел"};
                      DateBase.Departaments.Add(departament);
                      SelectedDepartament = departament;
                  }));
            }
        }

        private RelayCommand removeDepartament;
        public RelayCommand RemoveDepartament
        {
            get
            {
                return removeDepartament ??
                  (removeDepartament = new RelayCommand(obj =>
                  {
                      Departament departament = obj as Departament;
                      if (departament != null)
                      {
                          DateBase.Departaments.Remove(departament);
                      }
                  },
                 (obj) => SelectedDepartament != null));
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
