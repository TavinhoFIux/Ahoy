using Xunit;
using Moq;
using FluentAssertions;
using Domain.Repositorys;
using Domain.Entitys;
using Application.NoticiaCommands.Commands;
using Application.NoticiaCommands.Handlers;
using FluentValidation;

namespace Tests.Application.NoticiaCommandTest
{
    public class CreateNoticiaCommandHandlerTests
    {
        private readonly Mock<IRepository<Usuario>> _repositoryUsuarioMock;
        private readonly Mock<INoticiaRepository> _repositoryNoticiaMock;
        private readonly CreateNoticiaHandler _handler;

        public CreateNoticiaCommandHandlerTests()
        {
            _repositoryUsuarioMock = new Mock<IRepository<Usuario>>();
            _repositoryNoticiaMock = new Mock<INoticiaRepository>();

            _handler = new CreateNoticiaHandler(
                _repositoryNoticiaMock.Object,
                _repositoryUsuarioMock.Object
            );
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldReturnNoticiaId()
        {
            // Arrange
            var command = new CreateNoticiaCommand
            {
                Titulo = "Nova Noticia",
                Texto = "Conteúdo",
                TagIds = new List<int> { 1, 2, 3 }
            };

            var usuario = new Usuario("Admin", "admin@example.com", "admin123", 1);
            _repositoryUsuarioMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);

            var noticia = new Noticia("Nova Noticia", "Conteúdo", usuario.Id);
            _repositoryNoticiaMock.Setup(r => r.AddNoticiaWithTagsAsync(It.IsAny<Noticia>(), It.IsAny<List<int>>())).ReturnsAsync(noticia);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(noticia.Id);
            _repositoryUsuarioMock.Verify(r => r.GetByIdAsync(1), Times.Once);
            _repositoryNoticiaMock.Verify(r => r.AddNoticiaWithTagsAsync(It.IsAny<Noticia>(), command.TagIds), Times.Once);
        }

        [Fact]
        public async Task Handle_UserNotFound_ShouldThrowException()
        {
            // Arrange
            var command = new CreateNoticiaCommand
            {
                Titulo = "Nova Noticia",
                Texto = "Conteúdo",
                TagIds = new List<int> { 1, 2, 3 }
            };

            _repositoryUsuarioMock.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Usuario)null);

            // Act
            Func<Task> act = () => _handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Não existe usuarios cadastrado na base de dados");
            _repositoryUsuarioMock.Verify(r => r.GetByIdAsync(1), Times.Once);
            _repositoryNoticiaMock.Verify(r => r.AddNoticiaWithTagsAsync(It.IsAny<Noticia>(), It.IsAny<List<int>>()), Times.Never);
        }

        [Fact]
        public void Handle_InvalidCommand_ShouldThrowValidationException()
        {
            // Arrange
            var command = new CreateNoticiaCommand();

            // Act
            Func<Task> act = () => _handler.Handle(command, CancellationToken.None);

            // Assert
            act.Should().ThrowAsync<ValidationException>();
            _repositoryUsuarioMock.Verify(r => r.GetByIdAsync(It.IsAny<int>()), Times.Never);
            _repositoryNoticiaMock.Verify(r => r.AddNoticiaWithTagsAsync(It.IsAny<Noticia>(), It.IsAny<List<int>>()), Times.Never);
        }
    }
}
