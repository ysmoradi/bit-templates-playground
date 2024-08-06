namespace Bit.TemplatePlayground.Server.Api.Models.Emailing;

public class TwoFactorTokenTemplateModel
{
    public required string DisplayName { get; set; }

    public required string Token { get; set; }
}
