namespace Pr0grammViewerUniversal.Views
{
    using System;
    using Windows.UI.Xaml.Controls;
    using Enums;
    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.StoreApps;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : VisualStateAwarePage
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            this.LanguageComboBox.ItemsSource = Enum.GetValues(typeof(Language));
            this.ThemeComboBox.ItemsSource = Enum.GetValues(typeof(Theme));
            this.DisplayPostsComboBox.ItemsSource = Enum.GetValues(typeof(PostView));
        }
    }
}
