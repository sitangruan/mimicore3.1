<template>
  <div class="side">
    <router-link
      v-for="menu in menus"
      :key="menu.index"
      :to="menu.path"
      class="menuItem"
      :class="currentIndex === menu.index ? 'isFocus' : ''"
      @click.native="focusMenu(menu.index)"
      ><span>{{ menu.name }}</span></router-link
    >
  </div>
</template>

<script>
export default {
  name: 'SideBar',
  data() {
    return {
      menus: [
        {
          index: 0,
          path: '/employee',
          name: 'Employee',
        },
        {
          index: 1,
          path: '/order',
          name: 'Order',
        },
      ],
      currentIndex: 0,
    };
  },
  methods: {
    focusMenu(idx) {
      if (idx >= 0) {
        this.currentIndex = idx;
      }
    },
  },
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
    transition: all 0.2s ease-in-out;
    &:hover,
    &.isFocus {
      background: #a9c5d4;
    }
  }
}
</style>
