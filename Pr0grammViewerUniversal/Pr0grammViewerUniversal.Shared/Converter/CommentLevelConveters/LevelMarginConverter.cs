using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Converter.CommentLevelConveters
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    using Model;

    public class LevelMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var item = value as Comment;
                var level = item.Level;

                if (level == 0 || level == null)
                {
                    return new Thickness(0, 10, 5, 5);
                }

                var left = (double)(level * 10);
                return new Thickness(left, 10, 0, 5);
            }
            catch (Exception)
            {
                return new Thickness(0, 10, 5, 5);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
