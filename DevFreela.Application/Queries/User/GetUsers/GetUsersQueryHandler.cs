using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.User.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, ResultViewModel<List<UserItemViewModel>>>
    {
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<UserItemViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsers();
            var model = users.Select(UserItemViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserItemViewModel>>.Success(model);
        }
    }
}
