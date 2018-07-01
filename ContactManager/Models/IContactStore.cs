using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public interface IContactStore
    {
        bool Update(Contact updatedContact);

        Contact Get(int id);

        IQueryable<Contact> Get();

        bool Post(Contact contact);

        bool Delete(int id);
    }
}
