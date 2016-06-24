using System;

namespace Pr0grammViewerUniversal.Model
{
    using Windows.Storage;
    using Enums;
    using Interfaces;

    public class Settings : ISettings
    {
        public bool IsSfwChecked
        {
            get
            {
                var isSfwChecked = (ApplicationData.Current.LocalSettings.Values["IsSfwChecked"]);
                if (isSfwChecked == null)
                {
                    isSfwChecked = false;
                }

                return (bool)isSfwChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsSfwChecked"]) = value;
            }
        }

        public bool IsNsfwChecked
        {
            get
            {
                var isNsfwChecked = (ApplicationData.Current.LocalSettings.Values["IsNsfwChecked"]);
                if (isNsfwChecked == null)
                {
                    isNsfwChecked = false;
                }

                return (bool)isNsfwChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsNsfwChecked"]) = value;
            }
        }

        public bool IsNsflChecked
        {
            get
            {
                var isNsflChecked = (ApplicationData.Current.LocalSettings.Values["IsNsflChecked"]);
                if (isNsflChecked == null)
                {
                    isNsflChecked = false;
                }

                return (bool)isNsflChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsNsflChecked"]) = value;
            }
        }

        public bool IsLoadPicturesChecked
        {
            get
            {
                var isLoadPicturesChecked = (ApplicationData.Current.LocalSettings.Values["IsLoadPicturesChecked"]);
                if (isLoadPicturesChecked == null)
                {
                    isLoadPicturesChecked = false;
                }

                return (bool)isLoadPicturesChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsLoadPicturesChecked"]) = value;
            }
        }

        public bool IsLoadGifsChecked
        {
            get
            {
                var isLoadGifsChecked = (ApplicationData.Current.LocalSettings.Values["IsLoadGifsChecked"]);
                if (isLoadGifsChecked == null)
                {
                    isLoadGifsChecked = false;
                }

                return (bool)isLoadGifsChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsLoadGifsChecked"]) = value;
            }
        }

        public bool IsLoadWebmsChecked
        {
            get
            {
                var isLoadWebmsChecked = (ApplicationData.Current.LocalSettings.Values["IsLoadWebmsChecked"]);
                if (isLoadWebmsChecked == null)
                {
                    isLoadWebmsChecked = false;
                }

                return (bool)isLoadWebmsChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsLoadWebmsChecked"]) = value;
            }
        }

        public bool IsUsePointsChecked
        {
            get
            {
                var isUsePointsChecked = (ApplicationData.Current.LocalSettings.Values["IsUsePointsChecked"]);
                if (isUsePointsChecked == null)
                {
                    isUsePointsChecked = false;
                }

                return (bool)isUsePointsChecked;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["IsUsePointsChecked"]) = value;
            }
        }

        public int Points
        {
            get
            {
                var points = (ApplicationData.Current.LocalSettings.Values["Points"]);
                if (points == null)
                {
                    points = 0;
                }

                return (int)points;
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["Points"]) = value;
            }
        }

        public Language Language
        {
            get
            {
                var language = (ApplicationData.Current.LocalSettings.Values["Language"]);
                if (language == null)
                {
                    language = Language.German.ToString();
                }

                return (Language) Enum.Parse(typeof(Language), (string)language);
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["Language"]) = value.ToString();
            }
        }

        public Theme Theme
        {
            get
            {
                var theme = (ApplicationData.Current.LocalSettings.Values["Theme"]);
                if (theme == null)
                {
                    theme = Theme.Dark.ToString();
                }

                return (Theme)Enum.Parse(typeof(Theme), (string)theme);
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["Theme"]) = value.ToString();
            }
        }

        public PostView PostView
        {
            get
            {
                var postView = (ApplicationData.Current.LocalSettings.Values["PostView"]);
                if (postView == null)
                {
                    postView = PostView.PicturesWithBorder.ToString();
                }

                return (PostView)Enum.Parse(typeof(PostView), (string)postView);
            }

            set
            {
                (ApplicationData.Current.LocalSettings.Values["PostView"]) = value.ToString();
            }
        }
    }
}
