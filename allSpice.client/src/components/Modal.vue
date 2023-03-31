<template>
  <!-- Modal Body -->
  <!-- if you want to close by clicking outside the modal, delete the last endpoint:data-bs-backdrop and data-bs-keyboard -->
  <div class="modal fade" tabindex="-1" data-bs-keyboard="false" role="dialog" aria-labelledby="modalTitleId"
    aria-hidden="true">
    <div class="modal-dialog modal-dialog-scrollable modal-dialog-centered modal-lg" role="document">
      <div class="modal-content">
        <slot>Enter modal info here</slot>
      </div>
    </div>
  </div>
</template>


<script setup>
</script>


<style lang="scss" scoped></style>