<template>
  <div class="headerContainer">
    <div class="flag">
      <div class="logo"></div>
      <div class="slogan">Mimi Core 3.1</div>
    </div>
    <div class="action">
      Action to be implemented
    </div>
  </div>
</template>

<script>
export default {
  name: 'headerBar',
};
</script>

<style lang="less" scoped>
.headerContainer {
  height: 40px;
  box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
  display: flex;
  justify-content: space-between;
  padding: 0 5px;
  .flag {
    display: flex;
    align-items: center;
    .logo {
      background: url('../assets/images/sitangcircle.png') no-repeat center;
      background-size: 100% 100%;
      border-radius: 50%;
      width: 30px;
      height: 30px;
      margin-right: 16px;
    }
    .slogan {
      font-family: Oswald-Bold;
      font-size: 24px;
      text-transform: uppercase;
    }
  }
  .action {
    display: flex;
    align-items: center;
  }
}
</style>
