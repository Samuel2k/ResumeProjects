using CarDealership.Models.Classes;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.Data.Repositories
{
    public class ContactRepositoryMock : IContactRepository
    {
        private static List<Contact> list = new List<Contact>
        {
            new Contact {ContactId = 0, Email = "John@Apple.John", Message = "Please give me your car", Name = "Johnny Appleseed", Phone = "111-222-3333" }
        
        };
        public List<Contact> Create(Contact contact)
        {
            contact.ContactId = list.Max(x => x.ContactId) + 1;
            list.Add(contact);
            return list;
        }

        public List<Contact> RetrieveAll()
        {
            return list;
        }
    }
}