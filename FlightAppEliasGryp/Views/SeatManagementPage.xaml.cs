using FlightAppEliasGryp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                grid.Children.Add(text);
                Grid.SetRow(text, i + 1);
                Grid.SetColumn(text, 0);
            }

            for (int i=0; i < ViewModel.Chairs.Count; i++)
            {
                TextBlock text = new TextBlock();
                text.Text = ViewModel.Chairs.ElementAt(i).ToString();
                grid.Children.Add(text);
                Grid.SetRow(text, 0);
                Grid.SetColumn(text, i + 1);
            }

            for (int i=0; i < ViewModel.Seats.Count; i++)
            {
                TextBlock text = new TextBlock();
                if(ViewModel.Seats.ElementAt(i).Passenger != null)
                text.Text = ViewModel.Seats.ElementAt(i).Passenger.GetFullName();
                grid.Children.Add(text);
                var ro = ViewModel.Seats.ElementAt(i).Row;
                var indRo = ViewModel.Rows.IndexOf(ro);
                Grid.SetRow(text, indRo + 1);
                var c = ViewModel.Seats.ElementAt(i).Chair;
                var ind = ViewModel.Chairs.IndexOf(c);
                Grid.SetColumn(text, ind + 1);
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
                chair.Width = new GridLength(80.0);
                grid.ColumnDefinitions.Add(chair);
            }

            RowDefinition rowsRow = new RowDefinition();
            rowsRow.Height = GridLength.Auto;
            grid.RowDefinitions.Add(rowsRow);

            for (int i=0; i < ViewModel.Rows.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(80.0);
                grid.RowDefinitions.Add(row);
            }
        }

        private void LoadData()
        {
            ViewModel.LoadDataAsync();   
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitGrid();
            InitData();
        }
    }
}
