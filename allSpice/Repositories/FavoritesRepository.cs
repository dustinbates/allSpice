namespace allSpice.Repositories
{
    public class FavoritesRepository
    {
        private readonly IDbConnection _db;

        public FavoritesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Favorite CreateFavorite(Favorite favoriteData)
        {
            string sql = @"
            INSERT INTO favorites
            (accountId, recipeId)
            VALUES
            (@accountId, @recipeId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, favoriteData);
            favoriteData.Id = id;
            return favoriteData;
        }

        internal List<FavoritedRecipe> GetMyFavorites(string accountId)
        {
            string sql = @"
            SELECT
            recipes.*,
            favorites.*,
            creator.*
            FROM favorites
            JOIN recipes ON favorites.recipeId = recipes.id
            JOIN accounts creator ON recipes.creatorId = creator.id
            WHERE favorites.accountId = @accountId;
            ";
            List<FavoritedRecipe> favoritedRecipes = _db.Query<FavoritedRecipe, Favorite, Profile, FavoritedRecipe>(sql, (favoritedRecipe, favorite, profile) => 
            {
                favoritedRecipe.FavoriteId = favorite.Id;
                favoritedRecipe.Creator = profile;
                return favoritedRecipe;
            }, new {accountId}).ToList();
            return favoritedRecipes;
        }

        internal Favorite GetOneFavorite(int id)
        {
            string sql = @"
            SELECT 
            *
            FROM favorites
            WHERE id = @id;
            ";
            Favorite favorite = _db.Query<Favorite>(sql, new{id}).FirstOrDefault();
            return favorite;
        }

        internal void RemoveFavorite(int id)
        {
            string sql = @"
            DELETE
            FROM favorites
            WHERE id = @id;
            ";
            _db.Execute(sql, new{id});
        }

    }
}