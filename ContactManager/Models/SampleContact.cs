using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public static class SampleContact
    {
        private static List<Contact> sampleContacts = new List<Contact>
        {
            new Contact { ContactId =  1,Firstname = "Bhavin", Lastname = "Parmar" , Email = "bhavin.parmar25@outlook.com", Phonenumber = "8411927409", Status = true    },
            new Contact { ContactId =  2, Firstname = "Bhavin", Lastname = "Parmar" , Email = "bhavin.parmar25@outlook.com", Phonenumber = "8411927409", Status = true    },
            new Contact { ContactId =  3, Firstname = "Bhavin", Lastname = "Parmar" , Email = "bhavin.parmar25@outlook.com", Phonenumber = "8411927409", Status = true    },
            new Contact { ContactId =  4,Firstname = "Bhavin", Lastname = "Parmar" , Email = "bhavin.parmar25@outlook.com", Phonenumber = "8411927409", Status = true    },
            new Contact { ContactId =  5,Firstname = "Bhavin", Lastname = "Parmar" , Email = "bhavin.parmar25@outlook.com", Phonenumber = "8411927409", Status = true    }
        };
        public static List<Contact> Contacts
        {
            get
            {
                return sampleContacts;
            }
        }
    }
}