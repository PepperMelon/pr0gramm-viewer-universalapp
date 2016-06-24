using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Prism.Mvvm.Interfaces;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Pr0grammViewerUniversal
{
    using Windows.UI.ViewManagement;
    using Enums;
    using Interfaces;
    using Logic;
    using Microsoft.Practices.ServiceLocation;
    using Model;

    sealed partial class App : MvvmAppBase
    {
        readonly IUnityContainer container = new UnityContainer();
        readonly IHttpRequest httpRequest = new HttpRequest();
        readonly ICommonLogic commonLogic = new CommonLogic();
        readonly ISettings settings = new Settings();
        readonly IProgrammService programmService;

        public App()
        {
            programmService = new ProgrammService(httpRequest, commonLogic);
            if (settings.Theme == Theme.Dark)
            {
                RequestedTheme = ApplicationTheme.Dark;
            }
            if (settings.Theme == Theme.Light)
            {
                RequestedTheme = ApplicationTheme.Light;
            }

            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
            return Task.FromResult<object>(null);
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // Register MvvmAppBase services with the container so that view models can take dependencies on them
            container.RegisterInstance<ISessionStateService>(SessionStateService);
            container.RegisterInstance<INavigationService>(NavigationService);

            // Register any app specific types with the container
            container.RegisterInstance<IHttpRequest>(httpRequest);
            container.RegisterInstance<IProgrammService>(programmService);
            container.RegisterInstance<ICommonLogic>(commonLogic);
            container.RegisterInstance<ISettings>(settings);

            // Set a factory for the ViewModelLocator to use the container to construct view models so their
            // dependencies get injected by the container
            ViewModelLocationProvider.SetDefaultViewModelFactory((viewModelType) => container.Resolve(viewModelType));

            // Set locator for static access
            // Avoid to use this!
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            return Task.FromResult<object>(null);
        }
    }
}