using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.JsonAdapter
{
    using Model;
    using Newtonsoft.Json;

    public class JsonPostInfo
    {
        [JsonProperty]
        public List<Post> Items { get; set; }
    }
}
