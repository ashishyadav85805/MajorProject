using System;
using System.Collections.Generic;
using System.Text;

using Xunit;
using Xunit.Abstractions;
using Moq;
using Microsoft.Extensions.Logging;
using NGOManagementSystem.Controllers;
using NGOManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using System.Linq;

namespace NGO.xUnitTestProject
{
    public partial class CategoriesApiTests
    {
        [Fact]
        public void GetCategoryById_NotFoundResult()
        {
            // ARRANGE
            var dbName = nameof(CategoriesApiTests.GetCategoryById_NotFoundResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 900;

            // ACT
            IActionResult actionResultGet = controller.GetCategory(findCategoryID).Result;

            // ASSERT - check if the IActionResult is NotFound 
            Assert.IsType<NotFoundResult>(actionResultGet);

            // ASSERT - check if the Status Code is (HTTP 404) "NotFound"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound;
            var actualStatusCode = (actionResultGet as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_BadRequestResult()
        {
            // ARRANGE
            var dbName = nameof(CategoriesApiTests.GetCategoryById_BadRequestResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!

            var controller = new CategoriesController(dbContext, logger);
            int? findCategoryID = null;

            // ACT
            IActionResult actionResultGet = controller.GetCategory(findCategoryID).Result;

            // ASSERT - check if the IActionResult is BadRequest
            Assert.IsType<BadRequestResult>(actionResultGet);

            // ASSERT - check if the Status Code is (HTTP 400) "BadRequest"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            var actualStatusCode = (actionResultGet as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_OkResult()
        {
            // ARRANGE
            var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!

            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 2;

            // ACT
            IActionResult actionResultGet = controller.GetCategory(findCategoryID).Result;

            // ASSERT - if IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultGet);

            // ASSERT - if Status Code is HTTP 200 (Ok)
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionResultGet as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_CorrectResult()
        {
            // ARRANGE
            var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var controller = new CategoriesController(dbContext, logger);

            int findCategoryID = 2;
            Category expectedCategory = DbContextMocker.TestData_Categories
                                        .SingleOrDefault(c => c.CategoryId == findCategoryID);

            // ACT
            IActionResult actionResultGet = controller.GetCategory(findCategoryID).Result;

            // ASSERT - if IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultGet);

            // ASSERT - if IActionResult (i.e., OkObjectResult) contains an object of the type Category
            OkObjectResult okResult = actionResultGet.Should().BeOfType<OkObjectResult>().Subject;
            Assert.IsType<Category>(okResult.Value);

            // Extract the category object from the result.
            Category actualCategory = okResult.Value.Should().BeAssignableTo<Category>().Subject;
            _testOutputHelper.WriteLine($"Found: CategoryID == {actualCategory.CategoryId}");

            // ASSERT - if category is NOT NULL
            Assert.NotNull(actualCategory);

            // ASSERT - if the CategoryId is containing the expected data.
            Assert.Equal<int>(expected: expectedCategory.CategoryId, 
                              actual: actualCategory.CategoryId);

            // ASSERT - if the CateogoryName is correct 
            Assert.Equal(expectedCategory.CategoryName, actualCategory.CategoryName);
        }
    }
}
