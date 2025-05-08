using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media;

namespace TradeExec.Styles.Behaviors
{
    public static class HasErrorBehavior
    {
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.RegisterAttached(
                "HasError", typeof(bool), typeof(HasErrorBehavior),
                new PropertyMetadata(false, OnHasErrorChanged));

        public static bool GetHasError(DependencyObject obj) =>
            (bool)obj.GetValue(HasErrorProperty);

        public static void SetHasError(DependencyObject obj, bool value) =>
            obj.SetValue(HasErrorProperty, value);
        private static void OnHasErrorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox && e.NewValue is bool newVal && newVal)
            {
                // Ensure the TextBox has a RotateTransform
                if (textBox.RenderTransform is not RotateTransform)
                {
                    textBox.RenderTransform = new RotateTransform(0);
                    textBox.RenderTransformOrigin = new Point(0.5, 0.5);
                }

                // Restart storyboard
                if (Application.Current.TryFindResource("ShakeAnimation") is Storyboard baseStoryboard)
                {
                    var storyboard = baseStoryboard.Clone(); // optional due to x:Shared=False
                    Storyboard.SetTarget(storyboard, textBox);
                    storyboard.Begin();
                }

                // Reset HasError so it's retriggerable
                Task.Delay(350).ContinueWith(_ =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SetHasError(textBox, false);
                    });
                });
            }
        }
    }
}