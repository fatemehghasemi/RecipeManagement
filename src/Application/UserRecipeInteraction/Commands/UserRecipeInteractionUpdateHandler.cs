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
using Microsoft.AspNetCore.Http;

namespace Application.UserRecipeInteraction.Commands
{
    internal class UserRecipeInteractionUpdateHandler : IRequestHandler<UserRecipeInteractionUpdateCommand, Result<UserRecipeInteractionResponse>>
    {
        private readonly IUserRecipeInteractionRepository _userRecipeInteractionRepository;
        public UserRecipeInteractionUpdateHandler(IUserRecipeInteractionRepository userRecipeInteractionRepository)
        {
            _userRecipeInteractionRepository = userRecipeInteractionRepository;
        }
        public async Task<Result<UserRecipeInteractionResponse>> Handle(UserRecipeInteractionUpdateCommand request, CancellationToken cancellationToken)
        {
            var userUserRecipeInteraction = _userRecipeInteractionRepository.GetByUserIdAsync(request.UserId);
            if (userUserRecipeInteraction.Result == null)
            {

                return Result<UserRecipeInteractionResponse>.Fail("user not found", (int)StatusCodes.Status404NotFound);
            }

            var firstdata = userUserRecipeInteraction.Result.First();
            firstdata.Action = request.Action;
            firstdata.Timestamp = request.Timestamp;
            firstdata.UserId = request.UserId;
            firstdata.RecipeId = request.RecipeId;

            await _userRecipeInteractionRepository.UpdateAsync(firstdata);

            var response = firstdata.Adapt<UserRecipeInteractionResponse>();

            return Result<UserRecipeInteractionResponse>.Success(response);
        }
    }
}
