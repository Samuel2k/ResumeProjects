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
    public class MakeTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            if (new MakeRepositoryMock().RetrieveOne(id).MakeName != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }

        [Test]
        public void CanCreate()
        {
            MakeRepositoryMock repo = new MakeRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Make());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((1 + count), newCount);
        }
    }
}