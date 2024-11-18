﻿using Bit.TemplatePlayground.Shared.Dtos.Identity;
using Bit.TemplatePlayground.Shared.Controllers.Identity;

namespace Bit.TemplatePlayground.Client.Core.Components.Pages.Authorized.Settings;

public partial class SettingsPage
{
    protected override string? Title => Localizer[nameof(AppStrings.Settings)];
    protected override string? Subtitle => string.Empty;


    [Parameter] public string? Section { get; set; }


    [AutoInject] private IUserController userController = default!;


    private UserDto? user;
    private bool isLoading;
    private string? profileImageUrl;
    private string? openedAccordion;


    protected override async Task OnInitAsync()
    {
        openedAccordion = Section?.ToLower();

        isLoading = true;

        try
        {
            user = await userController.GetCurrentUser(CurrentCancellationToken);

            var access_token = await PrerenderStateService.GetValue(AuthTokenProvider.GetAccessToken);
            profileImageUrl = new Uri(AbsoluteServerAddress, $"/api/Attachment/GetProfileImage?access_token={access_token}").ToString();
        }
        finally
        {
            isLoading = false;
        }

        await base.OnInitAsync();
    }
}
