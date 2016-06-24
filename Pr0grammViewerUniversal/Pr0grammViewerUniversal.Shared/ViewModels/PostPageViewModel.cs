namespace Pr0grammViewerUniversal.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Windows.UI.Xaml.Navigation;
    using Interfaces;
    using Microsoft.Practices.Prism.Mvvm;
    using Model;

    public class PostPageViewModel : ViewModel
    {
        private readonly IProgrammService programmService;
        private ObservableCollection<Comment> comments;
        private Post post;
        private Post post1;
        private Post post2;
        private int postSelectedIndex;
        private PostInfo postinfo;
        private ObservableCollection<Post> postlist;
        private int previousIndex;
        private ObservableCollection<TagInfo> tags;

        public PostPageViewModel(IProgrammService programmService)
        {
            this.programmService = programmService;
        }

        public int PostSelectedIndex
        {
            get { return postSelectedIndex; }
            set
            {
                SetProperty(ref postSelectedIndex, value);
                Comments.Clear();
                HandleIndexingOfPosts();
            }
        }

        public Post Post
        {
            get { return post; }
            set { SetProperty(ref post, value); }
        }

        public Post Post1
        {
            get { return post1; }
            set { SetProperty(ref post1, value); }
        }

        public Post Post2
        {
            get { return post2; }
            set { SetProperty(ref post2, value); }
        }

        public ObservableCollection<Post> Postlist
        {
            get { return postlist; }
            set { SetProperty(ref postlist, value); }
        }

        public PostInfo Postinfo
        {
            get { return postinfo; }
            set { SetProperty(ref postinfo, value); }
        }

        public ObservableCollection<TagInfo> Tags
        {
            get { return tags; }
            set { SetProperty(ref tags, value); }
        }

        public ObservableCollection<Comment> Comments
        {
            get { return comments; }
            set { SetProperty(ref comments, value); }
        }

        public override async void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode,
            Dictionary<string, object> viewModelState)
        {
            if (navigationParameter != null)
            {
                var post = navigationParameter as Post;
                Post = post;
                Postinfo = await programmService.LoadPostInfo(Post);
                Comments = new ObservableCollection<Comment>(postinfo.Comments);
                Tags = new ObservableCollection<TagInfo>(postinfo.Tags);

                post1 = post.Parentlist.ElementAt(post.Parentlist.IndexOf(Post) + 1);
                post2 = post.Parentlist.ElementAt(post.Parentlist.IndexOf(Post) + 2);
                Postlist = post.Parentlist;
            }

            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);
        }

        private int GetNextTargetIndex(Post post)
        {
            int targetIndex = 0;
            targetIndex = Postlist.IndexOf(post) + 1;

            return targetIndex;
        }

        private int GetPreviousTargetIndex(Post post)
        {
            int targetIndex = 0;
            targetIndex = Postlist.IndexOf(post) - 1;

            return targetIndex;
        }

        private async void HandleIndexingOfPosts()
        {
            int targetIndex = 0;
            Post postToLoadCommentsFrom = null;

            if ((PostSelectedIndex > previousIndex || (previousIndex == 2 && PostSelectedIndex == 0)) &&
                !(previousIndex == 0 && PostSelectedIndex == 2))
            {
                if (PostSelectedIndex == 0)
                {
                    targetIndex = GetNextTargetIndex(Post2);
                    Post = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post;
                }

                if (PostSelectedIndex == 1)
                {
                    targetIndex = GetNextTargetIndex(Post);
                    Post1 = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post1;
                }

                if (PostSelectedIndex == 2)
                {
                    targetIndex = GetNextTargetIndex(Post1);
                    Post2 = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post2;
                }
            }
            else if (PostSelectedIndex < previousIndex || (previousIndex == 0 && PostSelectedIndex == 2))
            {
                if (PostSelectedIndex == 0)
                {
                    targetIndex = GetPreviousTargetIndex(Post1);
                    Post = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post;
                }

                if (PostSelectedIndex == 1)
                {
                    targetIndex = GetPreviousTargetIndex(Post2);
                    Post1 = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post1;
                }

                if (PostSelectedIndex == 2)
                {
                    targetIndex = GetPreviousTargetIndex(Post);
                    Post2 = Postlist.ElementAt(targetIndex);
                    postToLoadCommentsFrom = Post2;
                }
            }

            previousIndex = PostSelectedIndex;
            
            Postinfo = await programmService.LoadPostInfo(postToLoadCommentsFrom);
            Comments = new ObservableCollection<Comment>(postinfo.Comments);
            Tags = new ObservableCollection<TagInfo>(postinfo.Tags);
        }
    }
}