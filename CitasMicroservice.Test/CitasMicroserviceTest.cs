using AutoMapper;
using CitasMicroservice.Api.DTOs;
using CitasMicroservice.Application.Services;
using CitasMicroservice.Domain.Entities;
using CitasMicroservice.Infrastructure.Repository;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CitasMicroservice.Test
{
    [TestFixture]
    public class CitaServiceTests
    {
        private Mock<ICitaRepository> _mockCitaRepository;
        private CitaService _citaService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mockCitaRepository = new Mock<ICitaRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Cita, CitaDTO>().ReverseMap();
            });
            _mapper = config.CreateMapper();

            _citaService = new CitaService(_mockCitaRepository.Object, _mapper);
        }

        // Prueba para GetById
        [Test]
        public async Task GetById_ShouldReturnCitaDTO()
        {
            // Arrange
            var cita = new Cita { Id = 1, IdPaciente = 123, Estado = "Pendiente" };
            _mockCitaRepository.Setup(repo => repo.GetById(1)).ReturnsAsync(cita);

            // Act
            var result = await _citaService.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Pendiente", result.Estado);
        }

        [Test]
        public async Task GetById_ShouldReturnNull_WhenCitaNotFound()
        {
            // Arrange
            _mockCitaRepository.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Cita)null);

            // Act
            var result = await _citaService.GetById(1);

            // Assert
            Assert.IsNull(result);
        }

        // Prueba para Create
        [Test]
        public async Task Create_ShouldReturnSuccessMessage()
        {
            // Arrange
            var citaDto = new CitaDTO { Paciente = "Daniel", Medico = "Kevin", Fecha_Hora = System.DateTime.Now };
            _mockCitaRepository.Setup(repo => repo.Create(It.IsAny<Cita>())).ReturnsAsync("Success");

            // Act
            var result = await _citaService.Create(citaDto);

            // Assert
            Assert.AreEqual("Success", result);
            _mockCitaRepository.Verify(repo => repo.Create(It.Is<Cita>(c => c.Estado == "Pendiente")), Times.Once);
        }

        // Prueba para Update
        [Test]
        public async Task Update_ShouldReturnUpdatedMessage()
        {
            // Arrange
            var citaDto = new CitaDTO { Paciente = "Daniel", Medico = "Kevin" };
            _mockCitaRepository.Setup(repo => repo.Update(It.IsAny<int>(), It.IsAny<Cita>())).ReturnsAsync("Updated");

            // Act
            var result = await _citaService.Update(1, citaDto);

            // Assert
            Assert.AreEqual("Updated", result);
            _mockCitaRepository.Verify(repo => repo.Update(1, It.Is<Cita>(c => c.Paciente == "Daniel")), Times.Once);
        }

        // Prueba para Delete
        [Test]
        public async Task Delete_ShouldReturnDeletedMessage()
        {
            // Arrange
            _mockCitaRepository.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync("Deleted");

            // Act
            var result = await _citaService.Delete(1);

            // Assert
            Assert.AreEqual("Deleted", result);
            _mockCitaRepository.Verify(repo => repo.Delete(1), Times.Once);
        }
    }
}
