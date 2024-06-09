﻿using Bit.TemplatePlayground.Shared.Dtos.Identity;

namespace Bit.TemplatePlayground.Client.Core.Controllers.Identity;

[Route("api/[controller]/[action]/")]
public interface IIdentityController : IAppController
{
    [HttpPost]
    Task SignUp(SignUpRequestDto request, CancellationToken cancellationToken = default);

    [HttpPost]
    Task SendConfirmEmailToken(SendEmailTokenRequestDto request, CancellationToken cancellationToken = default);

    [HttpPost]
    Task ConfirmEmail(ConfirmEmailRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task SendConfirmPhoneToken(SendPhoneTokenRequestDto request, CancellationToken cancellationToken = default);

    [HttpPost]
    Task ConfirmPhone(ConfirmPhoneRequestDto request, CancellationToken cancellationToken);

    [HttpPost]
    Task SendResetPasswordToken(SendResetPasswordTokenRequestDto request, CancellationToken cancellationToken = default);

    [HttpPost]
    Task ResetPassword(ResetPasswordRequestDto request, CancellationToken cancellationToken = default);

    [HttpPost]
    Task<TokenResponseDto> Refresh(RefreshRequestDto request, CancellationToken cancellationToken = default) => default!;

    [HttpPost]
    Task<SignInResponseDto> SignIn(SignInRequestDto request, CancellationToken cancellationToken = default) => default!;

    [HttpPost]
    Task SendTwoFactorToken(IdentityRequestDto request, CancellationToken cancellationToken);

    [HttpPost("{?returnUrl}")]
    Task SendOtp(IdentityRequestDto request, string? returnUrl = null, CancellationToken cancellationToken = default);

    [HttpGet("{?provider,returnUrl,localHttpPort}")]
    Task<string> GetSocialSignInUri(string provider, string? returnUrl = null, int? localHttpPort = null);
}
