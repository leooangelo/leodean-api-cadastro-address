﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MS.Address.CrossCutting;
using MS.Address.Domain.Entities;
using MS.Address.Domain.Enum;
using MS.Address.Infra.AsymmetricEncryption;

namespace MS.Address.API.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly ISigningAudienceCertificate _signingAudienceCertificate;
        private readonly IDateTimeNowProvider _dateTimeProvider;

        public TokenGenerator(
            IConfiguration configuration,
            ISigningAudienceCertificate signingAudienceCertificate,
            IDateTimeNowProvider dateTimeProvider
            )
        {
            _configuration = configuration;
            _signingAudienceCertificate = signingAudienceCertificate;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(AddressEntity address, Guid establishmentId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(address, establishmentId);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private SecurityTokenDescriptor GetTokenDescriptor(AddressEntity address, Guid establishmentId)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims(address, establishmentId)),
                Expires = _dateTimeProvider.CurrentDateTime.AddYears(10),
                //Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["JwtCustomer:HoursToExpire"])),
                //SigningCredentials = _signingAudienceCertificate.GetAudienceSigningKey(JwtCertified.Customer)
                SigningCredentials = _signingAudienceCertificate.GetAudienceSigningKey(JwtCertified.User)
            };

            return tokenDescriptor;
        }

        private IEnumerable<Claim> Claims(AddressEntity address, Guid establishmentId)
        {
            var claims = new List<Claim> {
                //new Claim("EstablishmentID", establishmentId.ToString()),
                new Claim("AddressUid", address.AddressID.ToString())
            };

            claims.Add(new Claim(ClaimTypes.Role, "Address"));

            return claims;
        }
    }
}
