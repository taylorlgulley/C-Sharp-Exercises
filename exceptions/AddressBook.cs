using System;
using System.Collections.Generic;

namespace exceptions
{
    class AddressBook
    {
        Dictionary<string, Contact> ContactList = new Dictionary<string, Contact>();
        public void AddContact(Contact contact)
        {
            try
            {
            ContactList.Add(contact.Email, contact);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // ContactList.Add(contact.Email, contact);
        }
        public Contact GetByEmail(string email)
        {
            // return ContactList.ContainsKey(email);
            return ContactList[email];
        }
    }
}