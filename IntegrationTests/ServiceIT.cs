using AutoMapper;
using backend1;
using backend1.Data;
using backend1.Data.Repository;
using backend1.Models;
using backend1.Services;

namespace IntegrationTests
{
    public class ServiceIT
    {
       /* [Fact]
        public async void GetChildren_TwoChildrenAdded_ReturnsListWithTwoChildren_INTEGRATION()
        {
            // ARRANGE
            var martinaModel = new ChildModel()
            {

                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatianaModel = new ChildModel()
            {

                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var connectionString = builder.Configuration.GetConnectionString("ChildrenWithCourageConnectionString");
            //builder.Services.AddDbContext<ChildrenWithCourageDBContext>(x => x.UseSqlServer(connectionString));
            var ctx = new ChildrenWithCourageDBContext(x => x.UseSqlServer(connectionString));
            var repositoryMock = new ChildrenWithCourageAppRepository(ctx);
            var childService = new ChildService(repositoryMock, mapper);

            // Act
            var mart = await childService.CreateChildAsync(martinaModel);
            await childService.CreateChildAsync(tatianaModel);
            var listChildren = await childService.GetChildrenAsync();


            // ASSERT
            Assert.Equal(2, listChildren.Count());
        }*/
    }
}