using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Interfaces
{
    using System.Threading.Tasks;

    public interface IHttpRequest
    {
        Task<string> GetHttpRequestAsync(Uri uri);
    }
}
