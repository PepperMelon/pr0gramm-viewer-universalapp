using System;

namespace Pr0grammViewerUniversal.Converter
{
    using Windows.UI;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Media;

    public class MarkToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var mark = value is int ? (int)value : 0;
            if (mark == 1)
            {
                return new SolidColorBrush(Colors.Magenta);
            }
            else if (mark == 0)
            {
                return new SolidColorBrush(Colors.White);
            }
            else if (mark == 2)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (mark == 3)
            {
                return new SolidColorBrush(Colors.Orange);
            }
            else if (mark == 4)
            {
                return new SolidColorBrush(Colors.Gray);
            }
            else if (mark == 5)
            {
                return new SolidColorBrush(Colors.Blue);
            }
            else if (mark == 6)
            {
                return new SolidColorBrush(Color.FromArgb(255, 108, 67, 43));
            }
            else if (mark == 7)
            {
                return new SolidColorBrush(Color.FromArgb(255, 28, 185, 146));
            }
            else if (mark == 8)
            {
                return new SolidColorBrush(Color.FromArgb(150, 27, 185, 146));
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
