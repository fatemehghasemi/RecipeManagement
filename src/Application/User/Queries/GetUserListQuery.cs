using Application.User.ResponseModel;
using Domain.Common;
using MediatR;

namespace Application.User.Queries
{
    public class GetUserListQuery : IRequest<Result<List<UserResponse>>>
    {
    }
}
