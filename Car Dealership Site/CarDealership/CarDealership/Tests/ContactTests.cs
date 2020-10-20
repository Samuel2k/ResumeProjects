using CarDealership.Data.Repositories;
using CarDealership.Models.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Tests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void CanCreate()
        {
            ContactRepositoryMock repo = new ContactRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Contact());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((1 + count), newCount);
        }
    }
}