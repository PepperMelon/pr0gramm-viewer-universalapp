using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Converter
{
    using System.Reflection;
    using Windows.UI.Xaml.Data;
    using ExtendedClasses;
    using Interfaces;

    public class LocalizeEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var enumValue = value as Enum;

            var fieldInfo = enumValue.GetType().GetTypeInfo().GetDeclaredField(enumValue.ToString());

            var attributes = (LocalizedDescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(LocalizedDescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return enumValue.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
