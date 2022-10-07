using AutoMapper;
using backend1;
using backend1.Data.Entity;
using backend1.Models;
namespace UnitTests.Config
{
    //GOOD PRACTICES: https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    //TESTED METHOD'S NAME, SCENARIO TESTED, EXPECTED BEHAVIOR
    //Arrange (create objects), Act (act on object), Assert(see if it meet expected behavior)
    public class AutomapperUT
    {
        private IMapper _mapper;
        public AutomapperUT()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            _mapper = config.CreateMapper();
        }

        public ChildEntity CreateDefaultChildEntity()
        {
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };
            return childEntity;
        }
        public ChildModel CreateDefaultChildModel()
        {
            var childModel = new ChildModel() { Id = 1, ChildName = "Marco", BirthDate = DateTime.Now };
            return childModel;
        }
       
        [Fact]
        public void AutomapperProfile_ChildModel_ReturnsChildEntity()
        {
            //Arrange
            var childModel = CreateDefaultChildModel();
            var childEntity = new ChildEntity();
            var typeChildEntityType = childEntity.GetType().ToString();            

            //Act
            var actual = _mapper.Map<ChildEntity>(childModel);
            var actualType = actual.GetType().ToString();

            //Assert
            Assert.Equal(typeChildEntityType, actualType);
        }
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModel()
        {
            var childEntity = CreateDefaultChildEntity();
            var childModel = new ChildModel();
            var typeChildModelType = childModel.GetType().ToString();

            var actual = _mapper.Map<ChildModel>(childEntity);
            var actualType = actual.GetType().ToString();

            Assert.Equal(typeChildModelType, actualType);
        }

        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameName()
        {
            var childEntity = CreateDefaultChildEntity();            

            var actual = _mapper.Map<ChildModel>(childEntity);
            
            Assert.Equal("Marco",actual.ChildName);
        }
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameBirthDate()
        {
            var birthDate = new DateTime(2005, 2, 3);
            var childEntity = new ChildEntity() { Id = 1, ChildName = "Marco", BirthDate= birthDate };

            var actual = _mapper.Map<ChildModel>(childEntity);
            var actualBirthDate = actual.BirthDate;

            Assert.Equal(birthDate, actualBirthDate);
        }
        
        [Fact]
        public void AutomapperProfile_ChildEntity_ReturnsChildModelWithSameId()
        {
            var childEntity = CreateDefaultChildEntity();            

            var actual = _mapper.Map<ChildModel>(childEntity);

            Assert.Equal(1, actual.Id);
        }
       
    }
}