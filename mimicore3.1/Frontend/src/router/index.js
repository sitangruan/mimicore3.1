import Vue from 'vue';
import Router from 'vue-router';
import Employee from '../components/employee/employee';
import Order from '../components/order/order';
import Log from '../components/log/log';

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
    {
      path: '/log',
      name: 'Log',
      component: Log,
    },
  ],
});

export default router;
