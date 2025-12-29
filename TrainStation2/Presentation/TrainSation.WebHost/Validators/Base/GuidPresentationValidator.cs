using FluentValidation;

namespace TrainSation.WebHost.Validators.Base
{
    public class GuidPresentationValidator : AbstractValidator<Guid>
    {
        public GuidPresentationValidator()
        {
            // Основной метод библиотеки FluentValidation для определения правил валидации свойств объектов
            RuleFor(x => x)
                .NotEmpty();
        }
    }
}
