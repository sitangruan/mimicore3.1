<template>
  <div class="listView">
    <div class="row header">
      <div
        v-for="col in gridColumns"
        :key="col.fieldName"
        class="title"
        :class="col.className"
        @click="doSorting(col.fieldName)"
      >
        <div class="text">
          <span class="ellipsisText">{{ col.title }}</span>
        </div>
        <div
          class="icon"
          :class="[col.fieldName === sortingField.name ? 'isSorted' : '', sortingField.asc ? '' : 'desc']"
        ></div>
      </div>
      <div class="title colOperation">
        <div>Operation</div>
      </div>
    </div>
    <div v-for="emp in sortedEmployees" :key="emp.id" class="row data">
      <div v-for="col in gridColumns" :key="col.fieldName" class="cell" :class="col.className">
        <div v-if="col.fieldName === 'createDate'">{{ emp[col.fieldName] | moment('YYYY-MM-DD') }}</div>
        <div v-else class="text">
          <span class="ellipsisText">{{ emp[col.fieldName] }}</span>
        </div>
      </div>
      <div class="cell colOperation">
        <div class="icon edit" title="Edit"></div>
        <div class="icon delete" title="Delete" @click="deleteEmployee(emp[idField])"></div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters, mapActions, mapMutations } from 'vuex';

export default {
  name: 'EmployeeListView',
  computed: {
    ...mapGetters('employee', ['sortedEmployees', 'sortingField', 'gridColumns', 'idField']),
  },
  methods: {
    ...mapMutations('employee', ['setSortingColumn']),
    ...mapActions('employee', ['deleteEmployee']),
    doSorting(fieldName) {
      this.setSortingColumn(fieldName);
    },
  },
};
</script>

<style lang="less" scoped>
.listView {
  display: flex;
  flex-direction: column;
  .ellipsisText {
    display: inline-block;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
  }
  .row {
    box-shadow: 0 1px 6px 0 rgba(60, 73, 112, 0.25);
    display: flex;
    align-items: center;
    justify-content: space-between;
    margin-bottom: 10px;
    &.data {
      height: 28px;
      box-sizing: border-box;
      &:hover {
        border: 1px solid #54608a;
      }
      .cell {
        display: flex;
        justify-content: start;
        align-items: center;
        padding-left: 10px;
        &.colFirstName {
          width: 120px;
          flex-grow: 1;
        }
        &.colLastName {
          width: 120px;
          flex-grow: 1;
        }
        &.colCityName {
          width: 120px;
          flex-grow: 1;
        }
        &.colDepartmentName {
          width: 150px;
          flex-grow: 1;
        }
        &.colCreateDate {
          width: 120px;
          flex-grow: 1;
        }
        &.colOperation {
          width: 120px;
          flex-grow: 0;
          display: flex;
          align-items: center;
          .icon {
            width: 16px;
            height: 16px;
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
        .text {
          display: flex;
          overflow: hidden;
        }
      }
    }
    &.header {
      height: 30px;
      background-color: #d8e3e8;
      cursor: pointer;
      .title {
        font-family: Oswald-Bold;
        display: flex;
        align-items: center;
        padding-left: 10px;
        &.colFirstName {
          width: 120px;
          flex-grow: 1;
        }
        &.colLastName {
          width: 120px;
          flex-grow: 1;
        }
        &.colCityName {
          width: 120px;
          flex-grow: 1;
        }
        &.colDepartmentName {
          width: 150px;
          flex-grow: 1;
        }
        &.colCreateDate {
          width: 120px;
          flex-grow: 1;
        }
        &.colOperation {
          width: 120px;
          flex-grow: 0;
        }
        .text {
          display: flex;
          overflow: hidden;
        }
        .icon {
          width: 8px;
          height: 8px;
          margin-left: 10px;
          &.isSorted {
            background: url('../../assets/images/sorting.png') no-repeat center;
            background-size: 100% 100%;
            &.desc {
              transform: rotate(180deg);
            }
          }
        }
      }
    }
  }
}
</style>
