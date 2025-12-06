using Application.User.ResponseModel;
using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.User.Queries
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, Result<List<UserResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<List<UserResponse>>> Handle(
            GetUserListQuery request,
            CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();

            var response = users.Select(user => new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                DietaryPreference = user.DietaryPreference,
                HealthGoal = user.HealthGoal
            }).ToList();

            return Result<List<UserResponse>>.Success(
                response
            );
        }
    }
}
