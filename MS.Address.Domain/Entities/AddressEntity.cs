using MS.Address.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Domain.Entities
{
    public class AddressEntity : BaseEntity
    {
        public AddressEntity() { }
        public Guid AddressID { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public bool Favorite { get; private set; }
        public string Name { get; private set; }
        public bool IsActive { get; set; }

        public string? CustomerID { get; private set; }
        public string? EstablishmentID { get; private set; }
    }
}
