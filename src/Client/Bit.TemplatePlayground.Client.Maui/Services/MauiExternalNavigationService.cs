namespace Bit.TemplatePlayground.Client.Maui.Services;

public class MauiExternalNavigationService : IExternalNavigationService
{
    public async Task NavigateToAsync(string url)
    {
        await Browser.OpenAsync(url, OperatingSystem.IsAndroid() ? BrowserLaunchMode.SystemPreferred : BrowserLaunchMode.External);
    }
}
