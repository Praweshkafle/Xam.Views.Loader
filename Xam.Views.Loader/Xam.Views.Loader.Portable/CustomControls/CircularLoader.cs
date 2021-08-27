using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xam.Views.Loader.Portable.Enums;
using Xamarin.Forms;

namespace Xam.Views.Loader.Portable.CustomControls
{
    public class CircularLoader: ContentView,INotifyPropertyChanged
    {

        public static readonly BindableProperty LoadingTypeProperty =
            BindableProperty.Create(nameof(LoadingType), typeof(LoadingTypes),
                typeof(LinearLoader), defaultValue: LoadingTypes.circle, propertyChanged: DirectionChanged);
        
        public static readonly BindableProperty IsLoadingProperty =
           BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(LinearLoader), 
               defaultValue: false, propertyChanged: IsLoadingChanged);

        public LoadingTypes LoadingType
        {
            get => (LoadingTypes)GetValue(LoadingTypeProperty);
            set => SetValue(LoadingTypeProperty, value);
        }
        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }
        private static void DirectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //
        }
        private static async void IsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
            {
               await ((CircularLoader)bindable).AnimatingView();
            }
            else
                ((CircularLoader)bindable).StopAnimation();

        }

        public CircularLoader()
        {
           //
        }

        private async Task AnimatingView()
        {
            Action<double> degree = a => this.Rotation = a;
            if (LoadingType==LoadingTypes.circle)
            {
                while (IsLoading)
                {
                    this.Animate(name: "circle", callback: degree, start: 0, end: 360, length: 1000, easing: Easing.Linear);
                    await Task.Delay(1000);
                    //rotation.Commit(this, "circleRotate", 16, 1000, Easing.SinIn, (a, b) => { this.RotationX = 0; }, () => true);
                }
            }
            else if (LoadingType == LoadingTypes.flip)
            {
                while (IsLoading)
                {
                    // this.Animate(name: "circle", callback: degree, start: 0, end: 360, length: 1000, easing: Easing.Linear);
                    await this.RotateYTo(-90, 300, Easing.SinIn);
                    this.RotationY = 90;
                    await this.RotateYTo(0, 300, Easing.SinIn);
                }
            }
        }

        void StopAnimation()
        {
            this.CancelAnimations();
        }
    }
}
