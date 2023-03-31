<template>
  <header>
    <div class="container header">
      <div class="row">
        <div
          class="col-4 offset-4 text-light text-center d-flex justify-content-center align-items-center text-shadow pt-3 pb-3">
          <p class="fs-1 mt-5">All-Spice
          <p class="fs-5 m-0">Cherish your family</p>
          <p class="fs-5 m-0">And their cooking</p>
          </p>
        </div>
        <div class="col-4 text-end p-3">
          <Login />
        </div>
      </div>
    </div>
  </header>
  <main>
    <router-view />
  </main>
  <footer class="sticky-bottom">
    <button v-if="account.id" type="button" class="btn btn-success btn-lg rounded-pill" data-bs-toggle="modal"
      data-bs-target="#createRecipe" title="create recipe">
      <i class="mdi mdi-plus fs-1"></i>
    </button>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Login from './components/Login.vue'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, Login }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

.header {
  background-image: url(../src/assets/img/header.jpeg);
  min-height: 30vh;
  min-width: 98vw;
  background-size: cover;
  background-position-y: 17%;
  box-shadow: 1px 1px 6px black;
  margin-top: 10px;
}

.text-shadow {
  text-shadow: 1px 1px 1px black;
}


footer {
  display: grid;
  place-content: end;
  margin: 15px;
  height: 32px;
}
</style>
