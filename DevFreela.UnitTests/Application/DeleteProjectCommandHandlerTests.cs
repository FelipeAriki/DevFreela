using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application
{
    public class DeleteProjectCommandHandlerTests
    {
        [Fact]
        public async Task ProjectExists_Delete_Success_NSubstitute()
        {
            //Arrange
            const int ID = 1;
            var project = new Project("Projeto A", "Descrição do Projeto", 1, 2, 10000);
            var repository = Substitute.For<IProjectRepository>();

            repository.GetProjectById(ID).Returns(Task.FromResult((Project?)project));
            repository.UpdateProject(Arg.Any<Project>()).Returns(Task.CompletedTask);

            var handler = new DeleteProjectCommandHandler(repository);
            var command = new DeleteProjectCommand(ID);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            await repository.Received(ID).GetProjectById(ID);
            await repository.Received(ID).UpdateProject(Arg.Any<Project>());
        }

        [Fact]
        public async Task ProjectDoesNotExist_Delete_Error_NSubstitute()
        {
            //Arrange
            var repository = Substitute.For<IProjectRepository>();

            repository.GetProjectById(Arg.Any<int>()).Returns(Task.FromResult((Project?)null));
            var handler = new DeleteProjectCommandHandler(repository);
            var command = new DeleteProjectCommand(1);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Projeto não existe.", result.Message);

            await repository.Received(1).GetProjectById(Arg.Any<int>());
            await repository.DidNotReceive().UpdateProject(Arg.Any<Project>());
        }
    }
}
