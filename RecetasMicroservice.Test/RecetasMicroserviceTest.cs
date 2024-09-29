using AutoMapper;
using Moq;
using NUnit.Framework;
using RecetasMicroservice.Application.DTOs;
using RecetasMicroservice.Application.Services;
using RecetasMicroservice.Domain.Entities;
using RecetasMicroservice.Infrastructure.Repository;
using System.Threading.Tasks;

namespace RecetasMicroservice.Test
{
    [TestFixture]
    public class RecetaServiceTests
    {
        private Mock<IRecetaRepository> _mockRecetaRepository;
        private RecetaService _recetaService;
        private IMapper _mapper;
        private IPersonaService _personaService;
        private ICitaService _citaService;

        [SetUp]
        public void Setup()
        {
            _mockRecetaRepository = new Mock<IRecetaRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Receta, RecetaDTO>().ReverseMap();
                cfg.CreateMap<Medicamento, MedicamentoDTO>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            _recetaService = new RecetaService(_mockRecetaRepository.Object, _personaService, _citaService, _mapper);
        }

        // Prueba para GetById
        [Test]
        public async Task GetById_ShouldReturnRecetaDTO()
        {
            // Arrange
            var receta = new Receta { Id = 1, Paciente = "Juan Perez", Medico = "Dr. Lopez" };
            _mockRecetaRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(receta);

            // Act
            var result = await _recetaService.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Juan Perez", result.Paciente);
        }

        [Test]
        public async Task GetById_ShouldReturnNull_WhenRecetaNotFound()
        {
            // Arrange
            _mockRecetaRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Receta)null);

            // Act
            var result = await _recetaService.GetById(1);

            // Assert
            Assert.IsNull(result);
        }

        // Prueba para Create
        [Test]
        public async Task Create_ShouldReturnSuccessMessage()
        {
            // Arrange
            var recetaDto = new RecetaDTO { Paciente = "Ana Maria", Medico = "Dr. Gomez", Fecha_Emision = System.DateTime.Now };
            _mockRecetaRepository.Setup(repo => repo.Create(It.IsAny<Receta>())).ReturnsAsync("Success");

            // Act
            var result = await _recetaService.Create(recetaDto);

            // Assert
            Assert.AreEqual("Success", result);
            _mockRecetaRepository.Verify(repo => repo.Create(It.Is<Receta>(r => r.Paciente == "Ana Maria")), Times.Once);
        }

        // Prueba para Update
        [Test]
        public async Task Update_ShouldReturnUpdatedMessage()
        {
            // Arrange
            var recetaDto = new RecetaDTO { Paciente = "Carlos Diaz", Medico = "Dr. Martinez", Fecha_Emision = System.DateTime.Now };
            _mockRecetaRepository.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Receta>())).ReturnsAsync("Updated");

            // Act
            var result = await _recetaService.Update(1, recetaDto);

            // Assert
            Assert.AreEqual("Updated", result);
            _mockRecetaRepository.Verify(repo => repo.Update(1, It.Is<Receta>(r => r.Paciente == "Carlos Diaz")), Times.Once);
        }

        // Prueba para Delete
        [Test]
        public async Task Delete_ShouldReturnDeletedMessage()
        {
            // Arrange
            _mockRecetaRepository.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync("Deleted");

            // Act
            var result = await _recetaService.Delete(1);

            // Assert
            Assert.AreEqual("Deleted", result);
            _mockRecetaRepository.Verify(repo => repo.Delete(1), Times.Once);
        }
    }
}
