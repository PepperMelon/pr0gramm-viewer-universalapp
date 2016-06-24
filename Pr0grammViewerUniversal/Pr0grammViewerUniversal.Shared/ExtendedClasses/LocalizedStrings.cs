using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ExtendedClasses
{
    using Windows.ApplicationModel.Resources;

    public class LocalizedStrings
    {
        private static ResourceLoader localizedResources = new ResourceLoader();

        public ResourceLoader LocalizedResources { get { return localizedResources; } }

        private string GetVal(string key)
        {
            return LocalizedResources.GetString(key);
        }

        public string this[string key]
        {
            get
            {
                return GetVal(key);
            }
        }
    }
}
