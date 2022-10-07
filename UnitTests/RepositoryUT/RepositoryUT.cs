using backend1.Data.Entity;
using backend1.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.RepositoryUT
{
    public class RepositoryUT:BaseTest
    {
        [Fact]
        public async void GetChildren_TwoChildrenInDB_ReturnsListWith2Children_UNIT()
        {
            // ARRANGE
            var repository = new ChildrenWithCourageAppRepository(ctx);
            var martina = new ChildEntity()
            {
                Id = 1,
                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatiana = new ChildEntity()
            {
                Id = 2,
                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            ctx.Add(martina);
            ctx.Add(tatiana);
            ctx.SaveChanges();

            // ACT 
            var listChildren = await repository.GetChildrenAsync();
            var numberOfChildren = listChildren.Count();

            // ASSERT
            Assert.Equal(2, numberOfChildren);
            Assert.IsType<ChildEntity>(listChildren.First());
        }

        [Fact]
        public async Task CreateChild_AddChildToDB_ReturnsTrueSavedCorrectly()
        {
            // ARRANGE
            var repository = new ChildrenWithCourageAppRepository(ctx);
            var martina = new ChildEntity()
            {
                Id = 1,
                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatiana = new ChildEntity()
            {
                Id = 2,
                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var miguel = new ChildEntity()
            {
                ChildName = "Miguel",
                BirthDate = new DateTime(2006, 5, 5)
            };
            ctx.Add(martina);
            ctx.Add(tatiana);
            ctx.SaveChanges();

            // ACT 
            repository.CreateChild(miguel);
            var result = await repository.SaveChangesAsync();            

            // ASSERT
            Assert.True(result);
        }
        [Fact]
        public async Task CreateChild_AddChildToEmptyDB_ReturnsTrueSavedCorrectly()
        {
            // ARRANGE
            var repository = new ChildrenWithCourageAppRepository(ctx);            
            var miguel = new ChildEntity()
            {
                ChildName = "Miguel",
                BirthDate = new DateTime(2006, 5, 5)
            };

            // ACT 
            repository.CreateChild(miguel);
            var result = await repository.SaveChangesAsync();

            // ASSERT
            Assert.True(result);
        }
    }
}
