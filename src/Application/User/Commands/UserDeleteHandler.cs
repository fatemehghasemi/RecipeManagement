using Domain.Common;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.User.Commands
{
    public class UserDeleteHandler : IRequestHandler<UserDeleteCommand, Result<bool>>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<bool>> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                return Result<bool>.Fail(
                "User Not Found", StatusCodes.Status404NotFound
                );
            }

            await _userRepository.DeleteAsync(user);

            return Result<bool>.Success(
                true);
        }
    }
}
