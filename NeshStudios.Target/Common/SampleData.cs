using NLipsum.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeshStudios.Target.Common
{
    public static class SampleData
    {
        static Random randDate = new Random(DateTime.Now.Millisecond);
        static DateTime RandomDay()
        {
            DateTime start = new DateTime(1981, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(randDate.Next(range));
        }


        static Random intRnd = new Random(DateTime.Now.Millisecond);

        static int RandomInt(int start = 0, int end = 100)
        {
            int random = intRnd.Next(start, end);
            return random;
        }

        static int NextInt32(this Random rng)
        {
            unchecked
            {
                int firstBits = rng.Next(0, 1 << 4) << 28;
                int lastBits = rng.Next(0, 1 << 28);
                return firstBits | lastBits;
            }
        }

        static decimal NextDecimal(this Random rng)
        {
            byte scale = (byte)rng.Next(29);
            bool sign = rng.Next(2) == 1;
            return new decimal(rng.NextInt32(),
                               rng.NextInt32(),
                               rng.NextInt32(),
                               sign,
                               scale);
        }

        static Random rndDecimal = new Random(DateTime.Now.Millisecond);
        static decimal RandDecimal()
        {
            var random = rndDecimal.NextDecimal();
            return random;
        }

        static Random rndBool = new Random(DateTime.Now.Millisecond);
        static bool RandomBoolean()
        {
            var random = rndBool.Next(2);
            return random == 0;
        }

        public static ObservableCollection<Person> CreatePersons()
        {
            var list = new ObservableCollection<Person>()
            {
                new Person 
                { 
                    Address = new Address
                    {
                        City = "Philadelphia",
                        Line1 = "Common Wealth Suite",
                        Line2 = "APT #21",
                        State = "PA",
                        Zip = "19008",
                    }, 
                    Age=21, 
                    FirstName="Dhinesh", 
                    LastName="Devanathan",
                    BirthDate=DateTime.Now.Date,
                    IsActive = true,
                    Invoices = new List<Invoice>()
                    {
                        new Invoice { ItemName = "Halo", Price=29.00m},
                        new Invoice { ItemName = "Halo 2", Price=39.00m},
                        new Invoice { ItemName = "Halo 3", Price=29.00m},
                        new Invoice { ItemName = "Halo 4", Price=39.00m},
                    },
                },
                new Person 
                { 
                    Address = new Address
                    {
                        City = "Grand Line",
                        Line1 = "Greg Address",
                        Line2 = "Statue #1",
                        State = "Osaka",
                        Zip = "58974",
                    }, 
                    Age=26, 
                    FirstName="Asce", 
                    LastName="Portgas",
                    BirthDate=DateTime.Now.AddDays(20).Date,
                    IsActive = true,
                    Invoices = new List<Invoice>()
                    {
                        new Invoice { ItemName = "SSB", Price=29.00m},
                        new Invoice { ItemName = "SSB 2", Price=39.00m},
                        new Invoice { ItemName = "SSB 3", Price=29.00m},
                        new Invoice { ItemName = "SSB 4", Price=39.00m},
                    },
                },
                new Person 
                { 
                    Address = new Address
                    {
                        City = "Arizona",
                        Line1 = "East washington memorial",
                        Line2 = "APT #36",
                        State = "AZ",
                        Zip = "59715",
                    }, 
                    Age=16, 
                    FirstName="Gol", 
                    LastName="Rodger",
                    BirthDate=DateTime.Now.AddDays(-20).Date,
                    IsActive = false,
                    Invoices = new List<Invoice>()
                    {
                        new Invoice { ItemName = "Jacket", Price=29.00m},
                        new Invoice { ItemName = "Shirt", Price=39.00m},
                        new Invoice { ItemName = "Jeans", Price=29.00m},
                        new Invoice { ItemName = "Dress Pants", Price=39.00m},
                    },
                },
            };

            var lipsum = new LipsumGenerator();


            for (int i = 0; i < 100; i++)
            {
                var p = new Person
                {
                    Address = new Address
                    {
                        City = lipsum.GenerateWords(1).First(),
                        Line1 = lipsum.GenerateWords(4).First(),
                        Line2 = lipsum.GenerateWords(3).First(),
                        State = lipsum.GenerateWords(1).First(),
                        Zip = lipsum.GenerateWords(1).First(),
                    },
                    Age = RandomInt(),
                    FirstName = lipsum.GenerateWords(1).First(),
                    LastName = lipsum.GenerateWords(1).First(),
                    BirthDate = RandomDay(),
                    IsActive = RandomBoolean(),
                    Invoices = new List<Invoice>()
                    {
                        new Invoice { ItemName = lipsum.GenerateWords(1).First(), Price=RandDecimal()},
                        new Invoice { ItemName = lipsum.GenerateWords(1).First(), Price=RandDecimal()},
                        new Invoice { ItemName = lipsum.GenerateWords(1).First(), Price=RandDecimal()},
                        new Invoice { ItemName = lipsum.GenerateWords(1).First(), Price=RandDecimal()},
                    },
                };

                list.Add(p);
            }

            return list;
        }


    }
}
