namespace Bit.TemplatePlayground.Shared.Controllers.Diagnostics;

[Route("api/[controller]/[action]/")]
public interface IDiagnosticsController : IAppController
{
    [HttpPost]
    Task<string> PerformDiagnostics(CancellationToken cancellationToken);
}
