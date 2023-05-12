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
using System.Windows;

namespace HRDepartamentMVVM.ViewModels
{
    partial class DepartamentsViewModel : INotifyPropertyChanged
    {
        
        public List<int> Cabinets
        {
            get 
            {
                if (SelectedDepartament != null)
                    return SelectedDepartament.Cabinets;
                else
                    return new List<int>();
            }
            set
            {
                this.SelectedDepartament.Cabinets = value;
                OnPropertyChanged("Cabinets");
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
                      Cabinets.Add(cabinet);
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
                      Cabinets.Remove(int.Parse(obj.ToString()));
                  },
                 (obj) => obj != null));
            }
        }
    }
}
