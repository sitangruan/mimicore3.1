<template>
  <div class="main">
    <div class="content">
      <div class="input">
        <span class="label">User:</span>
      </div>
      <div class="input">
        <input type="text" />
      </div>
      <div class="input">
        <span class="label">Password:</span>
      </div>
      <div class="input">
        <input type="password" />
      </div>
      <div class="btn">
        <input type="button" value="Login" />
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'login',
};
</script>

<style lang="less">
@font-face {
  font-family: 'Oswald-SemiBold';
  src: url('../assets/fonts/Oswald-SemiBold.ttf');
}

@font-face {
  font-family: 'Oswald-Regular';
  src: url('../assets/fonts/Oswald-Regular.ttf');
}

body {
  min-width: 1280px;
  min-height: 600px;
  font-family: 'Oswald-Regular';
}
.main {
  min-height: 500px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  .content {
    display: flex;
    flex-direction: column;
    > div {
      margin-bottom: 10px;
      &.input {
        display: flex;
        .label {
          font-weight: bold;
          font-family: 'Oswald-SemiBold';
          line-height: 16px;
        }
        input {
          border-radius: 2px;
          border-width: 1px;
          width: 200px;
          height: 24px;
        }
      }
      &.btn {
        display: flex;
        justify-content: center;
        margin-top: 10px;
        input {
          border-radius: 2px;
          border-width: 1px;
          width: 100px;
          height: 24px;
        }
      }
    }
  }
}
</style>
