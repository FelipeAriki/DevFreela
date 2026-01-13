using DevFreela.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.User.CreateUserSkill
{
    public class CreateUserSkillCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
        public int[] SkillIds { get; set; }
    }
}
