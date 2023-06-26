using MS.Address.Domain.Entities;
using System;

namespace MS.Address.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(AddressEntity addressEntity, Guid establishmentId);
    }
}