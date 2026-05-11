using DiscoverEgypt.Core.Features.Conversation.DTOs;

namespace DiscoverEgypt.Core.Features.Conversation.Interfaces
{
    public interface IConversationService
    {
        Task<ConversationDto> CreateConversationAsync(string touristId, CreateConversationDto dto);
        Task<List<ConversationDto>> GetMyConversationsAsync(string userId);
        Task<ConversationDto> GetConversationByIdAsync(int id, string userId);
    }
}