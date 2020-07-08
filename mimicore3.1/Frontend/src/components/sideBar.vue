<template>
  <div class="side">
    <router-link to="/employee" class="menuItem">Employee</router-link>
    <router-link to="/order" class="menuItem">Order</router-link>
  </div>
</template>

<script>
export default {
  name: 'SideBar',
};
</script>

<style lang="less" scoped>
.side {
  display: flex;
  flex-direction: column;
  width: 200px;
  box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
  .menuItem {
    height: 40px;
    cursor: pointer;
    border-bottom: 1px solid #112442;
    font-size: 20px;
    display: flex;
    justify-content: center;
    align-items: center;
  }
}
</style>
