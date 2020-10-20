using CarDealership.UI.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Tests
{
    [TestFixture]
    public class ColorTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            if (new ColorRepositoryMock().RetrieveOne(id).ColorName != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }
    }
}