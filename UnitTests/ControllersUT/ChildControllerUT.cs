using AutoMapper;
using backend1;
using backend1.Controllers;
using backend1.Data.Entity;
using backend1.Data.Repository;
using backend1.Models;
using backend1.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.ControllersUT
{
    public class ChildControllerUT
    {
        [Fact]
        public async void GetChildren_TwoChildrenAdded_ReturnsListWith2Children()
        {
            // ARRANGE
            var martina = new ChildModel()
            {
                Id = 1,
                ChildName = "Martina",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var tatiana = new ChildModel()
            {
                Id = 2,
                ChildName = "Tatiana",
                BirthDate = new DateTime(2007, 3, 5)
            };
            var enumerable = new List<ChildModel>() { martina, tatiana } as IEnumerable<ChildModel>;
 
            var serviceMock = new Mock<IChildService>();
            serviceMock.Setup(r => r.GetChildrenAsync()).ReturnsAsync(enumerable);
            var childContoller = new ChildrenController(serviceMock.Object);

            // ACT 
            var response = await childContoller.GetChildrenAsync();
            var status = (OkObjectResult)response.Result;
            var childrenList = status.Value as List<ChildModel>;
            var countChildrenList = childrenList.Count();

            // ASSERT
            Assert.Equal(2, countChildrenList);
            Assert.Equal(200, status.StatusCode);
        }

        
    }
}
