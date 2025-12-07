using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.UserRecipeInteraction.Commands
{
    public class UserRecipeInteractionCreateCommand : IRequest<Result<UserRecipeInteractionResponse>>
    {
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
