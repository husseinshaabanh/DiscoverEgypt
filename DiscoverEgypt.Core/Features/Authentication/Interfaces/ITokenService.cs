using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DiscoverEgypt.Core.Entities;

namespace DiscoverEgypt.Core.Features.Authentication.Interfaces
{
    public interface ITokenService
    {
        Task <(string token, DateTime expiresOn)> GenerateTokenAsync(ApplicationUser user);
    }
}
