namespace allSpice.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;

        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
      Recipe recipe = _repo.CreateRecipe(recipeData);
      return recipe;
    }

    internal List<Recipe> Get(string userId)
    {
      List<Recipe> recipes = _repo.GetAll();
      // recipes = recipes.FindAll(r => r.CreatorId == userId);
      return recipes;
    }

    internal Recipe Get(int id, string userId)
    {
      Recipe recipe = _repo.GetOne(id);
      if(recipe == null) throw new Exception("No recipe found");
      if (recipe.CreatorId != userId) throw new Exception("You are not the recipe creator");
      return recipe;
    }

    internal string Remove(int id)
    {
      Recipe recipe = _repo.GetOne(id);
      bool result = _repo.Remove(id);
      if(!result) throw new Exception($"removing this recipe at id {recipe.Id} failed");
      return "removed recipe";

    }

    internal Recipe UpdateRecipe(Recipe updateData, string userId)
    {
      Recipe original = this.Get(updateData.Id, userId);
      original.Instructions = updateData.Instructions != null ? updateData.Instructions : original.Instructions;
      int rowsAffected = _repo.updateRecipe(original);
      if(rowsAffected == 0) throw new Exception("Could not modify recipe");
      if (rowsAffected > 1) throw new Exception("Something broke");
      return original;

    }
  }
}