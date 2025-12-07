using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.UserRecipeInteraction.Queries
{
    public class GetUserRecipeInteractionByIdCommand : IRequest<Result<List<UserRecipeInteractionResponse>>>
    {
        public Guid UserId { get; set; }
    }
}
