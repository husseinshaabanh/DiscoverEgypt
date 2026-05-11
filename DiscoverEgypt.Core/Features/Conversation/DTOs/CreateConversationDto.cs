using System.ComponentModel.DataAnnotations;

namespace DiscoverEgypt.Core.Features.Conversation.DTOs
{
    public class CreateConversationDto
    {
        [Required]
        public string GuideId { get; set; }
    }
}