using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibrary.Models.Repos
{
    public class DvdRepositoryMock : IDvdRepository
    {
        public DvdRepositoryMock()
        {
            if (list == null)
            {
                list = new List<Dvd>
                {
                    new Dvd { Director = "Fred Jones", DvdId = 0, Notes = "Cool movie.", Rating = "R", Title = "Test DVD 1", RealeaseYear = 1999},
                    new Dvd { Director = "Fred Johnson", DvdId = 1, Notes = "Cool movie.", Rating = "PG-13", Title = "Test DVD 2", RealeaseYear = 1999},
                    new Dvd { Director = "Egg John", DvdId = 2, Notes = "Cool movie.", Rating = "R", Title = "Test DVD 3", RealeaseYear = 2001}
                };
            }
        }

        private static List<Dvd> list;

        public List<Dvd> Create(Dvd dvd)
        {
            dvd.DvdId = list.Max(c => c.DvdId) + 1;
            list.Add(dvd);
            return list;
        }

        public List<Dvd> Delete(int id)
        {
            foreach (Dvd dvd in list)
            {
                if (id == dvd.DvdId)
                {
                    list.Remove(dvd);
                    break;
                }
            }
            return list;
        }

        public List<Dvd> RetrieveAll()
        {
            return list;
        }

        public Dvd RetrieveById(int id)
        {

            Dvd newDvd = new Dvd();

            foreach (Dvd dvd in list)
            {
                if (id == dvd.DvdId)
                {
                    newDvd = dvd;
                    break;
                }
            }
            return newDvd;
        }

        public List<Dvd> RetrieveByName(string name)
        {
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Director.Contains(name))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByRating(string rating)
        {
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Rating.Contains(rating))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByTitle(string title)
        {
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.Title.Contains(title))
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> RetrieveByYear(int year)
        {
            List<Dvd> newList = new List<Dvd>();
            foreach (Dvd dvd in list)
            {
                if (dvd.RealeaseYear == year)
                {
                    newList.Add(dvd);
                }
            }
            return newList;
        }

        public List<Dvd> Update(Dvd dvd)
        {
            list.Remove(list.FirstOrDefault(x => x.DvdId == dvd.DvdId));
            list.Add(dvd);
            return list;
        }
    }
}