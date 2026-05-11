using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Users.DTOs
{
    public class UpdateUserDto
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }
    }
}