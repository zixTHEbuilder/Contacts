using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBook
{
    class ClassContact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ClassContact(string name, long phoneNumber, string emailAddress)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
        }
    }
}
