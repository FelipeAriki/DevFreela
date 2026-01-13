using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommand : IRequest<ResultViewModel<int>>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Core.Entities.User ToEntity() => new(FullName, Email, BirthDate);
    }
}
