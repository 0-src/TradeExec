using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace TradeExec.Styles.Behaviors
{
    public class ActivePageMatchConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2) return false;
            if (values[0] is string activePage && values[1] is string tag)
                return activePage == tag;
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
