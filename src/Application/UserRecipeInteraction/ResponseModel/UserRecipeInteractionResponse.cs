namespace Application.UserRecipeInteraction.ResponseModel
{
    public class UserRecipeInteractionResponse
    {
        public Guid Id { get; set; }
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public Guid UserId { get; set; }
        public Guid RecipeId { get; set; }
    }
}
