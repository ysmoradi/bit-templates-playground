
namespace Bit.TemplatePlayground.Shared.Dtos.Identity;

public class SignInResponseDto : TokenResponseDto
{
    public bool RequiresTwoFactor { get; set; }
}
