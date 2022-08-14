using System;
using FluentValidation;

namespace BookStoreWebApi.Application.BookOperations.Command.Create
{
    public class CreateCommandValidator:AbstractValidator<CreateBookCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Model.Title).NotNull();
            RuleFor(x => x.Model.PageCount).NotNull();
            RuleFor(x => x.Model.GenreId).NotNull();
            RuleFor(x => x.Model.PublishDate).NotNull();
        }
    }
}
