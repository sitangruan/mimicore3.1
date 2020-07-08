<template>
  <div id="app">
    <header-bar></header-bar>
    <div class="main">
      <side-bar></side-bar>
      <router-view class="page"></router-view>
    </div>
  </div>
</template>

<script>
import HeaderBar from './headerBar';
import SideBar from './sideBar';

export default {
  name: 'home',
  components: {
    HeaderBar,
    SideBar,
  },
};
</script>

<style lang="less">
@font-face {
  font-family: 'Oswald-Bold';
  src: url('../assets/fonts/Oswald-Bold.ttf');
}

@font-face {
  font-family: 'Oswald-SemiBold';
  src: url('../assets/fonts/Oswald-SemiBold.ttf');
}

@font-face {
  font-family: 'Oswald-Regular';
  src: url('../assets/fonts/Oswald-Regular.ttf');
}

html,
body {
  overflow: auto;
  -ms-overflow-style: auto;
  height: 100%;
  width: 100%;
}

body {
  min-height: 600px;
  min-width: 1080px;
  font-family: Oswald-Regular;
  margin: 0;
  position: relative;
  overflow: hidden;
}
#app {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
  .main {
    display: flex;
    flex: 1;
    .page {
      display: flex;
      flex: 1;
      overflow: hidden;
    }
  }
}
</style>
