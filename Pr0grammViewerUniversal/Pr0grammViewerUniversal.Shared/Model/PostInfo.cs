namespace Pr0grammViewerUniversal.Model
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Newtonsoft.Json;

    public class PostInfo
    {
        public string Cache;
        public int Qc;
        public int Rt;
        public int Ts;
        public List<TagInfo> Tags;
        public List<Comment> Comments;

        public static PostInfo FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PostInfo>(json);
        }
    }
}