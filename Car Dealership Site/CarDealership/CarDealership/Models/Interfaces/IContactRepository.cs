using CarDealership.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Models.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> Create(Contact contact);
        List<Contact> RetrieveAll();
    }
}