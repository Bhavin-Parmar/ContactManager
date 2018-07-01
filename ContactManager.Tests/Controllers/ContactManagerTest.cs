using ContactManager.Controllers;
using ContactManager.Models;
using Ninject;
using NUnit.Framework;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ContactManager.Tests.Controllers
{
    [TestFixture]
    public class ContactManagerTest
    {
        [Test]
        public void GetContacts()
        {
            var controller = new ContactManagerController(new ContactStore());
            var contacts = controller.Get();
            Assert.IsTrue(contacts.Count() > 0);
        }

        [Test]
        public void Post()
        {
            // Post should return a contact
            var config = new HttpConfiguration();
            var kernel = new StandardKernel();
            kernel.Bind<IContactStore>().ToConstant(new ContactStore());
            WebApiConfig.Register(config, kernel);
            var server = new HttpServer(config);
            var client = new HttpClient(server);
            var contact = new Contact() { Firstname = "Test" };
            var response = client.PostAsJsonAsync<Contact>("http://localhost:49680/api/contactmanager", contact).Result;
            var postedContact = response.Content.ReadAsAsync<Contact>().Result;
            Assert.IsNotNull(postedContact);
        }
        
        [TestCase(1,ExpectedResult = true, TestName = "Valid Parameter")]        
        public bool GetContact(int id)  
        {
            var controller = new ContactManagerController(new ContactStore());            
            var contact = controller.Get(id);
            if(contact != null)
                return id == contact.ContactId;
            return false;
        }

        [Test]
        public void Delete()
        {
            var store = new ContactStore();
            var controller = new ContactManagerController(store);
            int id = 2;
            controller.Delete(id);
            Assert.IsNull(store.Get(id));
        }
    }
}
