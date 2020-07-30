<template>
  <div class="cardViewContainer">
    <employee-card v-for="emp in sortedEmployees" :key="emp.id" :employee="emp"></employee-card>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import EmployeeCard from './employeeCard';

export default {
  name: 'EmployeeCardView',
  components: {
    EmployeeCard,
  },
  computed: {
    ...mapGetters('employee', ['sortedEmployees']),
  },
};
</script>

<style lang="less" scoped>
.cardViewContainer {
  display: flex;
  padding: 5px;
  flex-wrap: wrap;
}
</style>
