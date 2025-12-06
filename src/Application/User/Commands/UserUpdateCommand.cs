using Application.User.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.User.Commands
{
    public class UserUpdateCommand : IRequest<Result<UserResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DietaryPreference { get; set; } = string.Empty;
        public string HealthGoal { get; set; } = string.Empty;
    }
}
