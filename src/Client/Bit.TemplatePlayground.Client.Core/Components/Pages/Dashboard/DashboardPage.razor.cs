using Microsoft.AspNetCore.Components.WebAssembly.Services;

namespace Bit.TemplatePlayground.Client.Core.Components.Pages.Dashboard;

[Authorize]
public partial class DashboardPage
{
    [AutoInject] LazyAssemblyLoader lazyAssemblyLoader = default!;

    private bool isLoadingAssemblies = true;

    protected async override Task OnInitAsync()
    {
        try
        {
            if (AppPlatform.IsBrowser)
            {
                await lazyAssemblyLoader.LoadAssembliesAsync([
                    "System.Private.Xml.wasm", "System.Data.Common.wasm",
                    "Newtonsoft.Json.wasm"]
                    );
            }
        }
        finally
        {
            isLoadingAssemblies = false;
        }

        await base.OnInitAsync();
    }
}
