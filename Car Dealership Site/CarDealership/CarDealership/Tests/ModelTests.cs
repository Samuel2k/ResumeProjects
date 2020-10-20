using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Tests
{
    [TestFixture]
    public class ModelTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            if (new ModelRepositoryMock().RetrieveOne(id).ModelName != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }

        [Test]
        public void CanCreate()
        {
            ModelRepositoryMock repo = new ModelRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Model());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((count + 1), newCount);
        }
    }
}