using DvdLibrary.Models.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class RepoFactory
    {
        private string mode = ConfigurationManager.AppSettings["Mode"].ToString();
        public RepoManager OrderFactory()
        {
            switch (mode)
            {
                case "SampleData":
                    return new RepoManager(new DvdRepositoryMock());
                case "EntityFramework":
                    return new RepoManager(new DvdRepositoryEF());
                case "ADO":
                    return new RepoManager(new DvdRepositoryADO());
                default:
                    throw new Exception("Mode value in web config is not valid");
            }
        }
    }
}