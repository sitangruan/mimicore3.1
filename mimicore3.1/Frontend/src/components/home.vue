<template>
  <div id="app">
    <header-bar></header-bar>
  </div>
</template>

<script>
import HeaderBar from './headerBar';

export default {
  name: 'home',
  components: {
    HeaderBar,
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
  min-height: 800px;
  min-width: 1280px;
  font-family: Oswald-Regular;
}
</style>
