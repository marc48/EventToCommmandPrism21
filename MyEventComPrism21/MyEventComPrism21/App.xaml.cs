using MyEventComPrism21.Services;
using MyEventComPrism21.ViewModels;
using MyEventComPrism21.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MyEventComPrism21
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SimpleExamplePage, SimpleExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<EventArgsParameterExamplePage, EventArgsParameterExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<EventArgsConverterExamplePage, EventArgsConverterExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<TestPage, TestPageViewModel>();

            containerRegistry.Register<IDataProvider, MockDataProvider>();
        }
    }
}
