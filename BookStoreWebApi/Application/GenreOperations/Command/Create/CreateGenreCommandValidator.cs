using System;
using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Command.Create
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotNull().WithMessage("Tür ismi boş geçilemez.")
                .MaximumLength(20).WithMessage("Tür ismi 20 karakteri geçemez.");
            RuleFor(x => x.Model.IsActive).NotNull();
        }
    }
}
