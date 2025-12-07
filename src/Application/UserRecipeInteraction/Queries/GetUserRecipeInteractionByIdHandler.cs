using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.UserRecipeInteraction.Queries
{
    public class GetUserRecipeInteractionByIdHandler : IRequestHandler<GetUserRecipeInteractionByIdCommand, Result<List<UserRecipeInteractionResponse>>>
    {
        private readonly IUserRecipeInteractionRepository _recipeInteractionRepository;
        public GetUserRecipeInteractionByIdHandler(IUserRecipeInteractionRepository userRecipeInteractionRepository)
        {
            _recipeInteractionRepository = userRecipeInteractionRepository;
        }

        public async Task<Result<List<UserRecipeInteractionResponse>>> Handle(GetUserRecipeInteractionByIdCommand request, CancellationToken cancellationToken)
        {
            var list = await _recipeInteractionRepository.GetByUserIdAsync(request.UserId);

            var response = list.Adapt<List<UserRecipeInteractionResponse>>();

            return Result<List<UserRecipeInteractionResponse>>.Success(response);
        }
    }
}
