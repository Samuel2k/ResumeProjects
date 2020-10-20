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
    public class PurchaseTests
    { 
        [Test]
        public void CanCreate()
        {
            PurchaseRepositoryMock repo = new PurchaseRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Purchase());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((count + 1), newCount);
        }
    }
}