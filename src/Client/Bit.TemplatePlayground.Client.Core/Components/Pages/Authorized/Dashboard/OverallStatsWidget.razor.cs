﻿using Bit.TemplatePlayground.Shared.Controllers.Dashboard;
using Bit.TemplatePlayground.Shared.Dtos.Dashboard;

namespace Bit.TemplatePlayground.Client.Core.Components.Pages.Authorized.Dashboard;

public partial class OverallStatsWidget
{
    [AutoInject] IDashboardController dashboardController = default!;

    private bool isLoading;
    private OverallAnalyticsStatsDataResponseDto dto = new();

    protected override async Task OnInitAsync()
    {
        await GetData();
    }

    private async Task GetData()
    {
        isLoading = true;

        try
        {
            dto = await dashboardController.GetOverallAnalyticsStatsData(CurrentCancellationToken);
        }
        finally
        {
            isLoading = false;
        }
    }
}
