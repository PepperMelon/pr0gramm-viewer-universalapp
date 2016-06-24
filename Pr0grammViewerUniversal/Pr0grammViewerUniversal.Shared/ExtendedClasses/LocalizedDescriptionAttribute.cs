using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ExtendedClasses
{
    using Windows.ApplicationModel.Resources;

    [AttributeUsage(AttributeTargets.All)]
    public class LocalizedDescriptionAttribute : Attribute 
    {
        private readonly string resourceKey;
        private static readonly ResourceLoader localizedResources = new ResourceLoader();

        public ResourceLoader LocalizedResources { get { return localizedResources; } }

        public LocalizedDescriptionAttribute(string resourceKey)
        {
            this.resourceKey = resourceKey;
        }

        public string Description
        {
            get
            {
                var displayName = LocalizedResources.GetString(resourceKey);

                return string.IsNullOrEmpty(displayName)
                    ? string.Format("[[{0}]]", resourceKey)
                    : displayName;
            }
        }
    }
}
