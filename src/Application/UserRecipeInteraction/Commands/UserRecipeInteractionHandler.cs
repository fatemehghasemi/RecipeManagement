using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.UserRecipeInteraction.Commands
{
    internal class UserRecipeInteractionCreateHandler : IRequestHandler<UserRecipeInteractionCreateCommand, Result<UserRecipeInteractionResponse>>
    {
        private readonly IUserRecipeInteractionRepository _userRecipeInteractionRepository;
        public UserRecipeInteractionCreateHandler(IUserRecipeInteractionRepository userRecipeInteractionRepository)
        {
            _userRecipeInteractionRepository = userRecipeInteractionRepository;
        }
        public async Task<Result<UserRecipeInteractionResponse>> Handle(UserRecipeInteractionCreateCommand request, CancellationToken cancellationToken)
        {
            var userRecipeInteraction = new Domain.Entities.UserRecipeInteraction()
            {
                Action = request.Action,
                Id = Guid.NewGuid(),
                RecipeId = request.RecipeId,
                Timestamp = DateTime.Now,
                UserId = request.UserId
            };
            await _userRecipeInteractionRepository.AddAsync(userRecipeInteraction);

            var response = userRecipeInteraction.Adapt<UserRecipeInteractionResponse>();

            return Result<UserRecipeInteractionResponse>.Success(response);
        }
    }
}
