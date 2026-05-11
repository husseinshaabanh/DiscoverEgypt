using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoverEgypt.Core.Features.Authentication.DTOs
{
    public class SocialLoginDto
    {
        public string Token { get; set; }
        public string Provider { get; set; }
    }
}
