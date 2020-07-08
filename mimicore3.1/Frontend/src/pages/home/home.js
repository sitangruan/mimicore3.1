import Vue from 'vue';
import Home from '../../components/home';
import router from '../../router/index';

new Vue({
  el: '#app',
  components: {
    Home,
  },
  router,
  template: '<Home />',
});
