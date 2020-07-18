<template>
  <div class="employeesView">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToCreateEditPage()">
        <div class="icon"></div>
        <div>Create New Employee</div>
      </div>
      <div class="rightContainer">
        <div class="searchContainer">
          <div class="valueContainer">
            <input type="text" class="value" v-model="searchText" @keypress.enter="doSearch()" />
            <div class="cleanIcon" title="Clean" @click="clearSearch"></div>
          </div>
          <div class="searchIcon" title="Search" @click="doSearch()"></div>
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
    </div>
    <employee-list-view v-if="currentViewMode == 'List'"></employee-list-view>
    <employee-card-view v-else></employee-card-view>
  </div>
</template>

<script>
import { mapActions, mapMutations } from 'vuex';
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
      currentViewMode: 'List',
      searchText: '',
    };
  },
  methods: {
    ...mapActions('employee', ['navigateToCreateEditPage', 'setFilterValue']),
    ...mapMutations('employee', ['setFilterValue']),
    toggleView() {
      this.currentViewMode = this.currentViewMode === 'List' ? 'Card' : 'List';
    },
    doSearch() {
      this.setFilterValue(this.searchText);
    },
    clearSearch() {
      this.searchText = '';
      this.doSearch();
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
    .rightContainer {
      display: flex;
      align-items: center;
      justify-content: space-between;
      width: 400px;
      .searchContainer {
        border: 1px solid black;
        border-radius: 2px;
        width: 280px;
        height: 30px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        .valueContainer {
          display: flex;
          align-items: center;
          .value {
            border-width: 0px 0px 1px 0px;
            width: 180px;
            height: 20px;
            margin-left: 10px;
            font-family: Oswald-Regular;
          }
          .cleanIcon {
            background: url('../../assets/images/clean.png') no-repeat center;
            background-size: 100% 100%;
            width: 16px;
            height: 16px;
            margin-left: 5px;
            cursor: pointer;
          }
        }
        .searchIcon {
          background: url('../../assets/images/search.png') no-repeat center;
          background-size: 100% 100%;
          width: 20px;
          height: 20px;
          cursor: pointer;
        }
      }
      .viewSwitch {
        display: flex;
        justify-content: flex-end;
        align-items: center;
        height: 32px;
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
