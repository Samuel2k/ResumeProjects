using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models.Repos
{
    public class DvdLibraryEntities : DbContext
    {
        public DvdLibraryEntities()
        : base("DvdEntity")
        {
        }
        public DbSet<Dvd> Dvds { get; set; }
    }

    public class DvdRepositoryEF : IDvdRepository
    {
        public List<Dvd> Create(Dvd dvd)
        {
            var repos = new DvdLibraryEntities();
            repos.Dvds.Add(dvd);
            repos.SaveChanges();
            return repos.Dvds.ToList();
        }

        public List<Dvd> Delete(int id)
        {
            var repos = new DvdLibraryEntities();
            repos.Dvds.Remove(repos.Dvds.FirstOrDefault(x => x.DvdId == id));
            repos.SaveChanges();
            return repos.Dvds.ToList();
        }

        public List<Dvd> RetrieveAll()
        {
            var repos = new DvdLibraryEntities();
            return repos.Dvds.ToList();
        }

        public Dvd RetrieveById(int id)
        {
            var repos = new DvdLibraryEntities();
            return repos.Dvds.FirstOrDefault(x => x.DvdId == id);
        }

        public List<Dvd> RetrieveByName(string name)
        {
            var repos = new DvdLibraryEntities();
            List<Dvd> list = repos.Dvds.Where(x => x.Director == name).ToList();
            return list;
        }

        public List<Dvd> RetrieveByRating(string rating)
        {
            var repos = new DvdLibraryEntities();
            List<Dvd> list = repos.Dvds.Where(x => x.Rating == rating).ToList();
            return list;
        }

        public List<Dvd> RetrieveByTitle(string title)
        {
            var repos = new DvdLibraryEntities();
            List<Dvd> list = repos.Dvds.Where(x => x.Title == title).ToList();
            return list;
        }

        public List<Dvd> RetrieveByYear(int year)
        {
            var repos = new DvdLibraryEntities();
            List<Dvd> list = repos.Dvds.Where(x => x.RealeaseYear == year).ToList();
            return list;
        }

        public List<Dvd> Update(Dvd dvd)
        {
            var repos = new DvdLibraryEntities();
            repos.Dvds.Remove(repos.Dvds.FirstOrDefault(x => x.DvdId == dvd.DvdId));
            repos.SaveChanges();
            repos.Dvds.Add(dvd);
            repos.SaveChanges();
            return repos.Dvds.ToList();
        }
    }
}