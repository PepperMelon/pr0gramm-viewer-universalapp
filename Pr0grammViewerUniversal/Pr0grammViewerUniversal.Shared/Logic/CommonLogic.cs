using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Logic
{
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using ExtendedClasses;
    using Interfaces;

    public class CommonLogic : ICommonLogic
    {
        public DateTime ConvertJsonDateToDateTime(double msSinceEpoch)
        {
            var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return date.AddMilliseconds(msSinceEpoch * 1000);
        }

        public void SetUiCulture(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture; 
        }

        public T GetAttribute<T, TK>(TK objectToGetAttribute)
        {
            var value = typeof (TK);
            var fieldInfo = value.GetTypeInfo().GetDeclaredField(objectToGetAttribute.ToString());

            var attributes = fieldInfo.GetCustomAttributes(typeof(T), false);

            if (attributes != null)
            {
                return ((IEnumerable<T>) attributes).First();
            }

            return default(T);
        }

        public int GetFlagFilter(ISettings settings)
        {
            var sfwLoaded = settings.IsSfwChecked;
            var nsfwLoaded = settings.IsNsfwChecked;
            var nsflLoaded = settings.IsNsflChecked;

            if (sfwLoaded && !nsfwLoaded && !nsflLoaded)
            {
                return 1;
            }
            else if (!sfwLoaded && nsfwLoaded && !nsflLoaded)
            {
                return 2;
            }
            else if (!sfwLoaded && !nsfwLoaded && nsflLoaded)
            {
                return 4;
            }
            else if (sfwLoaded && nsfwLoaded && !nsflLoaded)
            {
                return 3;
            }
            else if (sfwLoaded && !nsfwLoaded && nsflLoaded)
            {
                return 5;
            }
            else if (!sfwLoaded && nsfwLoaded && nsflLoaded)
            {
                return 6;
            }
            else if (sfwLoaded && nsfwLoaded && nsflLoaded)
            {
                return 7;
            }

            return 1;
        }
    }
}
