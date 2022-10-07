using AutoMapper;
using backend1.Data;
using backend1.Data.Entity;
using backend1.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Config
{
    public class DBContextUT:BaseTest
    {
        [Fact]
        public void CreateChildren_AddChildToContext_ChangesDBState()
        {
            var childEntity = new ChildEntity() { ChildName = "Juana", BirthDate = DateTime.Now };
            
            var childEntityAdded = ctx.Add(childEntity);
            var changesMade = ctx.SaveChanges();

            Assert.Equal(1, changesMade); 
            Assert.Equal(1,childEntityAdded.Entity.Id);
        }

        [Fact]
        public async Task GetChildren_Get1ChildFormContext_ReturnsSetWith1ChildFromDB()
        {
            var childEntity = new ChildEntity() { ChildName = "Juana", BirthDate = DateTime.Now };
            var childEntityAdded = ctx.Add(childEntity);
            var changesMade = ctx.SaveChanges();

            var children = await ctx.Children.ToListAsync() ;
            var numberOfChildren = children.Count();
            
            Assert.Equal(1, numberOfChildren);
        }

        [Fact]
        public async Task GetChildren_Get1ChildFormContext_ReturnsSetWith1ChildFromDBWithCorrectData()
        {
            var childEntity = new ChildEntity() { ChildName = "Juana", BirthDate = DateTime.Now };
            var childEntityAdded = ctx.Add(childEntity);
            var changesMade = ctx.SaveChanges();

            var children = await ctx.Children.ToListAsync();
            var numberOfChildren = children.Count();
            var juanaName = children.First().ChildName;

            Assert.Equal("Juana", juanaName);
        }
        [Fact]
        public async Task GetChildren_GetChildrenFormContext_ReturnsSetWithChildrenFromDB()
        {
            var childEntity1 = new ChildEntity() { ChildName = "Juana", BirthDate = DateTime.Now };
            var childEntity2 = new ChildEntity() { ChildName = "Mateo", BirthDate = DateTime.Now };
            var childEntity3 = new ChildEntity() { ChildName = "Valeria", BirthDate = DateTime.Now };
            ctx.Add(childEntity1);
            ctx.Add(childEntity2);
            ctx.Add(childEntity3);
            ctx.SaveChanges();

            var children = await ctx.Children.ToListAsync();
            var numberOfChildren = children.Count();

            Assert.Equal(3, numberOfChildren);
        }       
    }
}
