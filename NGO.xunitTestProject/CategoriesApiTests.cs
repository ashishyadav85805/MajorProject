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


// NOTE:
// Add the following NuGet PACKAGES:
//      FluentAssertions                            (latest version)
//      Moq                                         (latest version)
//      Microsoft.EntityFrameworkCore.InMemory      (same version as EFCore in the LMS.Web project
// Also add REFERENCE to the LMS.Web Project

namespace NGO.xUnitTestProject
{
    public partial class CategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CategoriesApiTests(
            ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

    }
}
