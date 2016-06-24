using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ViewModels
{
    using System.Linq;
    using Windows.Storage;
    using Windows.UI.Xaml;
    using Enums;
    using ExtendedClasses;
    using Interfaces;
    using Microsoft.Practices.Prism.Mvvm;
    using Model;

    public class SettingsPageViewModel : ViewModel
    {
        private readonly ISettings settings;
        private readonly ICommonLogic commonLogic;

        public SettingsPageViewModel(ISettings settings, ICommonLogic commonLogic)
        {
            this.settings = settings;
            this.commonLogic = commonLogic;
        }

        public bool IsSfwChecked
        {
            get { return settings.IsSfwChecked; }

            set { settings.IsSfwChecked = value; }
        }

        public bool IsNsfwChecked
        {
            get { return settings.IsNsfwChecked; }

            set { settings.IsNsfwChecked = value; }
        }

        public bool IsNsflChecked
        {
            get { return settings.IsNsflChecked; }

            set { settings.IsNsflChecked = value; }
        }

        public bool IsLoadPicturesChecked
        {
            get { return settings.IsLoadPicturesChecked; }

            set { settings.IsLoadPicturesChecked = value; }
        }

        public bool IsLoadGifsChecked
        {
            get { return settings.IsLoadGifsChecked; }

            set { settings.IsLoadGifsChecked = value; }
        }

        public bool IsLoadWebmsChecked
        {
            get { return settings.IsLoadWebmsChecked; }

            set { settings.IsLoadWebmsChecked = value; }
        }

        public bool IsUsePointsChecked
        {
            get { return settings.IsUsePointsChecked; }

            set { settings.IsUsePointsChecked = value; }
        }

        public int Points
        {
            get { return settings.Points; }

            set { settings.Points = value; }
        }

        public Language Language
        {
            get { return settings.Language; }

            set
            {
                settings.Language = value;
                var culture = commonLogic.GetAttribute<CultureDescriptionAttribute, Language>(value);
                commonLogic.SetUiCulture(culture.CultureDescription);
            }
        }

        public Theme Theme
        {
            get { return settings.Theme; }

            set
            {
                settings.Theme = value;
            }
        }

        public PostView PostView
        {
            get { return settings.PostView; }

            set
            {
                settings.PostView = value;
            }
        }
    }
}
