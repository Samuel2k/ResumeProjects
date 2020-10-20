using CarDealership.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> Create(Special special);
        Special RetrieveOne(int id);
        List<Special> RetrieveAll();
        List<Special> Delete(int id);
    }
}
