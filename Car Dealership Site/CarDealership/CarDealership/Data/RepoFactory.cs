using CarDealership.Data.Managers;
using CarDealership.Data.Repositories;
using CarDealership.UI.Data.Managers;
using CarDealership.UI.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data
{
    public class RepoFactory
    {
        private string mode = ConfigurationManager.AppSettings["Mode"].ToString();

        public VehicleManager VehicleFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new VehicleManager(new VehicleRepositoryMock());
                case "PROD":
                    return new VehicleManager(new VehicleRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public ColorManager ColorFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new ColorManager(new ColorRepositoryMock());
                case "PROD":
                    return new ColorManager(new ColorRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public BodyStyleManager BodyStyleFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new BodyStyleManager(new BodyStyleRepositoryMock());
                case "PROD":
                    return new BodyStyleManager(new BodyStyleRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public InteriorManager InteriorFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new InteriorManager(new InteriorRepositoryMock());
                case "PROD":
                    return new InteriorManager(new InteriorRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public MakeManager MakeFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new MakeManager(new MakeRepositoryMock());
                case "PROD":
                    return new MakeManager(new MakeRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public ModelManager ModelFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new ModelManager(new ModelRepositoryMock());
                case "PROD":
                    return new ModelManager(new ModelRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
        public PurchaseManager PurchaseFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new PurchaseManager(new PurchaseRepositoryMock());
                case "PROD":
                    return new PurchaseManager(new PurchaseRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }

        public SpecialManager SpecialFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new SpecialManager(new SpecialRepositoryMock());
                case "PROD":
                    return new SpecialManager(new SpecialRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }

        public ContactManager ContactFactory()
        {
            switch (mode)
            {
                case "QA":
                    return new ContactManager(new ContactRepositoryMock());
                case "PROD":
                    return new ContactManager(new ContactRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
    }
}