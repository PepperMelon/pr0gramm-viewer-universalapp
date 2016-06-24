using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Enums
{
    using ExtendedClasses;

    public enum Language
    {
        [LocalizedDescription("English")]
        [CultureDescription("en-US")]
        English,

        [LocalizedDescription("German")]
        [CultureDescription("de-DE")]
        German
    }
}
