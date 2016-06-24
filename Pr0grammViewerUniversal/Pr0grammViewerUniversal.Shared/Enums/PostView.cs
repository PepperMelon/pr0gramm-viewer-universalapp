using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Enums
{
    using ExtendedClasses;

    public enum PostView
    {
        [LocalizedDescription("List")]
        List,

        [LocalizedDescription("PictruesWithBorder")]
        PicturesWithBorder,

        [LocalizedDescription("PicturesWithoutBorder")]
        PicturesWithoutBorder,

        [LocalizedDescription("Efficient")]
        Efficient,

        [LocalizedDescription("BigView")]
        BigView
    }
}
