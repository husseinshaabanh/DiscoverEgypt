using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Roles.DTOs
{
    public class AssignRoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}