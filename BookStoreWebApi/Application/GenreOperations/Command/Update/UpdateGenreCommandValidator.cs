using System;
using FluentValidation;

namespace BookStoreWebApi.Application.GenreOperations.Command.Update
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Tür ismi boş geçilemez.")
                .MaximumLength(20).WithMessage("Tür ismi 20 karakteri geçemez.");
            RuleFor(x => x.Model.IsActive).NotEmpty();
        }
    }
}
