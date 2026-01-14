using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Core.Entities.User ToEntity(string hashPassword) => new(FullName, Email, BirthDate, hashPassword, Role);
    }
}
