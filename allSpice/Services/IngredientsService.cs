namespace allSpice.Services
{
  public class IngredientsService
  {
    private readonly IngredientsRepository _repo;

    public IngredientsService(IngredientsRepository repo)
    {
        _repo = repo;
    }
    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
      Ingredient ingredient = _repo.CreateIngredient(ingredientData);
      return ingredient;
    }

    internal string DeleteIngredient(int recipeId, Account userInfo)
    {
      Ingredient ingredient = _repo.GetIngredientById(recipeId);
      bool result = _repo.DeleteIngredient(recipeId);
      return $"{ingredient.Name} was deleted";
    }

    internal List<Ingredient> GetByRecipe(int recipeId)
    {
        List<Ingredient> ingredients = _repo.GetByRecipe(recipeId);
        return ingredients;
    }



  }
}