using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jewson.BranchData.WebApi.Data;
using Jewson.BranchData.WebApi.Tests.Data;
using System.Linq;

namespace Jewson.BranchData.WebApi.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void BranchRepository_GetAll_OK()
        {
            // Arrange
            TestJsonDataService json = new TestJsonDataService();
            BranchRepository repo = new BranchRepository(json);

            // Act
            var branchItems = repo.GetAll();

            // Assert
            Assert.IsNotNull(branchItems, "GetAll returned null data");
            Assert.IsTrue(branchItems.Count() == 2, "GetAll returned wrong number of records");
        }

        [TestMethod]
        public void BranchRepository_GetBranchByNumber_OK()
        {
            // Arrange
            TestJsonDataService json = new TestJsonDataService();
            BranchRepository repo = new BranchRepository(json);

            int testID = 102;

            // Act
            var branchItem = repo.GetBranchByNumber(testID);

            // Assert
            Assert.IsNotNull(branchItem, "GetBranchByNumber returned null data");
            Assert.AreEqual(testID, branchItem.Number, "GetBranchByNumber returned wrong record");
        }

        [TestMethod]
        public void BranchRepository_GetBranchByNumber_NotFound()
        {
            // Arrange
            TestJsonDataService json = new TestJsonDataService();
            BranchRepository repo = new BranchRepository(json);

            int testID = 999;

            // Act
            var branchItem = repo.GetBranchByNumber(testID);

            // Assert
            Assert.IsNull(branchItem, "GetBranchByNumber returned null data");
        }
    }
}
