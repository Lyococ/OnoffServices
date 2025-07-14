using FluentValidation;
namespace Onoff.Model.Validation
{
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .MaximumLength(200).WithMessage("La descripción no puede superar los 200 caracteres.");           
        }
    }
}
