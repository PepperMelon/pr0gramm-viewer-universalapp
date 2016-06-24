using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Constants
{
    public static class ApiCalls
    {
        public const string TopShareUrl = "http://pr0gramm.com/top/{0}";
        public const string NewShareUrl = "http://pr0gramm.com/new/{0}";

        public const string ImageUrl = "http://img.pr0gramm.com/";
        public const string ThumbUrl = "http://thumb.pr0gramm.com/";
        public const string HotPostsUrl = "http://pr0gramm.com/api/items/get?flags={0}";
        public const string PostInfoUrl = "http://pr0gramm.com/api/items/info?itemId=";
        public const string AuthUrl = "http://pr0gramm.com/api/user/login";
        public const string CommentUrl = "http://pr0gramm.com/api/comments/post";
        public const string CommentVoteUrl = "http://pr0gramm.com/api/comments/vote";
        public const string PostVoteUrl = "http://pr0gramm.com/api/items/vote";
        public const string AddTagsUrl = "http://pr0gramm.com/api/tags/add";
        public const string VoteTagUrl = "http://pr0gramm.com/api/tags/vote";
        public const string UploadPicFromUrlUrl = "http://pr0gramm.com/api/items/post";
        public const string SyncVotesUrl = "http://pr0gramm.com/api/user/sync?lastId={0}";
        public const string UserUrl = "http://pr0gramm.com/api/user/info?name={0}";
        public const string SelfUserLikes = "http://pr0gramm.com/api/items/get?likes={0}&flags={1}&self=true";
        public const string SelfUserUploads = "http://pr0gramm.com/api/items/get?user={0}&flags={1}&self=true";
        public const string CommonPostInfoUrl = "http://pr0gramm.com/api/items/get?id={0}&flags=7";
    }
}
