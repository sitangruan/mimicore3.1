<template>
  <div class="createModal">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToGridPage()">
        <div class="icon"></div>
        <div>Create New Employee</div>
      </div>
    </div>
    <div class="editModal">
      <cool-input :inputValue.sync="firstName" inputName="First Name"></cool-input>
      <br />
      <cool-input :inputValue.sync="lastName" inputName="Last Name"></cool-input>
      <input type="button" @click="clickMe" value="testme" />
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import CoolInput from '../common/coolInput';

export default {
  name: 'CreateEditEmployee',
  data() {
    return {
      firstName: '',
      lastName: '',
    };
  },
  components: {
    CoolInput,
  },
  methods: {
    ...mapActions('employee', ['navigateToGridPage']),
    clickMe() {
      console.log('First Name');
      console.log(this.firstName);
    },
  },
};
</script>

<style lang="less" scoped>
.createModal {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  .functionRow {
    display: flex;
    align-items: center;
    height: 48px;
    .buttonContainer {
      display: flex;
      align-items: center;
      height: 28px;
      cursor: pointer;
      .icon {
        background: url('../../assets/images/backArrow.png') no-repeat center;
        background-size: 100% 100%;
        width: 24px;
        height: 24px;
        margin-right: 10px;
      }
    }
  }
  .editModal {
  }
}
</style>
