using DiscoverEgypt.Core.Features.Favorite.DTOs;

namespace DiscoverEgypt.Core.Features.Favorite.Interfaces
{
    public interface IFavoriteService
    {
        Task AddFavoriteAsync(string userId, int placeId);
        Task RemoveFavoriteAsync(string userId, int placeId);
        Task<List<FavoriteDto>> GetFavoritesAsync(string userId);
    }
}