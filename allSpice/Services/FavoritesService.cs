namespace allSpice.Services
{
    public class FavoritesService
    {
        private readonly FavoritesRepository _repo;

        public FavoritesService(FavoritesRepository repo)
        {
            _repo = repo;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            Favorite favorite = _repo.CreateFavorite(favoriteData);
            return favorite;
        }

    internal List<FavoritedRecipe> GetMyFavorites(string accountId)
    {
      List<FavoritedRecipe> favoritedRecipes = _repo.GetMyFavorites(accountId);
      return favoritedRecipes;
    }

    internal string removeFavorite(int id, string userId)
    {
      Favorite favorite = _repo.GetOneFavorite(id);
      if(favorite == null) throw new Exception($"no favorite at {id}");
      if (favorite.accountId != userId) throw new UnauthorizedAccessException("this is not your favorite to delete");
      _repo.RemoveFavorite(id);
      return "removed your favorited recipe";
    }
  }
}