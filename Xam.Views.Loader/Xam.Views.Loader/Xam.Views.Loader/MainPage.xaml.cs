using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Views.Loader.Portable.Enums;
using Xamarin.Forms;

namespace Xam.Views.Loader
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
            // Task.Run(AnimationColor);
        }

        public List<string> BreeSdNames
        {
            get
            {
                return new List<string> { "Border Collie", "Labrador Retriever", "Pit Bull" };
            }
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

        //private async Task AnimationColor()
        //{
        //    Action<double> forward = a => boxBackground.AnchorX = a;
        //    Action<double> backward = a => boxBackground.AnchorY = a;
        //    while (true)
        //    {
        //        boxBackground.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 6000, easing: Easing.SinIn);
        //        await Task.Delay(5000);

        //        //boxBackground.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 5000, easing: Easing.SinIn);
        //        //await Task.Delay(8000);
        //        boxBackground.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 6000, easing: Easing.SinOut);
        //        await Task.Delay(2000);
        //    }
        //}
    }
}
