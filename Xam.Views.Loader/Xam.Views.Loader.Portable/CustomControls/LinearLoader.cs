﻿using System;
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
        public static readonly BindableProperty SelectColorProperty =
            BindableProperty.Create(nameof(SelectedColor), typeof(Color),
                typeof(LinearLoader),defaultValue: Color.Green, propertyChanged: ColorChanged);
        public static readonly BindableProperty LoadingDirectionProperty =
            BindableProperty.Create(nameof(SelectDirection), typeof(FlowLoadingDirection),
                typeof(LinearLoader), defaultValue: FlowLoadingDirection.right, propertyChanged: DirectionChanged);



        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(nameof(IsLoading), typeof(bool), typeof(LinearLoader), defaultValue: false, propertyChanged: IsLoadingChanged);

        public static readonly BindableProperty Duration =
                    BindableProperty.Create(nameof(LoadingTime), typeof(SpeedDuration), typeof(LinearLoader), defaultValue: SpeedDuration.fast);


        public LinearLoader()
        {
            this.HeightRequest = 5;
            this.VerticalOptions = LayoutOptions.Center;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.WidthRequest = 400;
            this.AnchorX = 1;
            this.AnchorY = 0;
            this.IsVisible = false;
            var brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop() { Color = Color.Green, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.Green, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.Green, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = SelectedColor, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
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
        public Color SelectedColor
        {
            get => (Color)GetValue(SelectColorProperty);
            set => SetValue(SelectColorProperty, value);
        }

        public SpeedDuration LoadingTime
        {
            get => (SpeedDuration)GetValue(Duration);
            set => SetValue(Duration, value);
        }
        public FlowLoadingDirection SelectDirection
        {
            get => (FlowLoadingDirection)GetValue(LoadingDirectionProperty);
            set => SetValue(LoadingDirectionProperty, value);
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
        private static async void DirectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var direction = (FlowLoadingDirection)newValue;
            //var linearLoader = ((LinearLoader)bindable);
            //await linearLoader.RunAnimation(direction);
        }
        private static void ColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue!=null)
            {
                ((LinearLoader)bindable).GetColor(newValue);
            }
            else
            {
                var color = new object();
                color = Color.Green;
                ((LinearLoader)bindable).GetColor(color);
            }

        }
        private static async void IsLoadingChanged(BindableObject bindable, object oldValue, object newValue)
        {

            if ((bool)newValue)
            {
                await ((LinearLoader)bindable).RunAnimation(null);
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

      
        private void GetColor(object obj)
        {
            var color = (Color)obj;
            var brush = new LinearGradientBrush();
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = color, Offset = 0.4F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            brush.GradientStops.Add(new GradientStop() { Color = Color.White, Offset = 0.3F });
            this.Background = brush;
        }

        private async Task RunAnimation(FlowLoadingDirection? direction)
        {
            this.IsVisible = true;
            this.Scale = 5;
            Action<double> forward = a => this.AnchorX = a;
            //Action<double> backward = a => this.AnchorY = a;

            if (direction == FlowLoadingDirection.right)
            {
                while (IsLoading)
                {
                    this.Animate(name: "forward", callback: forward, start: 1, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);
                    await Task.Delay((int)LoadingTime);
                    this.Animate(name: "forward", callback: forward, start: 1, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);

                    //this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                    await Task.Delay((int)LoadingTime);
                }
            }
            else if (direction == FlowLoadingDirection.left)
            {
                while (IsLoading)
                {
                    this.Animate(name: "forward", callback: forward, start: 0, end: 1, length: (uint)LoadingTime, easing: Easing.SinIn);
                    await Task.Delay((int)LoadingTime);
                    this.Animate(name: "forward", callback: forward, start: 1, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);

                    //this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                    await Task.Delay((int)LoadingTime);
                }
            }
            else
            {
                while (IsLoading)
                {
                    this.Animate(name: "forward", callback: forward, start: 1, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);
                    await Task.Delay((int)LoadingTime);
                    this.Animate(name: "forward", callback: forward, start: 1, end: 0, length: (uint)LoadingTime, easing: Easing.SinIn);

                    //this.Animate(name: "Backward", callback: backward, start: 1, end: 0, length: 3000, easing: Easing.SinOut);
                    await Task.Delay((int)LoadingTime);
                }
            }


        }
    }
    public enum SpeedDuration
    {
        slow = 7000,
        medium = 5000,
        fast = 3000
    }

    public enum FlowLoadingDirection
    {
        right,
        left,
        spreadFromCentre
    }
}
