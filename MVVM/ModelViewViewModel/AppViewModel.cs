using ModelViewViewModel.Commands;
using ModelViewViewModel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewViewModel
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged(nameof(SelectedPhone));
            }
        }

        private RelayCommand addComm;
        public RelayCommand AddComm
        {
            get
            {
                return addComm ?? (addComm = new RelayCommand(obj =>
                {
                    Phone phone = new Phone();
                    Phones.Insert(0, phone);
                    SelectedPhone = phone;
                }
                ));
            }
        }

        private RelayCommand removeComm;
        public RelayCommand RemoveComm
        {
            get
            {
                return removeComm ?? (removeComm = new RelayCommand(obj =>
                {
                    Phone phone = obj as Phone;
                    if (phone != null)
                    {
                        Phones.Remove(phone);
                    }
                },
                (obj) => Phones.Count > 0
                ));
            }
        }

        public AppViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }




    }
}
