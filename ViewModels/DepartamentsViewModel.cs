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
            Data.Data.DataBase.Departaments = new ObservableCollection<Departament>
            {
                new Departament () {Name = "Developers", Cabinets = new ObservableCollection<int>() {13, 2 } },
                new Departament () {Name = "Analitics", Cabinets = new ObservableCollection<int>() {10, 3, 3 } },
            };
        }

        public ObservableCollection<Departament> Departaments
        {
            get
            {
                return Data.Data.DataBase.Departaments;
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
                      Departament departament = new Departament() { Name = "Новый отдел", Cabinets = new ObservableCollection<int>()};
                      Data.Data.DataBase.Departaments.Add(departament);
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
                          Data.Data.DataBase.Departaments.Remove(departament);
                      }
                  },
                 (obj) => SelectedDepartament != null));
            }
        }


        private RelayCommand addCabinet;
        public RelayCommand AddCabinet
        {
            get
            {
                int cabinet = 0;
                return addCabinet ??
                  (addCabinet = new RelayCommand(obj =>
                  {
                      SelectedDepartament.Cabinets.Add(cabinet);
                      OnPropertyChanged("Departaments");
                  },
                  (obj) => int.TryParse(obj.ToString(), out cabinet) && SelectedDepartament != null));
            }
        }

        private RelayCommand removeCabinet;
        public RelayCommand RemoveCabinet
        {
            get
            {
                return removeCabinet ??
                  (removeCabinet = new RelayCommand(obj =>
                  {
                      SelectedDepartament.Cabinets.Remove(int.Parse(obj.ToString()));
                  },
                 (obj) => obj != null && SelectedDepartament != null));
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
