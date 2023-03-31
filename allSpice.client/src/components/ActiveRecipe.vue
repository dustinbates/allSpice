<template>
  <div class="row">
    <div class="col-5">
      <img :src="recipe.img" alt="">
    </div>
    <div class="col-7 mt-2">
      <h2>{{ recipe.title }}</h2>
      <div class="row mt-3">
        <div class="col-6">
          <h3>Instructions</h3>
          {{ recipe.instructions }}
        </div>
        <div v-for="i in ingredients" class="col-6">
          <h3>Ingredients</h3>
          {{ i.quantity }}
          {{ i.name }}
        </div>
      </div>
    </div>

  </div>
</template>


<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import { Recipe } from '../models/Recipe';

export default {
  setup() {
    return {
      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients)
    }
  }
}
</script>


<style lang="scss" scoped>
img {
  height: 50vh;
  width: 100%;
  object-fit: cover;
}
</style>