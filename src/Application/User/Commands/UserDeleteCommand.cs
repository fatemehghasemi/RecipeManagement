using Domain.Common;
using MediatR;

namespace Application.User.Commands
{
    public class UserDeleteCommand : IRequest<Result<bool>>
    {
        public Guid UserId { get; set; }

        public UserDeleteCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
