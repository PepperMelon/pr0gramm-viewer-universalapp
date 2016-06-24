using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Interfaces
{
    using Enums;

    public interface ISettings
    {
        bool IsSfwChecked { get; set; }

        bool IsNsfwChecked { get; set; }

        bool IsNsflChecked { get; set; }

        bool IsLoadPicturesChecked { get; set; }

        bool IsLoadGifsChecked { get; set; }

        bool IsLoadWebmsChecked { get; set; }

        bool IsUsePointsChecked { get; set; }

        int Points { get; set; }

        Language Language { get; set; }

        Theme Theme { get; set; }

        PostView PostView { get; set; }
    }
}
