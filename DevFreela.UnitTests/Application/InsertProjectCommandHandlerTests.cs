using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class InsertProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Success_NSubstitute()
        {
            //Arrange
            const int ID = 1;

            var repository = Substitute.For<IProjectRepository>();
            var mediator = Substitute.For<IMediator>();

            repository.CreateProject(Arg.Any<Project>()).Returns(Task.FromResult(ID));

            var command = new InsertProjectCommand
            {
                Title = "Projeto A",
                Description = "Descrição do projeto.",
                TotalCost = 20000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var handler = new InsertProjectCommandHandler(repository, mediator);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(ID, result.Data);
            await repository.Received(1).CreateProject(Arg.Any<Project>());
        }
    }
}
