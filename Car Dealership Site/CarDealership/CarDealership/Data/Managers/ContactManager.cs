using CarDealership.Models.Classes;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Managers
{
    public class ContactManager : IContactRepository
    {
        private static IContactRepository repos;
        public ContactManager (IContactRepository repo)
        {
            repos = repo;
        }
        public List<Contact> Create(Contact contact)
        {
            return repos.Create(contact);
        }

        public List<Contact> RetrieveAll()
        {
            return repos.RetrieveAll();
        }
    }
}