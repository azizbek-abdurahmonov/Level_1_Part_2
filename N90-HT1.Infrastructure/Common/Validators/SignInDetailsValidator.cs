using FluentValidation;
using Microsoft.Extensions.Options;
using N90_HT1.Application.Common.Identity.Models;
using N90_HT1.Infrastructure.Common.Settings;

namespace N90_HT1.Infrastructure.Common.Validators;

public class SignInDetailsValidator : AbstractValidator<SignInDetails>
{
    public SignInDetailsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(x => x.EmailAddress).NotEmpty().Matches(validationSettingsValue.EmailAddressRegexPattern);

        RuleFor(x => x.Password).NotEmpty();
    }
}