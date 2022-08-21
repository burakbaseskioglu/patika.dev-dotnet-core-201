using System;
using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOperations.Command.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotNull();
            RuleFor(x => x.Model.LastName).NotNull();
        }
    }
}
