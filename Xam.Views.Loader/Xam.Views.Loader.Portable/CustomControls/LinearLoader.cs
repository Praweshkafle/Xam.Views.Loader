using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xam.Views.Loader.Portable.Enums;
using Xamarin.Forms;

namespace Xam.Views.Loader.Portable.CustomControls
{
    public class LinearLoader : BoxView, INotifyPropertyChanged
    {
        public static readonly BindableProperty DefaultColorProperty = BindableProperty.Create(nameof(DefaultColor), typeof(Color), typeof(LinearLoader), defaultValue: Color.Transparent, propertyChanged: DefaultColorChanged);
       
        public static readonly BindableProperty SelectColorProperty =
            BindableProperty.Create(nameof(SelectColor), typeof(Color),
                typeof(LinearLoader),defaultValue: Color.Green, propertyChanged: ColorChanged);

        public static readonly BindableProperty SelectAnotherColorProperty =
           BindableProperty.Create(nameof(SelectSecondaryColor), typeof(Color),
               typeof(LinearLoader), defaultValue: Color.White, propertyChanged: SecondaryColorChanged);

      

        public static readonly BindableProperty LoadingDirectionProperty =
            BindableProperty.Create(nameof(Direction), typeof(FlowLoadingDirection),
                typeof(LinearLoader), defaultValue: FlowLoadingDirection.right, propertyChanged: DirectionChanged);



        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(LinearLoader), defaultValue: false, propertyChanged: IsLoadingChanged);

        public static readonly BindableProperty DurationProperty =
                    BindableProperty.Create(nameof(Duration), typeof(SpeedDuration), typeof(LinearLoader), defaultValue: SpeedDuration.fast);


        public LinearLoader()
        {
            this.HeightRequest = 5;
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.AnchorX = 1;
            this.AnchorY = 0;
            this.IsVisible = false;
            GetColor(SelectColor,SelectSecondaryColor);

        }

        public Color DefaultColor
        {
            get => (Color)GetValue(DefaultColorProperty);
            set => SetValue(DefaultColorProperty, value);
        }
        public Color SelectColor
        {
            get => (Color)GetValue(SelectColorProperty);
            set => SetValue(SelectColorProperty, value);
        }
        public Color SelectSecondaryColor
        {
            get => (Color)GetValue(SelectAnotherColorProperty);
            set => SetValue(SelectAnotherColorProperty, value);
        }

        public SpeedDuration Duration
        {
            get => (SpeedDuration)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }
        public FlowLoadingDirection Direction
        {
            get => (FlowLoadingDirection)GetValue(LoadingDirectionProperty);
            set => SetValue(LoadingDirectionProperty, value);
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }

      
        private static void DefaultColorChanged(BindableObject bindable, object oldValue, object newValue)
        {

        }
        private static async void DirectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var linearLoader = ((LinearLoader)bindable);
            await linearLoader.RunAnimation();
        }
        private static void ColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var linear = ((LinearLoader)bindable);
            linear.GetColor(newValue,linear.SelectSecondaryColor);
        }

        private static void SecondaryColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var linear = ((LinearLoader)bindable);
            linear.GetColor(linear.SelectColor,newValue);
        }
        private static async void IsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {

            if ((bool)newValue)
            {
                await ((LinearLoader)bindable).RunAnimation();
            }
            else
            {
                ((LinearLoader)bindable).StopAnimation();
            }
        }
        private void StopAnimation()
        {
            this.IsVisible = false;
            this.BackgroundColor = DefaultColor;
        }
        private void GetColor(object primary,object secondary)
        {
            var primaryColor = (Color)primary;
            var secondaryColor = (Color)secondary;

            var brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = primaryColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = secondaryColor, Offset = 0.3F });
            this.Background = brush;
        }

        private async Task RunAnimation()
        {
            this.IsVisible = IsLoading;
            this.Scale = 5;
            Action<double> forward = a => this.AnchorX = a;
            Action<double> backward = a => this.AnchorY = a;

            int start = 0;
            int end = 0;

            if (Direction == FlowLoadingDirection.right)
            {
                start = 1;
                end = 0;
            }
            else if (Direction == FlowLoadingDirection.left)
            {
                start = 0;
                end = 1;
            }
            else if(Direction == FlowLoadingDirection.spreadFromCentre)
            {
                //while (IsLoading)
                //{
                //    this.Animate(name: "forward", callback: forward, start: 0, end: 0.5, length: (uint)LoadingTime, easing: Easing.SinIn);
                //   // this.Animate(name: "backward", callback: backward, start: 0.5, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);
                //    //this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                //    await Task.Delay((int)LoadingTime);
                //}
            }
            while (IsLoading)
            {
                this.Animate(name: "forward", callback: forward, start: start, end: end, length: (uint)Duration, easing: Easing.SinIn);
                await Task.Delay((int)Duration);
                this.Animate(name: "forward", callback: forward, start: start, end: end, length: (uint)Duration, easing: Easing.SinIn);

                //this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                await Task.Delay((int)Duration);
            }

        }
    }
}
