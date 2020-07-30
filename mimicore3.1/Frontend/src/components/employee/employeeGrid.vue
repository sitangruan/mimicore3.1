<template>
  <div class="employeesView">
    <div class="functionRow">
      <div class="buttonContainer" @click="navigateToCreateEditPage(0)">
        <div class="icon"></div>
        <div>Create New Employee</div>
      </div>
      <div class="rightContainer">
        <div class="searchContainer">
          <div class="valueContainer">
            <input type="text" class="value" v-model="searchText" @keypress.enter="doSearch()" />
            <div class="cleanIcon" title="Clean" @click="clearSearch()"></div>
          </div>
          <div class="searchIcon" title="Search" @click="doSearch()"></div>
        </div>
        <div class="viewSwitch">
          <div class="viewBox" title="List View" :class="[isListViewMode ? 'isActive' : '']">
            <div class="viewIcon list isActive" @click="toggleViewMode()"></div>
          </div>
          <div class="viewBox" title="List View" :class="[!isListViewMode ? 'isActive' : '']">
            <div class="viewIcon card" title="Card View" @click="toggleViewMode()"></div>
          </div>
        </div>
      </div>
    </div>
    <employee-list-view v-if="isListViewMode"></employee-list-view>
    <employee-card-view v-else></employee-card-view>
  </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';
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
      searchText: '',
    };
  },
  computed: {
    ...mapGetters('employee', ['filterValue', 'isListViewMode']),
  },
  methods: {
    ...mapActions('employee', ['navigateToCreateEditPage', 'setFilterValue']),
    ...mapMutations('employee', ['setFilterValue', 'toggleViewMode']),
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
  mounted() {
    this.searchText = this.filterValue;
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
          height: 100%;
          .value {
            width: 200px;
            height: 100%;
            border: none;
            outline: none;
            box-sizing: border-box;
            padding-left: 5px;
            font-family: Oswald-Regular;
            font-size: 16px;
            &:focus {
              outline: none !important;
            }
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
