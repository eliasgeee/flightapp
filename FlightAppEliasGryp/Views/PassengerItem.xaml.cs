﻿using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FlightAppEliasGryp.Views
{
    public sealed partial class PassengerItem : UserControl
    {
        public PassengerItem()
        {
            this.InitializeComponent();
        }

        private Seat _seat;
        public Seat Seat { get { return _seat;  } set { _seat = value; Seat.RaisePropertyChanged(); } } 

        public StackPanel PassengerBlock {get { return PassengerNameContainer;  } }
    }
}
