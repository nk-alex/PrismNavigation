using PrismNavigation.ViewModels;
using PrismNavigation.Views;

namespace PrismNavigation;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes).OnAppStart("LoginPage");
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry
            .RegisterForNavigation<LoginPage, LoginPageViewModel>()
            .RegisterForNavigation<MainPage, MainPageViewModel>()
            .RegisterInstance(SemanticScreenReader.Default);
    }
}
