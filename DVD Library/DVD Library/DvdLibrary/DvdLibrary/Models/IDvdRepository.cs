using DvdLibrary.Models.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibrary.Models
{
    public interface IDvdRepository
    {
        List<Dvd> RetrieveAll();
        Dvd RetrieveById(int id);
        List<Dvd> RetrieveByTitle(string title);
        List<Dvd> RetrieveByYear(int year);
        List<Dvd> RetrieveByName(string name);
        List<Dvd> RetrieveByRating(string rating);
        List<Dvd> Create(Dvd dvd);
        List<Dvd> Update(Dvd dvd);
        List<Dvd> Delete(int id);
    }
}
