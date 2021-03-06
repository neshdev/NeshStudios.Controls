﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Target.Model
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }
        public Sport Sport { get; set; }

        public DateTime BirthDate { get; set; }

        public Boolean IsActive { get; set; }

        public List<Invoice> Invoices { get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public int PersonId { get; set; }
        public Person Person  { get; set;}
    }

    public class Sport
    {
        public string Name { get; set; }
        //public Address Address { get; set; }
    }

    public class Invoice
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
    }
}
