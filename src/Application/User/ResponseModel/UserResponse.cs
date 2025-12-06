namespace Application.User.ResponseModel
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DietaryPreference { get; set; } = string.Empty;
        public string HealthGoal { get; set; } = string.Empty;
    }
}
