using MS.Address.Domain.DTO.Base;
using System;

namespace MS.Address.DTO.Address
{
    public class ResponseAddressDTO : ResponseBaseDTO
    {
        public Guid AddressID { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public bool Favorite { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public string? CustomerId { get; set; }

        public string? EstablishmentId { get; set; }

        public ResponseAddressDTO() { }

        public ResponseAddressDTO(
            string street,
            string number,
            string neighborhood,
            string city,
            string state,
            string zipCode,
            string complement,
            bool favorite,
            string name,
            bool isActive,
            string? customerId,
            string? establishmentId
            )
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            Complement = complement;
            Favorite = favorite;
            Name = name;
            CustomerId = customerId;
            EstablishmentId = establishmentId;
            IsActive = isActive;
        }
    }
}