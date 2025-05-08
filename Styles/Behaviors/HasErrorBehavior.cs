using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows;

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
                var baseStoryboard = Application.Current.TryFindResource("ShakeAnimation") as Storyboard;

                if (baseStoryboard != null)
                {
                    Storyboard clone = baseStoryboard.Clone();
                    Storyboard.SetTarget(clone, textBox);
                    clone.Begin();
                }

                // Reset HasError so the next trigger will work
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