using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.User.Password.PasswordRecovery
{
    public class PasswordRecoveryCommand : IRequest<ResultViewModel>
    {
        public string Email { get; set; }
    }
}
