using Microsoft.Extensions.Logging;

namespace Bit.TemplatePlayground.Client.Core.Components;

public partial class AppInitializer : AppComponentBase
{

    [AutoInject] private MessageBoxService messageBoxService = default!;
    [AutoInject] private AuthenticationManager authManager = default!;
    [AutoInject] private IJSRuntime jsRuntime = default!;
    [AutoInject] private IBitDeviceCoordinator bitDeviceCoordinator = default!;
    [AutoInject] private IStorageService storageService = default!;
    [AutoInject] private CultureInfoManager cultureInfoManager = default!;
    [AutoInject] private ILogger<AuthenticationManager> authLogger = default!;

    protected async override Task OnInitAsync()
    {
        AuthenticationManager.AuthenticationStateChanged += AuthenticationStateChanged;

        AuthenticationStateChanged(AuthenticationManager.GetAuthenticationStateAsync());

        if (AppPlatform.IsBlazorHybrid)
        {
            if (CultureInfoManager.MultilingualEnabled)
            {
                cultureInfoManager.SetCurrentCulture(await storageService.GetItem("Culture") ?? // 1- User settings
                                                     CultureInfo.CurrentUICulture.Name); // 2- OS settings
            }

            await SetupBodyClasses();
        }

        await base.OnInitAsync();
    }

    protected override async Task OnAfterFirstRenderAsync()
    {
        await base.OnAfterFirstRenderAsync();

        if (AppPlatform.IsBlazorHybrid is false)
        {
            AppPlatform.OSDescription = await jsRuntime.GetBrowserPlatform();
        }
    }

    private async void AuthenticationStateChanged(Task<AuthenticationState> task)
    {
        try
        {
            var user = (await AuthenticationStateTask).User;

            var (isUserAuthenticated, userId, userName, email, sessionId) = user.IsAuthenticated() ? (user.IsAuthenticated(), user.GetUserId().ToString(), user.GetUserName(), user.GetEmail(), user.GetSessionId()) : default;

            LogAuthenticationState(authLogger, isUserAuthenticated, userId, userName, email, sessionId);

        }
        catch (Exception exp)
        {
            ExceptionHandler.Handle(exp);
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Authentication State: {IsUserAuthenticated}, {UserId}, {UserName}, {Email}, {UserSessionId}")]
    private static partial void LogAuthenticationState(ILogger logger, bool isUserAuthenticated, string userId, string userName, string? email, string? userSessionId);


    private async Task SetupBodyClasses()
    {
        var cssClasses = new List<string> { };

        if (AppPlatform.IsWindows)
        {
            cssClasses.Add("bit-windows");
        }
        else if (AppPlatform.IsMacOS)
        {
            cssClasses.Add("bit-macos");
        }
        else if (AppPlatform.IsIOS)
        {
            cssClasses.Add("bit-ios");
        }
        else if (AppPlatform.IsAndroid)
        {
            cssClasses.Add("bit-android");
        }

        var cssVariables = new Dictionary<string, string>();
        var statusBarHeight = bitDeviceCoordinator.GetStatusBarHeight();

        if (AppPlatform.IsMacOS is false)
        {
            //For iOS this is handled in css using safe-area env() variables
            //For Android there's an issue with keyboard in fullscreen mode. more info: https://github.com/bitfoundation/bitplatform/issues/5626
            //For Windows there's an issue with TitleBar. more info: https://github.com/bitfoundation/bitplatform/issues/5695
            statusBarHeight = 0;
        }

        cssVariables.Add("--bit-status-bar-height", $"{statusBarHeight.ToString("F3", CultureInfo.InvariantCulture)}px");
        await jsRuntime.ApplyBodyElementClasses(cssClasses, cssVariables);
    }

}
