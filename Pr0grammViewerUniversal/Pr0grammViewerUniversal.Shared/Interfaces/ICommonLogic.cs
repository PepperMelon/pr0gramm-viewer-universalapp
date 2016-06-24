using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Interfaces
{
    public interface ICommonLogic
    {
        DateTime ConvertJsonDateToDateTime(double msSinceEpoch);

        void SetUiCulture(string cultureName);

        T GetAttribute<T, TK>(TK objectToGetAttribute);

        int GetFlagFilter(ISettings settings);
    }
}
