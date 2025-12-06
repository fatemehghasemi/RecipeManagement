using Application.User.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.User.Commands
{
    public class UserCreateHandler : IRequestHandler<UserCreateCommand, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public UserCreateHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User
            {
                Id = Guid.NewGuid(),
                DietaryPreference = request.DietaryPreference,
                HealthGoal = request.HealthGoal,
                Name = request.Name
            };

            await _userRepository.AddAsync(user);

            var response = user.Adapt<UserResponse>();

            return Result<UserResponse>.Success(response);
        }
    }
}
