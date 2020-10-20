using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models
{
    public class RepoManager : IDvdRepository
    {
        private IDvdRepository repos;
        public RepoManager(IDvdRepository repo)
        {
            repos = repo;
        }
        public List<Dvd> Create(Dvd dvd)
        {
            return repos.Create(dvd);
        }

        public List<Dvd> Delete(int id)
        {
            return repos.Delete(id);
        }

        public List<Dvd> RetrieveAll()
        {
            return repos.RetrieveAll();
        }

        public Dvd RetrieveById(int id)
        {
            return repos.RetrieveById(id);
        }

        public List<Dvd> RetrieveByName(string name)
        {
            return repos.RetrieveByName(name);
        }

        public List<Dvd> RetrieveByRating(string rating)
        {
            return repos.RetrieveByRating(rating);
        }

        public List<Dvd> RetrieveByTitle(string title)
        {
            return repos.RetrieveByTitle(title);
        }

        public List<Dvd> RetrieveByYear(int year)
        {
            return repos.RetrieveByYear(year);
        }

        public List<Dvd> Update(Dvd dvd)
        {
            return repos.Update(dvd);
        }
    }
}