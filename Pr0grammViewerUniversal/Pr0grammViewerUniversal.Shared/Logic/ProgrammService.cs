using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Logic
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Windows.Web.Http;
    using Constants;
    using JsonAdapter;
    using Model;
    using Newtonsoft.Json;
    using Pr0grammViewerUniversal.Interfaces;

    public class ProgrammService : IProgrammService
    {
        private readonly IHttpRequest httpRequest;
        private readonly ICommonLogic commonLogic;

        public ProgrammService(IHttpRequest httpRequest, ICommonLogic commonLogic)
        {
            this.httpRequest = httpRequest;
            this.commonLogic = commonLogic;
        }

        public async Task<IEnumerable<Post>> LoadPosts(Uri postUrl)
        {
            var resultString = await httpRequest.GetHttpRequestAsync(postUrl);
            var postInfo = JsonConvert.DeserializeObject<JsonPostInfo>(resultString);
            foreach (var post in postInfo.Items)
            {
                post.Points = post.Up - post.Down;
                post.Thumb = string.Format("{0}{1}", ApiCalls.ThumbUrl, post.Thumb);
                post.Image = string.Format("{0}{1}", ApiCalls.ImageUrl, post.Image);
                post.ReadableCreatedTime = commonLogic.ConvertJsonDateToDateTime(post.Created).AddHours(2);
            }

            return postInfo.Items;
        }

        public async Task<PostInfo> LoadPostInfo(Post post)
        {
            post.CancellationTokenSource = new CancellationTokenSource();

            var postInfoUrl = string.Format("{0}{1}", ApiCalls.PostInfoUrl, post.Id);
            var jsonUrl = string.Format("{0}", postInfoUrl);

            var resultString = await httpRequest.GetHttpRequestAsync(new Uri(jsonUrl));

            var postInfo = PostInfo.FromJson(resultString);
            foreach (var comment in postInfo.Comments)
            {
                comment.ReadableCreatedTime = commonLogic.ConvertJsonDateToDateTime(comment.Created).AddHours(2);
                comment.Points = comment.Up - comment.Down;
            }

            RecursiveSetCommentsLevel(postInfo.Comments);

            return postInfo;
        }

        private static void RecursiveSetCommentsLevel(List<Comment> comments)
        {
            foreach (var itemcomment in comments.Where(x => x.Parent == 0).OrderBy(x => x.Up - x.Down).ToList())
            {
                comments.Remove(itemcomment);
                comments.Insert(0, itemcomment);

                LoadSubComments(comments, itemcomment, 1);
            }
        }

        private static void LoadSubComments(List<Comment> comments, Comment itemcomment, int level)
        {
            var itemLevel = level;
            var orderedCommentsList = comments.Where(x => x.Parent == itemcomment.Id).OrderBy(x => x.Up - x.Down).ToList();
            foreach (var subComment in orderedCommentsList)
            {
                comments.Remove(subComment);
                var indexOfParent = comments.IndexOf(comments.FirstOrDefault(x => x.Id == subComment.Parent)) + 1;

                comments.Insert(indexOfParent, subComment);
                subComment.Level = itemLevel;

                var newItemLevel = itemLevel + 1;
                LoadSubComments(comments, subComment, newItemLevel);
            }
        }
    }
}
