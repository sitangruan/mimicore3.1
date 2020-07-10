import Vue from 'vue';
import Home from '../../components/home';
import router from '../../router';
import store from '../../store';

new Vue({
  el: '#app',
  components: {
    Home,
  },
  store,
  router,
  template: '<Home />',
});
