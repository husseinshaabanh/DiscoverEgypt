using System;
using System.Collections.Generic;
using System.Text;
using DiscoverEgypt.Core.Features.Authentication.DTOs;

namespace DiscoverEgypt.Core.Features.Authentication.Interfaces
{
    public interface ISocialAuthService
    {
        Task<UserInfoDto> VerifyTokenAsync(string token, string provider);
    }
}
