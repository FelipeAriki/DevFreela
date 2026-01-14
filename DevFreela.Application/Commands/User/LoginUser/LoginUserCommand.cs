using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.User.LoginUser
{
    public class LoginUserCommand : IRequest<ResultViewModel<LoginViewModel>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
