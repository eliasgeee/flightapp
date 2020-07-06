using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.Models
{
    class Flight
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private long flightNumber;
        public long FlightNumber
        {
            get { return flightNumber; }

            set
            {
                this.flightNumber = value;
                RaisePropertyChanged();
            }
        }
        private DateTime eat;
        public DateTime Eat
        {
            get { return eat; }
            set
            {
                this.eat = value;
                RaisePropertyChanged();
            }
        }


    }
}
