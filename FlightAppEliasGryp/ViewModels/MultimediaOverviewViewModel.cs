using FlightAppEliasGryp.ViewModels.Base;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAppEliasGryp.ViewModels
{
    public class MultimediaOverviewViewModel : ViewModelBase
    {
        public List<MultimediaViewModel> ViewModels { get; set; }
        public string Category { get; set; }

        public MultimediaOverviewViewModel() { }
    }
}
