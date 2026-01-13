using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UserViewModel>>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserDetailsById(request.Id);

            if (user is null)
            {
                return ResultViewModel<UserViewModel>.Error("Usuário não existe.");
            }

            return ResultViewModel<UserViewModel>.Success(UserViewModel.FromEntity(user));
        }
    }
}
