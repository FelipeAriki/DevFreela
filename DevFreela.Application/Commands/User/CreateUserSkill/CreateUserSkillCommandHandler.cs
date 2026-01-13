using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.CreateUserSkill
{
    public class CreateUserSkillCommandHandler : IRequestHandler<CreateUserSkillCommand, ResultViewModel>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserSkillCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultViewModel> Handle(CreateUserSkillCommand request, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository.UserExists(request.Id);
            if (!userExists) return ResultViewModel.Error("Usuário não encontrado.");

            var userSkills = request.SkillIds.Select(s => new UserSkill(request.Id, s)).ToList();
            await _userRepository.CreateUserSkill(userSkills);

            return ResultViewModel.Success();
        }
    }
}
