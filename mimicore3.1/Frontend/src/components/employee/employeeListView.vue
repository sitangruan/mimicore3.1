<template>
  <div class="listView">
    <div class="row header">
      <div v-for="col in columns" :key="col.fieldName" class="title" :class="col.className" @click="doSorting(col)">
        <div>{{ col.title }}</div>
        <div
          class="icon"
          :class="[col.fieldName === sortingField.name ? 'isSorted' : '', sortingField.asc ? '' : 'desc']"
        ></div>
      </div>
    </div>
    <div v-for="emp in sortedEmps" :key="emp.id" class="row data">
      <div v-for="col in columns" :key="col.fieldName" class="cell" :class="col.className">
        <div v-if="col.fieldName === 'createDate'">{{ emp[col.fieldName] | moment('YYYY-MM-DD') }}</div>
        <div v-else>{{ emp[col.fieldName] }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: 'EmployeeListView',
  data() {
    return {
      columns: [
        {
          fieldName: 'firstName',
          className: 'colFirstName',
          title: 'First Name',
        },
        {
          fieldName: 'lastName',
          className: 'colLastName',
          title: 'Last Name',
        },
        {
          fieldName: 'cityName',
          className: 'colCityName',
          title: 'CityName',
        },
        {
          fieldName: 'departmentName',
          className: 'colDepartmentName',
          title: 'Department Name',
        },
        {
          fieldName: 'createDate',
          className: 'colCreateDate',
          title: 'Create Date',
        },
      ],
      sortingField: {
        name: 'firstName',
        asc: true,
      },
    };
  },
  computed: {
    ...mapGetters('employee', ['employees']),
    sortedEmps() {
      return this.employees.slice().sort((a, b) => {
        const biggerValue = this.sortingField.asc ? 1 : -1;
        const smallerValue = 0 - biggerValue;
        if (this.sortingField.name === 'createDate') {
          if (a.createDate > b.createDate) {
            return biggerValue;
          }
          if (a.createDate < b.createDate) {
            return smallerValue;
          }

          return 0;
        }

        const x = a[this.sortingField.name].toLowerCase();
        const y = b[this.sortingField.name].toLowerCase();
        if (x > y) {
          return biggerValue;
        }
        if (x < y) {
          return smallerValue;
        }
        return 0;
      });
    },
  },
  methods: {
    doSorting(col) {
      if (col.fieldName === this.sortingField.name) {
        this.sortingField.asc = !this.sortingField.asc;
      } else {
        this.sortingField.name = col.fieldName;
        this.sortingField.asc = true;
      }
    },
  },
};
</script>

<style lang="less" scoped>
.listView {
  display: flex;
  flex-direction: column;
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
