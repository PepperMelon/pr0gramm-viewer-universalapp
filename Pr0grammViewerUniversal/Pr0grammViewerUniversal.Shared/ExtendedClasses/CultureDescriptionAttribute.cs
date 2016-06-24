using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ExtendedClasses
{
    using Windows.ApplicationModel.Resources;

    [AttributeUsage(AttributeTargets.All)]
    public class CultureDescriptionAttribute : Attribute 
    {
        private readonly string cultureDescription;

        public CultureDescriptionAttribute(string cultureDescription)
        {
            this.cultureDescription = cultureDescription;
        }

        public string CultureDescription
        {
            get { return cultureDescription; }
        }
    }
}
