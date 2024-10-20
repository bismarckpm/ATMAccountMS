using AccountMS.Infrastructure.Exceptions;
using FluentValidation;

namespace AccountMS.Application.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        public virtual async Task<bool> ValidateRequest(T request)
        {
            var result = await ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidatorException(result.Errors.ToString() ?? string.Empty);
            }

            return result.IsValid;
        }
    }
}
