<template>
  <div class="helpModalMask">
    <div class="modalContainer">
      <div class="content">
        <div class="title">About Mimi Core 3.1</div>
        <div class="description">
          <p>
            Hello, I am very pleased to have you visiting this page! Mimi core 3.1 is a project I did for myself to
            practice the idea of using Vue.js in Visual Studio to build a SPA (Single Page Application).
          </p>
          <p>
            In the beigining I named the project as mimi, because I just planed to do a small (but full functional!)
            project like a pet, and mimi is a common nickname for little cats in China. However at the moment when I
            just started the project and needed to choose the .NET framework in Visual Stuio 2019, I was a bit surprised
            to see .NET core 3.1 was already there! I liked to try this new thing, so I chose it as the target framework
            and added it as part of the project name.
          </p>
          <p>
            The major purpose of this project is to practice Vue.js coding. The backend is simple and it mostly behaves
            as a REST service just to provide data via API. To be simple, there is no database usage involved either.
            All the data you see here is generated from C# static methods, and the changes you do on the page can be
            saved but only persistable in memory during runtime.
          </p>
          <p>
            Developing this project is an interesting journey of learning and practicing. I really got much fun from it!
            Mimi Core 3.1 provides a ready-to-go front end codes template with Vue.js which can be easily extended to
            implement new business requirements. Enjoy it!
          </p>
        </div>
      </div>
      <div class="buttonRow">
        <input type="button" value="OK" @click="setIsHelpModalVisible(false)" />
      </div>
    </div>
  </div>
</template>

<script>
import { mapMutations } from 'vuex';

export default {
  name: 'helpModal',
  methods: {
    ...mapMutations('common', ['setIsHelpModalVisible']),
  },
};
</script>

<style lang="less" scoped>
.helpModalMask {
  position: absolute;
  left: 0;
  top: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.1);
  transition: opacity 0.3s ease;
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 100;
  .modalContainer {
    z-index: 110;
    width: 720px;
    height: 500px;
    box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
    background-color: #ffffff;
    border-radius: 2px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    .content {
      .title {
        display: flex;
        justify-content: center;
        margin-top: 10px;
        font-family: Oswald-Bold;
        font-size: 20px;
        text-transform: uppercase;
        color: #870c03;
      }
      .description {
        margin-top: 10x;
        padding: 5px;
      }
    }
    .buttonRow {
      display: flex;
      justify-content: center;
      margin-bottom: 10px;
      input[type='button'] {
        font-family: Oswald-Regular;
        width: 80px;
      }
    }
  }
}
</style>
