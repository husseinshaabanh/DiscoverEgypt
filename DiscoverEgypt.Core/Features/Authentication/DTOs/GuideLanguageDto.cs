using DiscoverEgypt.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Authentication.DTOs
{
    public class GuideLanguageDto
    {
        [Required]
        public int LanguageId { get; set; }

        [Required]
        public LanguageLevel Level { get; set; }
    }
}