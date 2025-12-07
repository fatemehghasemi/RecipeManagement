using Application.UserRecipeInteraction.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.UserRecipeInteraction.Commands
{
    public class UserRecipeInteractionUpdateCommand : IRequest<Result<UserRecipeInteractionResponse>>
    {
        public Guid Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
