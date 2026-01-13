using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.User.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;

        public DeleteUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserById(request.Id);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não existe.");
            }

            user.SetAsDeleted();
            await _repository.UpdateUser(user);

            return ResultViewModel.Success();
        }
    }
}
