<template>
  <div class="cardContainer">
    <div class="buttonsRow">
      <div class="buttonsContainer">
        <div class="icon edit" title="Edit" @click="navigateToCreateEditPage(employee[idField])"></div>
        <div class="icon delete" title="Delete" @click="deleteEmployee(employee[idField])"></div>
      </div>
    </div>
    <div class="row">
      <div class="label">First Name:</div>
      <div class="value">
        <span class="ellipsisText">{{ employee.firstName }}</span>
      </div>
    </div>
    <div class="row">
      <div class="label">Last Name:</div>
      <div class="value">
        <span class="ellipsisText">{{ employee.lastName }}</span>
      </div>
    </div>
    <div class="row">
      <div class="label">Address:</div>
      <div class="value">
        <span class="ellipsisText">{{ employee.address }}</span>
      </div>
    </div>
    <div class="row">
      <div class="label">City:</div>
      <div class="value">
        <span class="ellipsisText">{{ employee.cityName }}</span>
      </div>
    </div>
    <div class="row">
      <div class="label">Department:</div>
      <div class="value">
        <span class="ellipsisText">{{ employee.departmentName }}</span>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';

export default {
  name: 'EmployeeCard',
  props: {
    employee: {},
  },
  computed: {
    ...mapGetters('employee', ['idField']),
  },
  methods: {
    ...mapActions('employee', ['deleteEmployee', 'navigateToCreateEditPage']),
  },
};
</script>

<style lang="less" scoped>
.cardContainer {
  border-radius: 2px;
  box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
  display: flex;
  flex-direction: column;
  width: 280px;
  height: 160px;
  flex-shrink: 0;
  flex-grow: 0;
  padding: 5px;
  box-sizing: border-box;
  margin-right: 10px;
  margin-bottom: 10px;
  &:hover {
    border: 1px solid #54608a;
    .buttonsRow {
      .buttonsContainer {
        display: flex;
        .icon {
          width: 10px;
          height: 16px;
          padding-right: 5px;
          cursor: pointer;
          &.edit {
            background: url('../../assets/images/edit.png') no-repeat center;
            background-size: 100% 100%;
            margin-right: 10px;
          }
          &.delete {
            background: url('../../assets/images/delete.png') no-repeat center;
            background-size: 100% 100%;
          }
        }
      }
    }
  }
  .ellipsisText {
    display: inline-block;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }
  .buttonsRow {
    display: flex;
    height: 20px;
    justify-content: flex-end;
    align-items: center;
    .buttonsContainer {
      display: none;
    }
  }
  .row {
    display: flex;
    align-items: center;
    .label {
      font-family: Oswald-Bold;
      width: 100px;
      flex-shrink: 0;
      display: flex;
      justify-content: flex-end;
      padding-right: 5px;
    }
    .value {
      flex-grow: 1;
      display: flex;
      overflow: hidden;
    }
  }
}
</style>
