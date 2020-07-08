import Vue from 'vue';
import Router from 'vue-router';
import Employee from '../components/employee';
import Order from '../components/order';

Vue.use(Router);

const router = new Router({
  routes: [
    { path: '/', component: Employee },
    { path: '/employee', name: 'Employee', component: Employee },
    {
      path: '/order',
      name: 'Order',
      component: Order,
    },
  ],
});

export default router;
