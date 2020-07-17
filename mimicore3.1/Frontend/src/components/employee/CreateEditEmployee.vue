<template>
  <div class="createModal">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToGridPage()">
        <div class="icon"></div>
        <div>Create New Employee</div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapActions } from 'vuex';

export default {
  name: 'CreateEditEmployee',
  methods: {
    ...mapActions('employee', ['navigateToGridPage']),
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
}
</style>
