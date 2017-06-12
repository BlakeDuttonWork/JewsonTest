using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jewson.BranchData.WebApi.Tests.Data;
using Jewson.BranchData.WebApi.Data;
using Jewson.BranchData.WebApi.Controllers;
using System.Linq;
using Jewson.BranchData.WebApi.Models;
using System.Web.Http.Results;

namespace Jewson.BranchData.WebApi.Tests
{
    [TestClass]
    public class ControllerTests
    {
        BranchRepository repo;

        public ControllerTests()
        {
            TestJsonDataService json = new TestJsonDataService();
            repo = new BranchRepository(json);
        }

        [TestMethod]
        public void BranchesController_GetBranches_OK()
        {
            // Arrange
            var controller = new BranchesController(repo);

            // Act
            var result = controller.GetBranches();

            // Assert
            Assert.IsNotNull(result, "Controller returned null data");
            Assert.AreEqual(repo.GetAll().Count(), result.Count());
        }

        [TestMethod]
        public void BranchesController_GetBranch_OK()
        {
            // Arrange
            var controller = new BranchesController(repo);
            var branchNumber = 102;

            // Act
            var result = controller.GetBranch(branchNumber) as OkNegotiatedContentResult<Branch>;

            // Assert
            Assert.IsNotNull(result, "Controller returned null data");
            Assert.AreEqual(repo.GetBranchByNumber(branchNumber).Name, result.Content.Name);
        }

        [TestMethod]
        public void BranchesController_GetBranch_NotFound()
        {
            // Arrange
            var controller = new BranchesController(repo);
            var branchNumber = 999;

            // Act
            var result = controller.GetBranch(branchNumber);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
