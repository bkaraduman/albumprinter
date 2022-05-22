using FluentValidation;
using FluentValidation.Results;

namespace Albelli.Api.Application.Validation
{
    public class ValidationBase<T> : AbstractValidator<T>
    {
        public ValidationBase()
        {
            base.CascadeMode = CascadeMode.Stop;
        }

        public new void Validate(T poco)
        {
            ValidationResult validationResult = base.Validate(poco);

            if (!validationResult.IsValid)
            {
                ValidationFailure error = validationResult.Errors.FirstOrDefault();

                int.TryParse(error.ErrorCode, out int errorCode);

                if (errorCode > 0)
                    throw new Common.Infrastructure.Exceptions.ValidationException(error.ErrorMessage, errorCode);
                else
                    throw new Common.Infrastructure.Exceptions.ValidationException(error.ErrorMessage);
            }

        }
    }
}
