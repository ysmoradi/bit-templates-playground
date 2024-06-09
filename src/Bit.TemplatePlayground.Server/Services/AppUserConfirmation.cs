using Bit.TemplatePlayground.Server.Models.Identity;

namespace Bit.TemplatePlayground.Server.Services;

public class AppUserConfirmation : IUserConfirmation<User>
{
    public async Task<bool> IsConfirmedAsync(UserManager<User> manager, User user)
    {
        return user.EmailConfirmed || user.PhoneNumberConfirmed;
    }
}
