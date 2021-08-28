using System;
using System.ComponentModel;
using Xam.Views.Loader.Portable.Enums;
using Xamarin.Forms;

namespace Xam.Views.Loader
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private SpeedDuration _spped;
        public SpeedDuration SelectedSpeed
        {
            get => _spped;
            set
            {
                _spped = value;
                OnPropertyChanged();
            }
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
