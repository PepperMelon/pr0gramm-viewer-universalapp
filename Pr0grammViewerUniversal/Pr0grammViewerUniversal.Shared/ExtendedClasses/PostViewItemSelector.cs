using System;
using System.Collections.Generic;
using System.Text;

namespace Pr0grammViewerUniversal.ExtendedClasses
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Enums;
    using Interfaces;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    public class PostViewItemSelector : DataTemplateSelector
    {
        private readonly ISettings settings;

        public DataTemplate ListItemTemplate { get; set; }
        public DataTemplate PicturesWithBorderItemTemplate { get; set; }
        public DataTemplate PicturesWithoutBorderItemTemplate { get; set; }
        public DataTemplate EfficientItemTemplate { get; set; }
        public DataTemplate BigViewItemTemplate { get; set; }
        

        public PostViewItemSelector()
        {
            settings = ServiceLocator.Current.GetInstance<ISettings>();
        }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (settings.PostView == PostView.List)
            {
                return ListItemTemplate;
            }

            if (settings.PostView == PostView.PicturesWithBorder)
            {
                return PicturesWithBorderItemTemplate;
            }

            if (settings.PostView == PostView.PicturesWithoutBorder)
            {
                return PicturesWithoutBorderItemTemplate;
            }

            if (settings.PostView == PostView.Efficient)
            {
                return EfficientItemTemplate;
            }

            if (settings.PostView == PostView.BigView)
            {
                return BigViewItemTemplate;
            }

            return PicturesWithoutBorderItemTemplate;
        }
    }
}
