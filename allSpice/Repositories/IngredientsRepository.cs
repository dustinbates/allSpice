namespace allSpice.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (recipeId, name, quantity)
            VALUES
            (@recipeId, @name, @quantity);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.Id = id;
            return ingredientData;
        }

        internal List<Ingredient> GetByRecipe(int recipeId)
        {
            string sql = @"
            SELECT
            ing.*
            FROM ingredients ing
            WHERE ing.recipeId = @recipeId;
            ";
            List<Ingredient> ingredients = _db.Query<Ingredient>(sql, new{recipeId}).ToList();
            return ingredients;
        }

        internal Ingredient GetIngredientById( int recipeId)
        {
            string sql = @"
            SElECT
            ing.*
            FROM ingredients ing
            WHERE ing.id = @recipeId;
            ";
            Ingredient ingredient = _db.Query<Ingredient>(sql, new{recipeId}).FirstOrDefault();
            return ingredient;
        }

        internal bool DeleteIngredient(int recipeId)
        {
            string sql = @"
            DELETE
            FROM ingredients
            WHERE id = @recipeId;
            ";
            int rows = _db.Execute(sql, new{recipeId});
            return rows == 1;
        }

    }
}