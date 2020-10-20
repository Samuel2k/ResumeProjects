using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Tests
{
    [TestFixture]
    public class InteriorTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            Interior interior = new InteriorRepositoryMock().RetrieveOne(id);
            if (interior.InteriorName != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }
    }
}