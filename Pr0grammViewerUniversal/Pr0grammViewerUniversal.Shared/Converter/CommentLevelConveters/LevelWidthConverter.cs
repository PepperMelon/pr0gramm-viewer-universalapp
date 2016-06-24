using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Converter.CommentLevelConveters
{
    using Windows.UI.Xaml.Data;
    using Model;

    public class LevelWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var item = value as Comment;
                var level = item.Level;
                
                if (level == 0 || level == null)
                {
                    return 380;
                }

                var width = 380 - (double)level * 10;

                return width;
            }
            catch (Exception)
            {
                return 380;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
