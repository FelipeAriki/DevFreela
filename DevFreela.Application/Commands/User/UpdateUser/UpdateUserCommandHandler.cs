using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            if (user is null)
            {
                return ResultViewModel.Error("Usuário não existe.");
            }

            user.Update(request.FullName, request.Email, request.BirthDate, request.Active);
            await _userRepository.UpdateUser(user);

            return ResultViewModel.Success();
        }
    }
}
