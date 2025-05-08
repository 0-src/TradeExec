using System.Windows;

namespace TradeExec.Styles.Behaviors
{
    public static class PlaceholderBehavior
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder", typeof(string), typeof(PlaceholderBehavior),
                new PropertyMetadata(string.Empty));

        public static string GetPlaceholder(DependencyObject obj) =>
            (string)obj.GetValue(PlaceholderProperty);

        public static void SetPlaceholder(DependencyObject obj, string value) =>
            obj.SetValue(PlaceholderProperty, value);
    }
}
