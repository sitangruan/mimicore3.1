<template>
  <div class="headerContainer">
    <div class="flag">
      <div class="logo"></div>
      <div class="slogan">Mimi Core 3.1</div>
    </div>
    <div class="settingContainer">
      <div class="settingTop" @click="toggleSettingDropdown()">
        <div class="user">{{ currentUser.name }}</div>
        <div class="arrowDown" :class="[isSettingExpanded ? 'up' : '']"></div>
      </div>
      <transition name="fade">
        <div v-click-outside="clickOutsideSetting" class="settingDropdown" v-if="isSettingExpanded">
          <div class="settingDropdownItem" @click="setIsHelpModalVisible(true)">Help</div>
          <div class="settingDropdownItem" @click="logout()">Logout</div>
        </div>
      </transition>
    </div>
    <help-modal v-if="isHelpModalVisible"></help-modal>
  </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';
import ClickOutside from 'vue-click-outside';
import apiCaller from '../../api/apiCaller';
import helpModal from './helpModal';

export default {
  name: 'headerBar',
  computed: {
    ...mapGetters('user', ['currentUser']),
    ...mapGetters('common', ['isHelpModalVisible']),
  },
  data() {
    return {
      isSettingExpanded: false,
      expandClicked: false,
    };
  },
  components: {
    helpModal,
  },
  directives: {
    ClickOutside,
  },
  methods: {
    ...mapActions('user', ['getCurrentUser']),
    ...mapMutations('common', ['setIsHelpModalVisible']),
    toggleSettingDropdown() {
      this.expandClicked = true;
      this.isSettingExpanded = !this.isSettingExpanded;
    },
    clickOutsideSetting() {
      if (!this.expandClicked && this.isSettingExpanded) {
        this.isSettingExpanded = false;
      } else {
        this.expandClicked = false;
      }
    },
    logout() {
      apiCaller.logout(
        () => {
          window.location.href = '/Login/Index';
        },
        error => {
          console.log(error);
        },
      );
    },
  },
  created() {
    this.getCurrentUser();
  },
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
      background: url('../../assets/images/sitangcircle.png') no-repeat center;
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
      color: #870c03;
    }
  }
  .settingContainer {
    overflow: visible;
    width: 80px;
    cursor: pointer;
    z-index: 10;
    .settingTop {
      height: 40px;
      display: flex;
      align-items: center;
      justify-content: center;
      .user {
      }
      .arrowDown {
        background: url('../../assets/images/arrow_down.png') no-repeat center;
        background-size: 100% 100%;
        width: 24px;
        height: 24px;
        transition: all 0.3s ease-in-out;
        &.up {
          transform: rotate(180deg);
        }
      }
    }
    .fade-enter-active,
    .fade-leave-active {
      transition: opacity 0.5s;
    }
    .fade-enter,
    .fade-leave-to {
      opacity: 0;
    }
    .settingDropdown {
      display: flex;
      flex-direction: column;
      .settingDropdownItem {
        line-height: 30px;
        display: flex;
        justify-content: center;
        align-items: center;
        box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
        transition: all 0.3s ease-in-out;
        &:hover {
          background-color: #a9c5d4;
        }
      }
    }
  }
}
</style>
