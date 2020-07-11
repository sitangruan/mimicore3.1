<template>
  <div>
    This is Employee component
  </div>
</template>

<script>
import apiCaller from '../../api/apiCaller';

export default {
  name: 'Employee',
  data() {
    return {
      employees: [],
    };
  },
  created() {
    apiCaller.getEmployees(data => {
      console.log(data);
    });
  },
};
</script>

<style lang="less" scoped></style>
