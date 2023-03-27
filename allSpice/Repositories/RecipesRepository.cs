namespace allSpice.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Recipe CreateRecipe(Recipe recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (creatorId, title, category, instructions, img)
            VALUES
            (@creatorId, @title, @category, @instructions, @img);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal List<Recipe>GetAll()
        {
            string sql = @"
            SELECT
            recipes.*,
            accounts.*
            FROM recipes
            JOIN accounts ON recipes.creatorId = accounts.id;
            ";
            List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) => 
            {
                recipe.Creator = profile;
                return recipe;
            }).ToList();
            return recipes;
        }

        internal Recipe GetOne(int id)
        {
            string sql = @"
            SELECT
            recipes.*,
            accounts.*
            FROM recipes
            JOIN accounts ON recipes.creatorId = accounts.id
            WHERE recipes.id = @id
            ";
            Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) => 
            {
                recipe.Creator = profile;
                return recipe;
            }, new {id}).FirstOrDefault();
            return recipe;
        }

        internal int updateRecipe(Recipe recipe)
        {
            string sql = @"
            UPDATE recipes SET
            instructions = @instructions
            WHERE id = @id;
            ";
            int rows = _db.Execute(sql, recipe);
            return rows;
        }

        internal bool Remove(int id)
        {
            string sql = @"
            DELETE FROM recipes WHERE id = @id;
            ";
            int rows = _db.Execute(sql, new {id});
            return rows == 1;
        }

    }
}