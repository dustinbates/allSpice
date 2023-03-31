<template>
  <div class="container-fluid p-0">
    <h1 class="top text-center">New Recipe</h1>
    <form class="row m-2" @submit.prevent="createRecipe()">
      <div class="col-6 mt-3">
        <label for="" class="form-label">Title</label>
        <input type="text" class="form-control" v-model="editable.title" name="title" id="" aria-describedby="helpId"
          placeholder="Title...">
      </div>
      <div class="col-6 mt-3">
        <label for="" class="form-label">Category</label>
        <input type="text" class="form-control" v-model="editable.category" name="category" id=""
          aria-describedby="helpId" placeholder="Appetizer...">
      </div>
      <div class=" col-12 mt-3">
        <label for="" class="form-label">Image</label>
        <input type="text" class="form-control" v-model="editable.img" name="img" id="" aria-describedby="helpId"
          placeholder="url...">
      </div>
      <div class="col-12  mt-3 mb-3">
        <label for="" class="form-label">Instructions</label>
        <input type="text" class="form-control" v-model="editable.instructions" name="instructions" id=""
          araia-describedby="helpId" placeholder="Instructions...">
      </div>

      <button class="btn btn-success">Get Cooking</button>
    </form>


  </div>
</template>


<script>
import { ref } from 'vue';
import { recipesService } from '../services/RecipesService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createRecipe() {
        try {
          await recipesService.createRecipe(editable.value)
          editable.value = {}
        } catch (error) {
          logger.error(error)
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.top {
  border-top-right-radius: 5px;
  border-top-left-radius: 5px;
  background-color: #288755;
  color: whitesmoke;
  margin: 0;
  padding: .25em;
}
</style>