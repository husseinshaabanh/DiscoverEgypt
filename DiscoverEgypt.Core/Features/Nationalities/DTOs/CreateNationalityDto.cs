using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Nationalities.DTOs
{
    public class CreateNationalityDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public string? NameAr { get; set; }
    }
}