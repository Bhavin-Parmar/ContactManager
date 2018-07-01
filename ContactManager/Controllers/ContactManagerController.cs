using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.Controllers
{
    public class ContactManagerController : ApiController
    {
        private readonly IContactStore contactStore;

        /// <summary>
        /// Construction with parameter to inject dependancy
        /// </summary>
        /// <param name="store"></param>
        public ContactManagerController(IContactStore store)
        {
            contactStore = store;
        }

        /// <summary>
        /// gets all the available contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contact> Get()
        {
            return contactStore.Get();
        }


        /// <summary>
        /// Gets a contact by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact Get(int id)
        {
            var contact = contactStore.Get(id);
            if (contact == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return contact;
        }

        /// <summary>
        /// Add a new contact.
        /// </summary>
        /// <param name="contact">Contact to add.</param>
        /// <returns>The added contact</returns>
        public HttpResponseMessage Post(Contact contact)
        {
            if (this.ModelState.IsValid)
            {
                bool issuccess = contactStore.Post(contact);
                if(issuccess)
                return Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);                               
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Update an existing contact.
        /// </summary>
        /// <param name="id">Contact ID.</param>
        /// <param name="contact">Contact update.</param>
        /// <returns>the updated contact.</returns>
        public Contact Put(int id, Contact contact)
        {
            contact.ContactId = id;
            contactStore.Update(contact);
            return contact;
        }

        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="id">Contact ID.</param>
        /// <returns>The deleted contact.</returns>
        public Contact Delete(int id)
        {
            var deleted = contactStore.Get(id);
            if (deleted == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            contactStore.Delete(id);
            return deleted;
        }
    }
}
