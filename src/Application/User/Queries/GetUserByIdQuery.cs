using Application.User.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.User.Queries
{
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        public Guid UserId { get; set; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
