using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Logic
{
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Interfaces;

    public class HttpRequest : IHttpRequest
    {
        public async Task<string> GetHttpRequestAsync(Uri uri)
        {
            var httpClient = new HttpClient();
            try
            {
                var result = await httpClient.GetStringAsync(uri);
                return result;
            }
            catch
            {

            }
            
            return null;
        }
    }
}
