using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class ContactStore : IContactStore
    {
        public bool Delete(int id)
        {
            try
            {
                SampleContact.Contacts.Remove(SampleContact.Contacts.Where(x => x.ContactId == id).First());
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public Contact Get(int id)
        {
            try
            {
              return  SampleContact.Contacts.Where(x => x.ContactId == id).First();
            }
            catch(Exception e)
            {
                return null;
            }             
        }

        public IQueryable<Contact> Get()
        {
            try
            {
                return SampleContact.Contacts.Select(x => x).AsQueryable();
            }
            catch(Exception e)
            {
                return null;
            }  
        }

        public bool Post(Contact contact)
        {
            try
            {
                SampleContact.Contacts.Add(contact);
            }catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Update(Contact updatedContact)
        {
            try
            {
                SampleContact.Contacts.Remove(SampleContact.Contacts.Where(x => x.ContactId == updatedContact.ContactId).First());
                SampleContact.Contacts.Add(updatedContact);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}