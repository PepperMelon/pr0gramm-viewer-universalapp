using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Converter.CommentLevelConveters
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;
    using Model;

    public class LevelBorderVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var item = value as Comment;
                var level = item.Level;

                if (level == 0 || level == null)
                {
                    return 0;
                }

                return 1;
            }
            catch (Exception)
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
