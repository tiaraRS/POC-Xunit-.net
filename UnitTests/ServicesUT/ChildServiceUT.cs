using AutoMapper;
using backend1;
using backend1.Data;
using backend1.Data.Entity;
using backend1.Data.Repository;
using backend1.Models;
using backend1.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ServicesUT
{
    //https://stackoverflow.com/questions/45409622/net-core-how-to-unit-test-service
    public class ChildServiceUT:BaseTest
    {

         [Fact]
         public async void GetChildren_TwoChildrenAdded_ReturnsListWith2Children()
         {
            // ARRANGE
             var martina = new ChildEntity()
             {
                 Id=1,
                 ChildName = "Martina",
                 BirthDate = new DateTime(2007, 3, 5)
             };
             var tatiana = new ChildEntity()
             {
                 Id = 2,
                 ChildName = "Tatiana",
                 BirthDate = new DateTime(2007, 3, 5)
             };            
             var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
             var mapper = config.CreateMapper();
             var enumerable = new List<ChildEntity>() { martina, tatiana } as IEnumerable<ChildEntity>;             
             var repositoryMock = new Mock<IChildrenWithCourageAppRepository>();             
             repositoryMock.Setup(r => r.GetChildrenAsync()).ReturnsAsync(enumerable);
             var childService = new ChildService(repositoryMock.Object, mapper);

             // ACT 
             var listChildren = await childService.GetChildrenAsync();
            var lastChildId = listChildren.Last().Id;

            // ASSERT
            Assert.NotEmpty(listChildren);
            Assert.Equal(2, lastChildId);
        }

        [Fact]
        public async void CreateChild_ChildAdded_AddsChild()
        {
            // ARRANGE
            var tatianaEntity = new ChildEntity()
            {
                Id = 1,
                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatianaModel = new ChildModel()
            {                
                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>());
            var mapper = config.CreateMapper();
            var repositoryMock = new Mock<IChildrenWithCourageAppRepository>();
            repositoryMock.Setup(r => r.CreateChild(tatianaEntity));
            repositoryMock.Setup(r => r.SaveChangesAsync()).ReturnsAsync(true);
            var childService = new ChildService(repositoryMock.Object, mapper);

            // ACT 
            var childModelAdded = await childService.CreateChildAsync(tatianaModel);
            var childId = childModelAdded.Id;
            var childName = childModelAdded.ChildName;
            var childBirthDate = childModelAdded.BirthDate;

            // ASSERT
            //Assert.Equal(1, childId);
            Assert.Equal(new DateTime(2007, 3, 5), childBirthDate);
            Assert.Equal("Tatiana", childModelAdded.ChildName);  
            
        }
    }
}
