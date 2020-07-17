<template>
  <div class="employeeModal">
    <div class="title">Employees</div>
    <component :is="activeComponent"></component>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex';
import EmployeeGrid from './employeeGrid';
import CreateEditEmployee from './CreateEditEmployee';

export default {
  name: 'Employee',
  components: {
    EmployeeGrid,
    CreateEditEmployee,
  },
  data() {
    return {
      employees: [],
      currentView: 'List',
      isGridView: true,
    };
  },
  computed: {
    ...mapGetters('employee', ['activeComponentIndex']),
    activeComponent() {
      switch (this.activeComponentIndex) {
        case 1:
          return 'CreateEditEmployee';
        case 0:
        default:
          return 'EmployeeGrid';
      }
    },
  },
  methods: {
    ...mapActions('employee', ['navigateToGridPage']),
  },
  created() {
    this.navigateToGridPage();
  },
};
</script>

<style lang="less" scoped>
.employeeModal {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  padding: 10px;
  .title {
    font-size: 24px;
  }
  .employeesView {
    display: flex;
    flex-direction: column;
    .functionRow {
      display: flex;
      justify-content: space-between;
      align-items: center;
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
        height: 48px;
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
}
</style>
