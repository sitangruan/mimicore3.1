<template>
  <div class="main">
    <div class="logo"></div>
    <div class="appTitle">MIMI Core 3.1</div>
    <div class="error">
      {{ errorMsg }}
    </div>
    <div class="content">
      <div class="input">
        <span class="label">User:</span>
      </div>
      <div class="input">
        <input type="text" class="value" v-model="userName" />
      </div>
      <div class="input">
        <span class="label">Password:</span>
      </div>
      <div class="input">
        <input class="value" type="password" v-model="password" @keypress.enter="doLogin()" />
      </div>
      <div class="btnContainer">
        <input type="button" class="loginBtn" value="Login" @click="doLogin()" />
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'login',
  data() {
    return {
      userName: '',
      password: '',
      errorMsg: '',
    };
  },
  methods: {
    doLogin() {
      axios
        .post('/Login/Index', {
          UserName: this.userName,
          Password: this.password,
        })
        .then(({ data }) => {
          if (data.success) {
            this.errorMsg = '';
            window.location.href = '/Home/Index';
          } else {
            this.errorMsg = data.errorMessage;
          }
        })
        .catch(error => {
          this.errorMsg = 'Error happened when trying to login. Please try again!';
          console.log(error);
        });
    },
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
.main {
  min-height: 500px;
  height: 80%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  .logo {
    background: url('../assets/images/sitangcircle.png') no-repeat center;
    background-size: 100% 100%;
    border-radius: 50%;
    width: 150px;
    height: 150px;
    margin-bottom: 15px;
  }
  .appTitle {
    font-family: 'Oswald-Bold';
    color: #870c03;
    display: font-family;
    justify-content: center;
    line-height: 36px;
    font-size: 36px;
    text-transform: uppercase;
    margin-bottom: 5px;
  }
  .error {
    color: red;
    width: 300px;
    min-height: 24px;
    display: flex;
    justify-content: center;
    margin-bottom: 5px;
  }
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
        .value {
          border-radius: 2px;
          border-width: 1px;
          font-family: 'Oswald-Regular';
          width: 200px;
          height: 24px;
        }
      }
      &.btnContainer {
        display: flex;
        justify-content: center;
        margin-top: 10px;
        .loginBtn {
          border-radius: 2px;
          border-width: 1px;
          width: 100px;
          height: 24px;
          font-family: Oswald-Regular;
        }
      }
    }
  }
}
</style>
