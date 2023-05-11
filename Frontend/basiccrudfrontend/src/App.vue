<script>
import { RouterLink, RouterView } from 'vue-router';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import ProjectHeader from './components/Header.vue';
import projectFooter from './components/Footer.vue';
// import DateTime from './components/DateTime.vue';
export default {
  name: 'App',
  components: {
    ProjectHeader,
    projectFooter,
    // DateTime
    
  },
};
</script>

<template>
  <div >
    <div class="md-12 ">
      <projectHeader />
    </div>
    
    <div class="md-12 content">
      <RouterView />
    </div>
    
    <div class="md-12 footer">
      <projectFooter />
    </div>
  </div>
</template>

<style scoped>
  .header{
    max-height: 10%;
  }
.content{
  min-height: 643px;
}
.footer {
  margin-top: 50px;
  left: 0;
  bottom: 0;
  width: 100%;
  z-index: -1;
}
</style>
