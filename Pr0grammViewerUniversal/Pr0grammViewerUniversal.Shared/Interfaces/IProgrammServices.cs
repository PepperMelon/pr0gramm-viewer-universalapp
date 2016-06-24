using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.Interfaces
{
    using System.Threading.Tasks;
    using Model;

    public interface IProgrammService
    {
        Task<IEnumerable<Post>> LoadPosts(Uri postUrl);

        Task<PostInfo> LoadPostInfo(Post post);
    }
}
