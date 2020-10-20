using CarDealership.Data.Repositories;
using CarDealership.Models.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Tests
{
    [TestFixture]
    public class SpecialTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            if (new SpecialRepositoryMock().RetrieveOne(id).SpecialTitle != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }

        [Test]
        public void CanCreate()
        {
            SpecialRepositoryMock repo = new SpecialRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Special());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((count + 1), newCount );
        }
    }
}