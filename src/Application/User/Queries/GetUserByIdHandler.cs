using Application.User.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.User.Queries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserResponse>> Handle(
            GetUserByIdQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return Result<UserResponse>.Fail(
                    "User not found",
                    StatusCodes.Status404NotFound
                );
            }

            var response = new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                DietaryPreference = user.DietaryPreference,
                HealthGoal = user.HealthGoal
            };

            return Result<UserResponse>.Success(
                response);
        }
    }
}
