using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewViewModel.Models
{
    public class Phone : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        private string company;
        private int price;

        public string Title
        {
            get { return title; }
            set
            {
                if(!Equals(title, value))
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Company
        {
            get { return title; }
            set
            {
                if (!Equals(company, value))
                {
                    company = value;
                    OnPropertyChanged(nameof(Company));
                }
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (!Equals(price, value))
                {
                    price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
