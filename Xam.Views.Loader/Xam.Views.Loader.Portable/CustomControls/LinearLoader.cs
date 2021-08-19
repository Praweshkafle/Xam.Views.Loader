using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Views.Loader.Portable.CustomControls
{
    public class LinearLoader : BoxView, INotifyPropertyChanged
    {
        public static readonly BindableProperty SpeedProperty = BindableProperty.Create(nameof(Speed), typeof(float), typeof(LinearLoader), defaultValue: 0F, propertyChanged: SpeedChanged);

        public static readonly BindableProperty DefaultColorProperty = BindableProperty.Create(nameof(DefaultColor), typeof(Color), typeof(LinearLoader), defaultValue: Color.Transparent, propertyChanged: DefaultColorChanged);

        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(LinearLoader), defaultValue: false, propertyChanged: IsLoadingChanged);


        public LinearLoader()
        {
            this.HeightRequest = 5;
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.WidthRequest = 400;
            this.AnchorX = 1;
            this.AnchorY = 0;
            var brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.Green, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.Green, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });

            this.Background = brush;
        }

        public float Speed
        {
            get => (float)GetValue(SpeedProperty);
            set => SetValue(SpeedProperty, value);
        }

        public Color DefaultColor
        {
            get => (Color)GetValue(DefaultColorProperty);
            set => SetValue(DefaultColorProperty, value);
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

        private static void SpeedChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private static void DefaultColorChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }

        private static async void IsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
                await ((LinearLoader)bindable).RunAnimation();
            else
                ((LinearLoader)bindable).StopAnimation();
        }

        private void StopAnimation()
        {
            this.BackgroundColor = DefaultColor;
        }

        private async Task RunAnimation()
        {
            this.Scale = 5;
            Action<double> forward = a => this.AnchorX = a;
            Action<double> backward = a => this.AnchorY = a;
            while (IsLoading)
            {
                this.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 3000, easing: Easing.SinIn);
                await Task.Delay(2000);

                this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                await Task.Delay(2000);
            }
        }
    }
}
