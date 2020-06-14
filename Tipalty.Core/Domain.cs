using System;
using System.Dynamic;

namespace Tipalty.Core
{
   public class Person
    {
        public Name FullName { get; set; }
        public Address Address { get; set; }

        public static Person Create(
            string firstName, 
            string lastName,
            string street,
            string city
            )
        {
            var instance = new Person();

            instance.FullName = new Name()
            {
                FirstName = firstName ?? string.Empty,
                LastName = lastName ?? string.Empty
            };

            instance.Address = new Address()
            {
                City = city ?? string.Empty,
                Street = street ?? string.Empty

            };

            return instance;
        }


        protected bool Equals(Person other)
        {
            return Equals(FullName, other.FullName) && Equals(Address, other.Address);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Person) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Address);
        }
    }
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected bool Equals(Name other)
        {
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Name) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
    
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }

        protected bool Equals(Address other)
        {
            return Street == other.Street && City == other.City;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Address) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Street, City);
        }
    }
}
