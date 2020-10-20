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
    public class VehicleTests
    {
        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanGetOne(int id, bool expectedResult)
        {
            bool success = false;
            Vehicle vehicle = new VehicleRepositoryMock().RetrieveOne(id);
            if (vehicle.Transmission != null)
            {
                success = true;
            }
            Assert.AreEqual(expectedResult, success);
        }

        [Test]
        public void CanCreate()
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Create(new Vehicle());
            int newCount = repo.RetrieveAll().Count();
            Assert.AreEqual((count + 1), newCount);
        }

        [TestCase(-1, false)]
        [TestCase(0, true)]
        public void CanDelete(int id, bool expectedResult)
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            int count = repo.RetrieveAll().Count();
            repo.Delete(id);
            int newCount = repo.RetrieveAll().Count();
            bool success = false;
            if (count == (newCount + 1))
            {
                success = true;
            }

            Assert.AreEqual(expectedResult, success);
        }

        [Test]
        public void CanUpdate()
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            Vehicle vehicle = new Vehicle
            {
                VehicleId = 0,
                Mileage = 30
            };
            repo.Update(vehicle);
            Vehicle testMe = repo.RetrieveOne(0);
            Assert.AreEqual("30 miles", testMe.Mileage);
        }

        [TestCase("r", null, null, null, null, 2)]
        [TestCase("1", null, null, null, null, 2)]
        [TestCase("A1", null, null, null, null, 1)]
        [TestCase("", 20000, null, null, null, 2)]
        [TestCase("", null, 30000, null, null, 2)]
        [TestCase("", null, null, null, 2013, 2)]
        [TestCase("", null, null, 2003, null, 2)]
        [TestCase("", null, null, null, null, 3)]
        public void SearchTests(string bar, int? minPrice, int? maxPrice, int? minYear, int? maxYear, int expectedCount)
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            List<Vehicle> list = repo.Search(bar, minPrice, maxPrice, minYear, maxYear);

            Assert.AreEqual(expectedCount, list.Count());
        }

        [Test]
        public void NewSearchTest()
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            List<Vehicle> list = repo.NewSearch("", null, null, null, null);

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual("New", list[0].Type);
        }

        [Test]
        public void UsedSearchTest()
        {
            VehicleRepositoryMock repo = new VehicleRepositoryMock();
            List<Vehicle> list = repo.UsedSearch("", null, null, null, null);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual("Used", list[0].Type);
            Assert.AreEqual("Used", list[1].Type);
        }
    }
}