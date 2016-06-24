using System;

namespace Pr0grammViewerUniversal.Converter
{
    using System.Resources;
    using System.Text;
    using Windows.UI;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;
    using ExtendedClasses;

    public class DatetimeAgoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var resouceManager = new LocalizedStrings();
            var date = value is DateTime ? (DateTime)value : new DateTime();
            var dateDiff = DateTime.Now - date;

            var sb = new StringBuilder();
            if (dateDiff.Days > 0)
            {
                sb.AppendFormat("{0}d ", dateDiff.Days);
            }
            if (dateDiff.Hours > 0 && dateDiff.Days < 8)
            {
                sb.AppendFormat("{0}h ", dateDiff.Hours);
            }
            if (dateDiff.Minutes > 0 && dateDiff.Days < 1)
            {
                sb.AppendFormat("{0}m ", dateDiff.Minutes);
            }

            if (dateDiff.TotalMinutes < 1)
            {
                sb.AppendFormat("{0}  ", resouceManager.LocalizedResources.GetString("Now"));
            }
            else
            {
                sb = new StringBuilder(string.Format(resouceManager.LocalizedResources.GetString("Ago"), sb));
            }

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
