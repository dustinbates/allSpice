<template>
  <div class="row" @click="setActiveRecipe(recipe.id), getRecipeIngredients(recipe.id)" data-bs-toggle="modal"
    data-bs-target="#activeRecipe">
    <div class="col-12 recipeCard">
      <img :src="recipe.img" alt="">
      <div class="overlayTop">
        <p class="m-1">{{ recipe.category }}</p>
      </div>
      <div class="overlayTopRight">
        <p class="m-0 p-0"><i class="mdi mdi-heart-outline fs-4"></i></p>
      </div>
      <div class="overlayBottom fs-5 ps-3">
        <p class="m-1">{{ recipe.title }}</p>
      </div>
    </div>
  </div>
</template>


<script>
import { Recipe } from '../models/Recipe';
import { computed } from 'vue';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';

export default {
  props: {
    recipe: { type: Recipe, required: true }
  },
  setup() {
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe),
      setActiveRecipe(recipeId) {
        recipesService.setActiveRecipe(recipeId)
      },
      async getRecipeIngredients(recipeId) {
        try {
          await recipesService.getRecipeIngredients(recipeId)
        } catch (error) {
          logger.error(error.message)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 40vh;
  width: 100%;
  object-fit: cover;
  border-radius: 5px;
  box-shadow: 1px 1px 6px black;
}

.recipeCard {
  position: relative;
  padding: 0;
}

.overlayTop {
  position: absolute;
  text-align: center;
  top: 0;
  margin: .5em;
  background-color: rgba(0, 0, 0, 0.346);
  color: #fff;
  text-shadow: 1px 1px 1px black;
  width: 25%;
  border-radius: 5px;
}

.overlayTopRight {
  position: absolute;
  text-align: center;
  top: 0;
  right: 0;
  margin: .5em;
  background-color: rgba(0, 0, 0, 0.346);
  color: #fff;
  text-shadow: 1px 1px 1px black;
  width: 10%;
  border-radius: 5px;
}

.overlayBottom {
  position: absolute;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.346);
  color: #fff;
  text-shadow: 1px 1px 1px black;
  width: 90%;
  margin: .5em;
  border-radius: 5px;
}
</style>