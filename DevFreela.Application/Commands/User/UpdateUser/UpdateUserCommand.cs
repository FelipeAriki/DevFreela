using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
    }
}
