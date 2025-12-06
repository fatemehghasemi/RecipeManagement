using Application.User.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.User.Commands
{
    public class UserUpdateHandler : IRequestHandler<UserUpdateCommand, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        public UserUpdateHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result<UserResponse>> Handle(
          UserUpdateCommand request,
          CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return Result<UserResponse>.Fail(
                    "user not found",
                    (int)StatusCodes.Status404NotFound
                );
            }

            user.Name = request.Name;
            user.DietaryPreference = request.DietaryPreference;
            user.HealthGoal = request.HealthGoal;

            await _userRepository.UpdateAsync(user);

            var response = new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                DietaryPreference = user.DietaryPreference,
                HealthGoal = user.HealthGoal
            };

            return Result<UserResponse>.Success(response);
        }

    }
}
