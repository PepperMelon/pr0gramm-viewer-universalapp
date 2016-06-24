namespace Pr0grammViewerUniversal.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Data;
    using Constants;
    using ExtendedClasses;
    using Interfaces;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.Mvvm.Interfaces;
    using Model;

    public class MainPageViewModel : ViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IProgrammService programmService;
        private readonly ISettings settings;
        private readonly ICommonLogic commonLogic;
        private ObservableCollection<Post> hotPosts;
        private ObservableCollection<Post> newPosts;
        private Post selectedPost;

        public MainPageViewModel(INavigationService navigationService, IProgrammService programmService, ISettings settings, ICommonLogic commonLogic)
        {
            this.navigationService = navigationService;
            this.programmService = programmService;
            this.settings = settings;
            this.commonLogic = commonLogic;

            NavigateToSettingsCommand = new DelegateCommand(() => navigationService.Navigate("Settings" , null));

            hotPosts = new IncrementalObservableCollection<Post>(
                () => true,
                (uint count) =>
                {
                    var loadMoreItemsTask = LoadHotPostsAsync();
                    return loadMoreItemsTask.AsAsyncOperation();
                });

            newPosts = new IncrementalObservableCollection<Post>(
                () => true,
                (uint count) =>
                {
                    var loadMoreItemsTask = LoadNewPostsAsync();
                    return loadMoreItemsTask.AsAsyncOperation();
                });
        }

        public DelegateCommand NavigateToSettingsCommand { get; private set; }

        public ObservableCollection<Post> HotPosts
        {
            get { return hotPosts; }

            set { SetProperty(ref hotPosts, value); }
        }

        public ObservableCollection<Post> NewPosts
        {
            get { return newPosts; }

            set { SetProperty(ref newPosts, value); }
        }

        public Post SelectedPost
        {
            get { return selectedPost; }

            set
            {
                SetProperty(ref selectedPost, value);
                navigationService.Navigate("Post", value);
            }
        }

        private async Task<LoadMoreItemsResult> LoadHotPostsAsync()
        {
            var flag = commonLogic.GetFlagFilter(settings);
            var url = string.Format("{0}&promoted=1", string.Format(ApiCalls.HotPostsUrl, flag));
            if (hotPosts.Any())
            {
                url = string.Format("{0}&older={1}", url, hotPosts.Last().Promoted);
            }

            var posts = await programmService.LoadPosts(new Uri(url));
            foreach (var post in posts)
            {
                if (FilterPost(post))
                {
                    continue;
                }

                post.Parentlist = hotPosts;
                hotPosts.Add(post);
            }

            return new LoadMoreItemsResult
            {
                Count = (uint)posts.Count()
            };
        }

        private async Task<LoadMoreItemsResult> LoadNewPostsAsync()
        {
            var flag = commonLogic.GetFlagFilter(settings);
            var url = string.Format(ApiCalls.HotPostsUrl, flag);
            if (newPosts.Any())
            {
                url = string.Format("{0}&older={1}", url, newPosts.Last().Id);
            }

            var posts = await programmService.LoadPosts(new Uri(url));
            foreach (var post in posts)
            {
                if (FilterPost(post))
                {
                    continue;
                }

                post.Parentlist = newPosts;
                newPosts.Add(post);
            }

            return new LoadMoreItemsResult
            {
                Count = (uint)posts.Count()
            };
        }

        private bool FilterPost(Post postObject)
        {
            var isPostGif = postObject.Image.EndsWith(".gif");
            var isPostWebm = postObject.Image.EndsWith(".webm");
            if (!settings.IsLoadPicturesChecked && !isPostWebm && !isPostGif)
            {
                return true;
            }

            if (!settings.IsLoadGifsChecked && isPostGif)
            {
                return true;
            }

            if (!settings.IsLoadWebmsChecked && isPostWebm)
            {
                return true;
            }

            var points = postObject.Up - postObject.Down;
            if (settings.IsUsePointsChecked && points <= settings.Points)
            {
                return true;
            }

            return false;
        }
    }
}