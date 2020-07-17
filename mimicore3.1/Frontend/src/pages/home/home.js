import Vue from 'vue';
import vueMoment from 'vue-moment';
import Home from '../../components/home';
import router from '../../router';
import store from '../../store';

Vue.use(vueMoment);

new Vue({
  el: '#app',
  components: {
    Home,
  },
  store,
  router,
  template: '<Home />',
});
