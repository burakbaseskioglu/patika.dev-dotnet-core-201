using System;
using FluentValidation;

namespace BookStoreWebApi.Application.BookOperations.Command.Update
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Model.Title).NotEmpty();
            RuleFor(x => x.Model.GenreId).NotEmpty();
            RuleFor(x => x.Model.PageCount).NotEmpty();
            RuleFor(x => x.Model.PublishDate).NotEmpty();
            RuleFor(x => x.Model.GenreId).NotEmpty();
        }
    }
}
