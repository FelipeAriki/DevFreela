using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Queries.User.GetUsers
{
    public class GetUsersQuery : IRequest<ResultViewModel<List<UserItemViewModel>>>
    {
    }
}
