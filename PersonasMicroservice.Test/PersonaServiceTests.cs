using AutoMapper;
using Moq;
using NUnit.Framework;
using PersonasMicroservice.Application.Mappings;
using PersonasMicroservice.Application.Services;
using PersonasMicroservice.Domain.Entities;
using PersonasMicroservice.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonasMicroservice.Test
{
    [TestFixture]
    public class PersonaServiceTests
    {
        private Mock<IPersonaRepository> _mockPersonaRepository;
        private PersonaService _personaService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            _mockPersonaRepository = new Mock<IPersonaRepository>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile(new PersonaProfile()));
            _mapper = config.CreateMapper();

            _personaService = new PersonaService(_mockPersonaRepository.Object, _mapper);
        }

        [Test]
        public async Task GetAll_ShouldReturnListOfPersonas()
        {
            // Arrange (implícito en Setup)
            _mockPersonaRepository.Setup(repo => repo.GetAll())
                .ReturnsAsync(new List<Persona>
                {
                new Persona { Id = 1, Nombre = "Juan", IdTipoPersona = 1 },
                new Persona { Id = 2, Nombre = "Ana", IdTipoPersona = 2 }
                });

            // Act
            var result = await _personaService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Juan", result[0].Nombre);
        }
    }
}
