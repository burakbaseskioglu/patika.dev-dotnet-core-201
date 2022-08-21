using System;
using FluentValidation;

namespace BookStoreWebApi.Application.BookOperations.Command.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Model.Title).NotEmpty().MinimumLength(4);
            RuleFor(x => x.Model.PageCount).NotEmpty();
            RuleFor(x => x.Model.GenreId).NotEmpty();
            RuleFor(x => x.Model.PublishDate).NotEmpty();
        }
    }
}
