using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Domain.DTO
{
    public class AddressUpdateDTO
    {

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Complement { get; set; }

        public bool Favorite { get; set; }

        public string Name { get; set; }
    }
}
