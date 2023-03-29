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




}

export const recipesService = new RecipesService();