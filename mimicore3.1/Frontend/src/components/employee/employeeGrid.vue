<template>
  <div class="employeesView">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToCreateEditPage()">
        <div class="icon"></div>
        <div>Create New Employee</div>
      </div>
      <div class="viewSwitch">
        <div class="viewBox" title="List View" :class="[currentViewMode == 'List' ? 'isActive' : '']">
          <div class="viewIcon list isActive" @click="toggleView()"></div>
        </div>
        <div class="viewBox" title="List View" :class="[currentViewMode == 'Card' ? 'isActive' : '']">
          <div class="viewIcon card" title="Card View" @click="toggleView()"></div>
        </div>
      </div>
    </div>
    <employee-list-view v-if="currentViewMode == 'List'"></employee-list-view>
    <employee-card-view v-else></employee-card-view>
  </div>
</template>

<script>
import { mapActions } from 'vuex';
import EmployeeCardView from './employeeCardView';
import EmployeeListView from './employeeListView';

export default {
  name: 'EmployeeGrid',
  components: {
    EmployeeCardView,
    EmployeeListView,
  },
  data() {
    return {
      employees: [],
      currentViewMode: 'List',
    };
  },
  methods: {
    ...mapActions('employee', ['navigateToCreateEditPage']),
    toggleView() {
      this.currentViewMode = this.currentViewMode === 'List' ? 'Card' : 'List';
    },
  },
  created() {
    this.$store.dispatch('employee/getEmployees');
  },
};
</script>

<style lang="less" scoped>
.employeesView {
  display: flex;
  flex-direction: column;
  .functionRow {
    display: flex;
    justify-content: space-between;
    align-items: center;
    height: 48px;
    .buttonContainer {
      display: flex;
      align-items: center;
      height: 28px;
      cursor: pointer;
      .icon {
        background: url('../../assets/images/add.png') no-repeat center;
        background-size: 100% 100%;
        width: 24px;
        height: 24px;
        margin-right: 10px;
      }
    }
    .viewSwitch {
      display: flex;
      justify-content: flex-end;
      align-items: center;
      align-items: center;
      .viewBox {
        width: 28px;
        height: 28px;
        display: flex;
        justify-content: center;
        align-items: center;
        border: 1px solid black;
        transition: all 0.3s ease-in-out;
        cursor: pointer;
        border-radius: 2px;
        &.isActive {
          background-color: #9194b5;
        }
        .viewIcon {
          width: 22px;
          height: 22px;
          &.list {
            background: url('../../assets/images/listView.png') no-repeat center;
            background-size: 100% 100%;
          }
          &.card {
            background: url('../../assets/images/cardView.png') no-repeat center;
            background-size: 100% 100%;
          }
        }
      }
    }
  }
}
</style>
