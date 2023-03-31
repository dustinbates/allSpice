import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";
import { Recipe } from "../models/Recipe"

class RecipesService{

  async getRecipes(){
    const res = await api.get('api/recipes')
    logger.log('[Got Recipes]', res.data)
    const recipes = res.data.map(r => new Recipe(r))
    AppState.recipes = recipes
  }

  setActiveRecipe(recipeId){
    AppState.activeRecipe = AppState.recipes.find(r => r.id == recipeId)
    logger.log('[Setting Recipe]', AppState.activeRecipe)
  }

  async getRecipeIngredients(recipeId){
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('[Getting Ingredients]', res.data)
    AppState.ingredients = res.data
  }

  async createRecipe(recipeData){
    const res = await api.post('api/recipes', recipeData)
    logger.log('[Created Recipe]', res.data)
    AppState.recipes.push(res.data)
  }


}

export const recipesService = new RecipesService();