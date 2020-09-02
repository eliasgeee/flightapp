using FlightAppEliasGryp.Models;
using FlightAppEliasGryp.Services;
using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlightAppEliasGryp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SeatManagementPage : Page
    {
        private Grid grid;
        private SeatManagementViewModel ViewModel { get { return ViewModelLocator.Current.SeatManagementViewModel; } }
        public NavigationServiceEx NavigationService { get { return ViewModelLocator.Current.NavigationService; } }

        public SeatManagementPage()
        {
            this.InitializeComponent();
            LoadData();
        }

        private void InitData()
        {
            for (int i=0; i < ViewModel.Rows.Count; i++)
            {
                TextBlock text = new TextBlock();
                text.Text = ViewModel.Rows.ElementAt(i).ToString();
                text.VerticalAlignment = VerticalAlignment.Center;
                grid.Children.Add(text);
                Grid.SetRow(text, i + 1);
                Grid.SetColumn(text, 0);
            }

            for (int i=0; i < ViewModel.Chairs.Count; i++)
            {
                TextBlock text = new TextBlock();
                text.Text = ViewModel.Chairs.ElementAt(i).ToString();
                text.HorizontalAlignment = HorizontalAlignment.Center;
                grid.Children.Add(text);
                Grid.SetRow(text, 0);
                Grid.SetColumn(text, i + 1);
            }

            for (int i=0; i < ViewModel.Seats.Count; i++)
            {
                PassengerItem passengerItem = new PassengerItem() {
                    Seat = ViewModel.Seats.ElementAt(i)
                };
                passengerItem.PassengerBlock.DragStarting += Passenger_DragStarting;
                passengerItem.PassengerBlock.Drop += Passenger_Drop;
                passengerItem.PassengerBlock.DragEnter += Passenger_Text_DragEnter;
                grid.Children.Add(passengerItem);
                var ro = ViewModel.Seats.ElementAt(i).Row;
                var indRo = ViewModel.Rows.IndexOf(ro);
                
                Grid.SetRow(passengerItem, indRo + 1);
                var c = ViewModel.Seats.ElementAt(i).Chair;
                var ind = ViewModel.Chairs.IndexOf(c);
                Grid.SetColumn(passengerItem, ind + 1);
            }
        }

            private void InitGrid()
        {
            grid = Container;

            ColumnDefinition chairsColumn = new ColumnDefinition();
            chairsColumn.Width = GridLength.Auto;
            grid.ColumnDefinitions.Add(chairsColumn);

            for (int i=0; i < ViewModel.Chairs.Count; i++)
            {
                ColumnDefinition chair = new ColumnDefinition();
                chair.Width = new GridLength(8.0, GridUnitType.Star);
                grid.ColumnDefinitions.Add(chair);
            }

            RowDefinition rowsRow = new RowDefinition();
            rowsRow.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowsRow);

            for (int i=0; i < ViewModel.Rows.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(8.0, GridUnitType.Star);
                grid.RowDefinitions.Add(row);
            }
        }

        private async void LoadData()
        {
            await ViewModel.LoadDataAsync();
            InitGrid();
            InitData();
        }

        private void Passenger_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            var passContainer = sender as StackPanel;
            var passenger = passContainer.Tag as Passenger;
            var parentGrid = passContainer.Parent as Grid;
            var parent = parentGrid.Parent as PassengerItem;
            if(parent.Seat.Passenger != null)
            args.Data.SetText(parent.Seat.Passenger.Id.ToString());
            args.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private async void Passenger_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var passenger = await e.DataView.GetTextAsync();
                var passContainer = sender as StackPanel;
                var parentGrid = passContainer.Parent as Grid;
                var item = parentGrid.Parent as PassengerItem;

                int i = 0;
                bool foundSeat = false;
                Passenger oldPassenger;
                Seat oldSeat = null;
                do
                {
                    if (ViewModel.Seats.ElementAt(i).Passenger != null)
                    {
                        if (ViewModel.Seats.ElementAt(i).Passenger.Id == passenger)
                        {
                            oldPassenger = item.Seat.Passenger;
                            item.Seat.Passenger = ViewModel.Seats.ElementAt(i).Passenger;
                            ViewModel.Seats.ElementAt(i).Passenger = oldPassenger;
                            oldSeat = ViewModel.Seats.ElementAt(i);
                            foundSeat = true;
                        }
                    }
                    i++;
                } while (i < ViewModel.Seats.Count & foundSeat == false);

                if (oldSeat != item.Seat)
                    ViewModel.SwitchSeats(oldSeat, item.Seat);
            }
        }

        private void Passenger_Text_DragEnter(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Move;
        }
    }
}
