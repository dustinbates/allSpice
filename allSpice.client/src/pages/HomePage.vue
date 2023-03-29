<template>
  <div class="container-fluid">
    <div class="row mt-4">
      <div v-for="r in recipes" class="col-12 col-md-4">
        <div class="m-4">
          <Recipe :recipe="r" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, computed } from 'vue';
import { AppState } from '../AppState';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { Recipe } from '../models/Recipe';

export default {
  setup() {
    async function getRecipes() {
      try {
        await recipesService.getRecipes();
      }
      catch (error) {
        logger.error(error);
        Pop.error(error);
      }
    }
    onMounted(() => {
      getRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),
      account: computed(() => AppState.account),

    };
  },
}
</script>

<style scoped lang="scss"></style>
