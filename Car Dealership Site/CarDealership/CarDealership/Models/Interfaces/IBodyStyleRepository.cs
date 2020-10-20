using CarDealership.UI.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IBodyStyleRepository
    {
        List<BodyStyle> RetrieveAll();

        BodyStyle RetrieveOne(int id);
    }
}
