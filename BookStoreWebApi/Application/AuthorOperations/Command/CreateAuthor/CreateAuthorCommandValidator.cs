using System;
using FluentValidation;

namespace BookStoreWebApi.Application.AuthorOperations.Command.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotNull();
            RuleFor(x => x.Model.LastName).NotNull();
        }
    }
}
