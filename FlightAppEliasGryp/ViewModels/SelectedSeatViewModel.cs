using FlightAppEliasGryp.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class SelectedSeatViewModel : ViewModelBase
    {
        public Seat Seat { get; set; }
        public bool IsSelected { get; set; }
    }
}
