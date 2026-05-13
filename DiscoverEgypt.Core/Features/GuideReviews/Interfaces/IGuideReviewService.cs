using DiscoverEgypt.Core.Features.GuideReviews.DTOs;

namespace DiscoverEgypt.Core.Features.GuideReviews.Interfaces
{
    public interface IGuideReviewService
    {
        Task AddAsync(string userId, CreateGuideReviewDto dto);
        Task<List<GuideReviewDto>> GetByGuideAsync(string guideId);
        Task DeleteAsync(int reviewId, string userId);
    }
}
